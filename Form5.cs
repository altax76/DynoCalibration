using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Windows.Forms.DataVisualization.Charting;
using MathWorks.MATLAB.NET.Arrays; // Include MWArray library
using MathWorks.MATLAB.NET.Utility; // Include MWArray utility library

using calculateMetrics; // Add your MATLAB assembly namespace

namespace DynoCalibration
{
    public partial class Form5 : Form
    {
        private string excelFilePath;
        double[] time_array;
        double[] roller_rpm_array;
        double engineHp;
        double engineRpm;

        private string configFilePath;

        double torqueX2Coef;
        double torqueX1Coef;
        double torqueX0Coef;
        double hpX2Coef;
        double hpX1Coef;
        double hpX0Coef;

        double[] filteredEngineHPArray;
        double[] filteredEngineTorqueArray;
        double[] engineRPMArray;
        double[] correctedTorque;
        double[] correctedHP;

        bool fileSaved = false;

        public Form5()
        {
            InitializeComponent();

            configFilePath = "C:\\Users\\anton\\source\\repos\\DynoCalibration\\dynoConfig.xlsx";

            textBox1.Text = "C:\\Users\\anton\\Desktop\\FilteringTestMatlab\\11_1_24_test1.xlsx";


            excelFilePath = textBox1.Text;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


            if (!File.Exists(configFilePath))
            {
                Console.WriteLine("Error: File does not exist.");
                return;
            }

            try
            {
                // Open the existing Excel file
                FileInfo existingFile = new FileInfo(configFilePath);
                using (ExcelPackage excel = new ExcelPackage(existingFile))
                {
                    // Get the first worksheet in the workbook (or you can get a specific one)
                    var worksheet = excel.Workbook.Worksheets[0]; // Accessing the first worksheet

                    // Get cell Data
                    torqueX2Coef = (double)worksheet.Cells[6, 12].Value;
                    torqueX1Coef = (double)worksheet.Cells[7, 12].Value;
                    torqueX0Coef = (double)worksheet.Cells[8, 12].Value;
                    hpX2Coef = (double)worksheet.Cells[9, 12].Value;
                    hpX1Coef = (double)worksheet.Cells[10, 12].Value;
                    hpX0Coef = (double)worksheet.Cells[11, 12].Value;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //Loading Excel Data
            //calWeightTextBox.Text = calWeight.ToString("0.0");


        }

        private void runTestButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(excelFilePath))
            {
                Console.WriteLine("Error: File does not exist.");
                return;
            }
            try
            {
                // Open the existing Excel file
                FileInfo existingFile = new FileInfo(excelFilePath);
                using (ExcelPackage excel = new ExcelPackage(existingFile))
                {
                    // Get the first worksheet in the workbook
                    var worksheet = excel.Workbook.Worksheets[0];

                    // Create lists to store values from columns A and B
                    List<string> columnAData = new List<string>();
                    List<string> columnBData = new List<string>();

                    // Determine the number of rows in the worksheet
                    int rowCount = worksheet.Dimension.End.Row;

                    // Loop through each row to get data from columns A and B
                    for (int row = 2; row <= rowCount; row++)
                    {
                        // Get values from column A and column B
                        var valueA = worksheet.Cells[row, 1].Text; // Column A
                        var valueB = worksheet.Cells[row, 2].Text; // Column B

                        // Add values to respective lists
                        columnAData.Add(valueA);
                        columnBData.Add(valueB);
                    }

                    // Parse and convert lists to arrays
                    time_array = columnAData.Select(value => double.TryParse(value, out double parsedValue) ? parsedValue : 0.0).ToArray();
                    roller_rpm_array = columnBData.Select(value => double.TryParse(value, out double parsedValue) ? parsedValue : 0).ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            UpdateChart();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            excelFilePath = textBox1.Text;
        }

        private void UpdateChart()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.DataBindXY(time_array, roller_rpm_array);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var output = new calculateMetrics.Class1();

            double window_size = 21;          
            double polynomial_order = 5;     
            double engine_wheel_ratio = 8.3;   
            double wheel_roller_ratio = 1.93;   
            double linear_equivalent_mass = 600;  
            double roller_radius = 4;

            MWNumericArray mwTimeArray = new MWNumericArray(time_array);
            MWNumericArray mwRollerRpmArray = new MWNumericArray(roller_rpm_array);
            MWNumericArray mwWindowSize = new MWNumericArray(window_size);
            MWNumericArray mwPolynomialOrder = new MWNumericArray(polynomial_order);
            MWNumericArray mwEngineWheelRatio = new MWNumericArray(engine_wheel_ratio);
            MWNumericArray mwWheelRollerRatio = new MWNumericArray(wheel_roller_ratio);
            MWNumericArray mwLinearEquivalentMass = new MWNumericArray(linear_equivalent_mass);
            MWNumericArray mwRollerRadius = new MWNumericArray(roller_radius);

            var results = output.calculateMetrics(5,mwTimeArray, mwRollerRpmArray, mwWindowSize, mwPolynomialOrder, mwEngineWheelRatio, mwWheelRollerRatio, mwLinearEquivalentMass, mwRollerRadius);

            double[] engineHPArray = (double[])((MWNumericArray)results[0]).ToVector(MWArrayComponent.Real);
            double[] engineTorqueArray = (double[])((MWNumericArray)results[1]).ToVector(MWArrayComponent.Real);
            engineRPMArray = (double[])((MWNumericArray)results[2]).ToVector(MWArrayComponent.Real);
            filteredEngineHPArray = (double[])((MWNumericArray)results[3]).ToVector(MWArrayComponent.Real);
            filteredEngineTorqueArray = (double[])((MWNumericArray)results[4]).ToVector(MWArrayComponent.Real);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.Series[0].Points.DataBindXY(engineRPMArray, filteredEngineHPArray);
            chart1.Series[1].Points.DataBindXY(engineRPMArray, filteredEngineTorqueArray);

            chart1.Series[0].Name = "HP";
            chart1.Series[1].Name = "Torque";

            chart1.ChartAreas[0].AxisX.Minimum = 4000;  // Set X-axis minimum
            chart1.ChartAreas[0].AxisX.Maximum = 12000; // Set X-axis maximum

            double maxTorque = filteredEngineTorqueArray.Max();
            int maxTorqueRPMIndex = Array.IndexOf(filteredEngineTorqueArray, maxTorque);
            double maxTorqueRPM = engineRPMArray[maxTorqueRPMIndex];

            double maxHP = filteredEngineHPArray.Max();
            int maxHPRPMIndex = Array.IndexOf(filteredEngineHPArray, maxHP);
            double maxHPRPM = engineRPMArray[maxHPRPMIndex];

            string maxTorqueLabel = ("Max Torque: " + Math.Round(maxTorque,1).ToString() + " ft*lb @ " + Math.Round(maxTorqueRPM,0).ToString() + " RPM");
            string maxHPLabel = ("  |  Max HP: " + Math.Round(maxHP, 1).ToString() + " HP @ " + Math.Round(maxHPRPM, 0).ToString() + " RPM");

            double timeOfTest = time_array.Last();
            string testTime = ("  |  Length of Test: " + Math.Round(timeOfTest, 2));

            label7.Text = (maxTorqueLabel + maxHPLabel + testTime + " sec");


        }

        private void addCD_Click(object sender, EventArgs e)
        {
            // Ensure the arrays are initialized
            if (filteredEngineHPArray == null || filteredEngineTorqueArray == null || engineRPMArray == null)
            {
                MessageBox.Show("Error: Data arrays are not initialized.");
                return;
            }

            // Initialize the corrected arrays if they haven't been initialized
            if (correctedTorque == null || correctedTorque.Length != filteredEngineHPArray.Length)
            {
                correctedTorque = new double[filteredEngineHPArray.Length];
            }

            if (correctedHP == null || correctedHP.Length != filteredEngineHPArray.Length)
            {
                correctedHP = new double[filteredEngineHPArray.Length];
            }

            // Calculate corrected values
            for (int i = 0; i < filteredEngineHPArray.Length; i++)
            {
                correctedTorque[i] = filteredEngineTorqueArray[i] - (Math.Pow(engineRPMArray[i], 2) * torqueX2Coef
                                     + engineRPMArray[i] * torqueX1Coef + torqueX0Coef);

                correctedHP[i] = filteredEngineHPArray[i] - (Math.Pow(engineRPMArray[i], 2) * hpX2Coef
                                 + engineRPMArray[i] * hpX1Coef + hpX0Coef);
            }

            // Update chart with corrected data
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[0].Points.DataBindXY(engineRPMArray, correctedHP);
            chart1.Series[1].Points.DataBindXY(engineRPMArray, correctedTorque);

            double maxTorque = correctedTorque.Max();
            int maxTorqueRPMIndex = Array.IndexOf(correctedTorque, maxTorque);
            double maxTorqueRPM = engineRPMArray[maxTorqueRPMIndex];

            double maxHP = correctedHP.Max();
            int maxHPRPMIndex = Array.IndexOf(correctedHP, maxHP);
            double maxHPRPM = engineRPMArray[maxHPRPMIndex];

            string maxTorqueLabel = ("Max Torque: " + Math.Round(maxTorque, 1).ToString() + " ft*lb @ " + Math.Round(maxTorqueRPM, 0).ToString() + " RPM");
            string maxHPLabel = ("  |  Max HP: " + Math.Round(maxHP, 1).ToString() + " HP @ " + Math.Round(maxHPRPM, 0).ToString() + " RPM");

            double timeOfTest = time_array.Last();
            string testTime = ("  |  Length of Test: " + Math.Round(timeOfTest, 2));

            label7.Text = (maxTorqueLabel + maxHPLabel + testTime + " sec");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileSaved)
            {

                //time_array.Clear();
                //roller_rpm_array.Clear();

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.Series[0].Name = "RPM";
                chart1.Series[1].Name = "None";

                chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Set X-axis minimum
                chart1.ChartAreas[0].AxisX.Maximum = Double.NaN; // Set X-axis maximum

                fileSaved = false;
            }

            {
                DialogResult result = MessageBox.Show(
                "File not saved. Do you want to continue?",   // Message
                "Unsaved File",                              // Title
                MessageBoxButtons.OKCancel,              // Buttons (Retry will act as "Refresh")
                MessageBoxIcon.Warning                      // Icon
                );

                // Handle the result
                if (result == DialogResult.OK)
                {
                    chart1.Series[0].Points.Clear();
                    chart1.Series[1].Points.Clear();

                    chart1.Series[0].Name = "RPM";
                    chart1.Series[1].Name = "None";

                    chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Set X-axis minimum
                    chart1.ChartAreas[0].AxisX.Maximum = Double.NaN; // Set X-axis maximum
                }
                else if (result == DialogResult.Cancel)
                {
                    // Code for cancel action
                    MessageBox.Show("Refresh Canceled.");
                }
            }

        }
    }
}
