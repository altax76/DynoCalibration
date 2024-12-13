using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static OfficeOpenXml.ExcelErrorValue;
using MathWorks.MATLAB.NET.Arrays; // Include MWArray library
using MathWorks.MATLAB.NET.Utility; // Include MWArray utility library

using calculateMetrics; // Add your MATLAB assembly namespace

namespace DynoCalibration
{
    public partial class Form3 : Form
    {
        private string excelFilePath;

        private string configFilePath;

        private string serial;

        private bool testing = false;
        private bool startButtonPressed = false;
        private bool hasFallenBelowPullStart = false;

        private bool testStart = false;

        List<double> rollerRPMList = new List<double>();                    //rev/min
        List<double> timeList = new List<double>();             //sec

        double[] rollerRPMArray;
        double[] timeStampArray;
        double[] engineHPArray;
        double[] engineTorqueArray;
        double[] engineRPMArray;
        double[] filteredEngineHPArray;
        double[] filteredEngineTorqueArray;

        double currentRollerRPM;
        double currentEngineRPM;


        private double engineWheelRatio;
        private double wheelRollerRatio;
        private double rollerMass;
        private double rollerDiameter;
        private double pullStart;
        private double pullStop;

        private string runFilePath;
        private string runFileName;

        private double[] torqueCoef = new double[3];
        private double[] HPCoef = new double[3];

        private double[] correctedEngineHPArray;
        private double[] correctedEngineTorqueArray;

        double[] coastDownTimeStampArray;
        double[] coastDownRollerRPMArray;

        bool fileSaved = false;

        public Form3()
        {
            InitializeComponent();
            serialPort1.Open();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            timer1.Enabled = true;

            configFilePath = "C:\\Users\\anton\\source\\repos\\DynoCalibration\\dynoConfig.xlsx";

            //Load Saved Data

            //Strain Gauge Calibration
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
                    engineWheelRatio = (double)worksheet.Cells[4, 9].Value;
                    wheelRollerRatio = (double)worksheet.Cells[5, 9].Value;
                    rollerMass = (double)worksheet.Cells[6, 9].Value;
                    rollerDiameter = (double)worksheet.Cells[7,9].Value;
                    pullStart = (double)worksheet.Cells[8,9].Value;
                    pullStop = (double)worksheet.Cells[9, 9].Value;
                    runFilePath = (string)worksheet.Cells[10, 9].Value;
                    runFileName = (string)worksheet.Cells[11,9].Value;
                    torqueCoef[0] = (double)worksheet.Cells[6, 12].Value;
                    torqueCoef[1] = (double)worksheet.Cells[7, 12].Value;
                    torqueCoef[2] = (double)worksheet.Cells[8, 12].Value;
                    HPCoef[0] = (double)worksheet.Cells[9, 12].Value;
                    HPCoef[1] = (double)worksheet.Cells[10, 12].Value;
                    HPCoef[2] = (double)worksheet.Cells[11, 12].Value;
                }

                using (ExcelPackage excel = new ExcelPackage(existingFile))
                {
                    // Get the second worksheet in the workbook
                    var worksheet = excel.Workbook.Worksheets[1];

                    // Get the total number of rows used in the worksheet
                    int totalRows = worksheet.Dimension.Rows;

                    // Create arrays to store values from columns 1 and 2
                    coastDownTimeStampArray = new double[totalRows - 1];       // Exclude the header row
                    coastDownRollerRPMArray = new double[totalRows - 1]; // Exclude the header row

                    // Iterate through the rows starting from row 2
                    for (int row = 2; row <= totalRows; row++)
                    {
                        // Read the value from column 1
                        var timeCellValue = worksheet.Cells[row, 1].Value;
                        var rpmCellValue = worksheet.Cells[row, 2].Value;

                        // Convert the values to double and store them in the arrays
                        // Add null or empty checks before conversion to avoid exceptions
                        if (timeCellValue != null && double.TryParse(timeCellValue.ToString(), out double timeResult))
                        {
                            coastDownTimeStampArray[row - 2] = timeResult;
                        }
                        else
                        {
                            throw new InvalidDataException($"Invalid data at row {row}, column 1 (Time).");
                        }

                        if (rpmCellValue != null && double.TryParse(rpmCellValue.ToString(), out double rpmResult))
                        {
                            coastDownRollerRPMArray[row - 2] = rpmResult;
                        }
                        else
                        {
                            throw new InvalidDataException($"Invalid data at row {row}, column 2 (Roller RPM).");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //Loading Excel Data
            engineToWheelRatioTextBox.Text = engineWheelRatio.ToString("0.00");
            wheelToRollerRatioTextBox.Text = wheelRollerRatio.ToString("0.00");
            rollerMassTextBox.Text = rollerMass.ToString("0.00");
            rollerDiameterTextBox.Text = rollerDiameter.ToString("0.00");
            pullStartTextBox.Text = pullStart.ToString("0");
            pullStopTextBox.Text = pullStop.ToString("0");
            filePathTextBox.Text = runFilePath;
            fileNameTextBox.Text = runFileName;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                serialPort1.Write("rpm_start");
                testStart = true;
                startButton.Text = "Stop";
                StartButtonPressed();
                chart1.ChartAreas[0].AxisX.Minimum = 0;
            }
            else if (startButton.Text == "Stop")
            {
                serialPort1.Write("rpm_stop");
                testStart =  false;
                startButton.Text = "Start";
            }
        }

        private void chartRefreshButton_Click(object sender, EventArgs e)
        {

            if (fileSaved)
            {

                rollerRPMList.Clear();
                timeList.Clear();

                initialTimestamp = -1; // Reset the initial timestamp
                serialPort1.DiscardInBuffer(); // Clear the input buffer
                serialPort1.DiscardOutBuffer(); // Clear the output buffer

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.Series[0].Name = "RPM";
                chart1.Series[1].Name = "None";

                chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Set X-axis minimum
                chart1.ChartAreas[0].AxisX.Maximum = Double.NaN; // Set X-axis maximum

                fileSaved = false;
            }

            else
            {
                DialogResult result = MessageBox.Show(
                "File not saved, do you want to refresh?",   // Message
                "Unsaved File",                              // Title
                MessageBoxButtons.RetryCancel,              // Buttons (Retry will act as "Refresh")
                MessageBoxIcon.Warning                      // Icon
                );

                // Handle the result
                if (result == DialogResult.Retry)
                {
                    // Code to refresh
                    MessageBox.Show("Refreshing...");
                    rollerRPMList.Clear();
                timeList.Clear();

                initialTimestamp = -1; // Reset the initial timestamp
                serialPort1.DiscardInBuffer(); // Clear the input buffer
                serialPort1.DiscardOutBuffer(); // Clear the output buffer

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.Series[0].Name = "RPM";
                chart1.Series[1].Name = "None";

                chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;  // Set X-axis minimum
                chart1.ChartAreas[0].AxisX.Maximum = Double.NaN; // Set X-axis maximum

                fileSaved = false;
                }
                else if (result == DialogResult.Cancel)
                {
                    // Code for cancel action
                    MessageBox.Show("Operation canceled.");
                }
            }

        }

        private double initialTimestamp = -1;

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (testStart)
            {
                string serial = serialPort1.ReadLine();
                if (serial.StartsWith("s"))
                {
                    serial = serial.Substring(1);
                    string[] parts = serial.Split(' ');

                    if (parts.Length == 2)
                    {
                        currentRollerRPM = double.Parse(parts[0]);
                        double timestamp = double.Parse(parts[1]);
                        currentEngineRPM = ((double)currentRollerRPM * engineWheelRatio / wheelRollerRatio);

                        if (testing)
                        {
                            testing = true;
                            this.Invoke(new MethodInvoker(delegate
                            {
                                if (initialTimestamp < 0)
                                {
                                    initialTimestamp = timestamp;
                                }

                                double offsetTimestamp = timestamp - initialTimestamp;

                                rollerRPMList.Add(currentRollerRPM);
                                timeList.Add(offsetTimestamp);

                                rollerRPMArray = rollerRPMList.ToArray();
                                timeStampArray = timeList.ToArray();

                                chart1.Series[0].Points.Clear();
                                chart1.Series[0].Points.DataBindXY(timeStampArray, rollerRPMArray);

                            }));
                        }
                    }
                }
            }
        }


        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            excelFilePath = filePathTextBox.Text + "\\" + fileNameTextBox.Text + ".xlsx";

            using (ExcelPackage package = new ExcelPackage())

            {
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Interia Pull");

                // Write some data to the worksheet
                worksheet.Cells[1, 1].Value = "Time [sec]";
                worksheet.Cells[1, 2].Value = "Roller RPM [rev/min]"; 
                worksheet.Cells[1, 3].Value = "Engine RPM [rev/min]";
                worksheet.Cells[1, 4].Value = "Raw Wheel Torque [ft*lb]";
                worksheet.Cells[1, 5].Value = "Raw Wheel HP [HP]";
                worksheet.Cells[1, 6].Value = "Filtered Wheel Torque [ft*lb]";
                worksheet.Cells[1, 7].Value = "Filtered Wheel HP [HP]";
                worksheet.Cells[1, 8].Value = "Corrected Engine Torque [ft*lb]";
                worksheet.Cells[1, 9].Value = "Corrected Engine HP [HP]";


                double[] rollerRPMArray = rollerRPMList.ToArray();
                double[] timeStampArray = timeList.ToArray();
                

                for (int i = 0; i < rollerRPMArray.Length; i++)
                {
                    worksheet.Cells[2 + i, 1].Value = timeStampArray[i];
                    worksheet.Cells[2 + i, 2].Value = rollerRPMArray[i];
                    if (i > 0)
                    {
                        worksheet.Cells[2 + i, 3].Value = engineRPMArray[i - 1];
                        worksheet.Cells[2 + i, 4].Value = engineTorqueArray[i - 1];
                        worksheet.Cells[2 + i, 5].Value = engineHPArray[i - 1];
                        worksheet.Cells[2 + i, 6].Value = filteredEngineTorqueArray[i - 1];
                        worksheet.Cells[2 + i, 7].Value = filteredEngineHPArray[i - 1];
                        worksheet.Cells[2 + i, 8].Value = correctedEngineTorqueArray[i - 1];
                        worksheet.Cells[2 + i, 9].Value = correctedEngineHPArray[i - 1];
                    }
                }


                worksheet = package.Workbook.Worksheets.Add("CoastDown");

                worksheet.Cells[1, 1].Value = "Time [sec]";
                worksheet.Cells[1, 2].Value = "Roller RPM [rev/min]";

                for (int i = 0; i < coastDownTimeStampArray.Length; i++)
                {
                    worksheet.Cells[2 + i, 1].Value = coastDownTimeStampArray[i];
                    worksheet.Cells[2 + i, 2].Value = coastDownRollerRPMArray[i];
                }

                // Save the package to a file
                string filePath = excelFilePath;
                FileInfo file = new FileInfo(excelFilePath);
                package.SaveAs(file);

                Console.WriteLine("Excel file created successfully!");


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
                        worksheet = excel.Workbook.Worksheets[0]; // Accessing the first worksheet

                        // Modify cells in the worksheet

                        worksheet.Cells[10, 9].Value = filePathTextBox.Text;
                        worksheet.Cells[11, 9].Value = fileNameTextBox.Text;

                        // Save the modified Excel file
                        excel.Save();

                        Console.WriteLine("Excel file modified and saved successfully.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }


            }

            fileSaved = true;
        }

        private void saveVehicleData_Click(object sender, EventArgs e)
        {
            engineWheelRatio = double.Parse(engineToWheelRatioTextBox.Text);
            wheelRollerRatio = double.Parse(wheelToRollerRatioTextBox.Text);

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

                    // Modify cells in the worksheet
                    worksheet.Cells[4, 9].Value = double.Parse(engineToWheelRatioTextBox.Text);
                    worksheet.Cells[5, 9].Value = double.Parse(wheelToRollerRatioTextBox.Text);
                    worksheet.Cells[6, 9].Value = double.Parse(rollerMassTextBox.Text);
                    worksheet.Cells[7, 9].Value = double.Parse(rollerDiameterTextBox.Text);
                    worksheet.Cells[8, 9].Value = double.Parse(pullStartTextBox.Text);
                    worksheet.Cells[9, 9].Value = double.Parse(pullStopTextBox.Text);

                    // Save the modified Excel file
                    excel.Save();

                    Console.WriteLine("Excel file modified and saved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void rollerMassTextBox_Validated(object sender, EventArgs e)
        {
            rollerMass = double.Parse(rollerMassTextBox.Text);
        }

        private void rollerDiameterTextBox_Validated(object sender, EventArgs e)
        {
            rollerDiameter = double.Parse(rollerDiameterTextBox.Text);
        }

       

        private void pullStartTextBox_Validated(object sender, EventArgs e)
        {
            pullStart = double.Parse(pullStartTextBox.Text);
        }

        private void pullStopTextBox_Validated(object sender, EventArgs e)
        {
            pullStop = double.Parse(pullStopTextBox.Text);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (testStart)
            {
                currentRPMLabel.Text = Math.Round(currentEngineRPM,0).ToString() + " RPM";
            }
            else
            {
                currentRPMLabel.Text = "N/A RPM";
            }

            // Only proceed if the start button has been pressed
            if (startButtonPressed)
            {
                if (!testing)
                {
                    // Check if currentRPM falls 50 units below pullStart
                    if (currentEngineRPM <= pullStart - 500)                      //Change this to - 500
                    {
                        hasFallenBelowPullStart = true;
                    }

                    // Check if currentRPM exceeds pullStart after falling below it
                    if (hasFallenBelowPullStart && currentEngineRPM > pullStart)
                    {
                        // Start recording
                        testing = true;
                        hasFallenBelowPullStart = false; // Reset flag
                    }
                }
                else
                {
                    // Stop recording when currentRPM exceeds pullStop
                    if (currentEngineRPM >= pullStop)
                    {
                        // Stop recording
                        testing = false;
                        startButtonPressed = false;  // Stop further updates until the button is pressed again
                    }
                }
            }
        }

        void StartButtonPressed()
        {
            // Reset all necessary variables
            testing = false;
            startButtonPressed = true;
            hasFallenBelowPullStart = false;
            currentEngineRPM = 20000;
            // Reset any other variables related to your recording process here
        }

        private void applyBrakeButton_Click(object sender, EventArgs e)
        {
            if (applyBrakeButton.Text == "Apply Brake")
            {
                serialPort1.Write("applyBrakeOn");
                applyBrakeButton.Text = "Turn Off Brake";
            }
            else if (applyBrakeButton.Text =="Turn Off Brake")
            {
                serialPort1.Write("applyBrakeOff");
                applyBrakeButton.Text = "Apply Brake";
            }

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            var output = new calculateMetrics.Class1();

            double window_size = 21;
            double polynomial_order = 5;
            double engine_wheel_ratio = engineWheelRatio;
            double wheel_roller_ratio = wheelRollerRatio;
            double linear_equivalent_mass = rollerMass;
            double roller_radius = (double)(rollerDiameter/2);

            MWNumericArray mwTimeArray = new MWNumericArray(timeStampArray);
            MWNumericArray mwRollerRpmArray = new MWNumericArray(rollerRPMArray);
            MWNumericArray mwWindowSize = new MWNumericArray(window_size);
            MWNumericArray mwPolynomialOrder = new MWNumericArray(polynomial_order);
            MWNumericArray mwEngineWheelRatio = new MWNumericArray(engine_wheel_ratio);
            MWNumericArray mwWheelRollerRatio = new MWNumericArray(wheel_roller_ratio);
            MWNumericArray mwLinearEquivalentMass = new MWNumericArray(linear_equivalent_mass);
            MWNumericArray mwRollerRadius = new MWNumericArray(roller_radius);

            var results = output.calculateMetrics(5, mwTimeArray, mwRollerRpmArray, mwWindowSize, mwPolynomialOrder, mwEngineWheelRatio, mwWheelRollerRatio, mwLinearEquivalentMass, mwRollerRadius);

            engineHPArray = (double[])((MWNumericArray)results[0]).ToVector(MWArrayComponent.Real);
            engineTorqueArray = (double[])((MWNumericArray)results[1]).ToVector(MWArrayComponent.Real);
            engineRPMArray = (double[])((MWNumericArray)results[2]).ToVector(MWArrayComponent.Real);
            filteredEngineHPArray = (double[])((MWNumericArray)results[3]).ToVector(MWArrayComponent.Real);
            filteredEngineTorqueArray = (double[])((MWNumericArray)results[4]).ToVector(MWArrayComponent.Real);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.Series[0].Name = "HP";
            chart1.Series[1].Name = "Torque";

            chart1.ChartAreas[0].AxisX.Minimum = pullStart;  // Set X-axis minimum
            chart1.ChartAreas[0].AxisX.Maximum = pullStop; // Set X-axis maximum

            chart1.Series[0].Points.DataBindXY(engineRPMArray, filteredEngineHPArray);
            chart1.Series[1].Points.DataBindXY(engineRPMArray, filteredEngineTorqueArray);

            double maxTorque = filteredEngineTorqueArray.Max();
            int maxTorqueRPMIndex = Array.IndexOf(filteredEngineTorqueArray, maxTorque);
            double maxTorqueRPM = engineRPMArray[maxTorqueRPMIndex];

            double maxHP = filteredEngineHPArray.Max();
            int maxHPRPMIndex = Array.IndexOf(filteredEngineHPArray, maxHP);
            double maxHPRPM = engineRPMArray[maxHPRPMIndex];

            string maxTorqueLabel = ("Max Torque: " + Math.Round(maxTorque, 1).ToString() + " ft*lb @ " + Math.Round(maxTorqueRPM, 0).ToString() + " RPM");
            string maxHPLabel = (" | Max HP: " + Math.Round(maxHP, 1).ToString() + " HP @ " + Math.Round(maxHPRPM, 0).ToString() + " RPM");

            double timeOfTest = timeStampArray.Last();
            string testTime = (" | Length of Test: " + Math.Round(timeOfTest, 2) + " sec");
            dynoDataLabel.Text = (maxTorqueLabel + maxHPLabel + testTime);

        }

        private void addLossesButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.Series[0].Name = "Corrected HP";
            chart1.Series[1].Name = "Corrected Torque";

            correctedEngineHPArray = new double[engineRPMArray.Length];
            correctedEngineTorqueArray = new double[engineRPMArray.Length];

            for (int i = 0; i < engineHPArray.Length; i++)
            {
                correctedEngineTorqueArray[i] = filteredEngineTorqueArray[i] - torqueCoef[0] * Math.Pow(engineRPMArray[i], 2) - torqueCoef[1] * engineRPMArray[i] - torqueCoef[2];
                correctedEngineHPArray[i] = filteredEngineHPArray[i] - HPCoef[0] * Math.Pow(engineRPMArray[i], 2) - HPCoef[1] * engineRPMArray[i] - HPCoef[2];
            }

            chart1.Series[0].Points.DataBindXY(engineRPMArray, correctedEngineHPArray);
            chart1.Series[1].Points.DataBindXY(engineRPMArray, correctedEngineTorqueArray);

            double maxTorque = correctedEngineTorqueArray.Max();
            int maxTorqueRPMIndex = Array.IndexOf(correctedEngineTorqueArray, maxTorque);
            double maxTorqueRPM = engineRPMArray[maxTorqueRPMIndex];

            double maxHP = correctedEngineHPArray.Max();
            int maxHPRPMIndex = Array.IndexOf(correctedEngineHPArray, maxHP);
            double maxHPRPM = engineRPMArray[maxHPRPMIndex];

            string maxTorqueLabel = ("Max Torque: " + Math.Round(maxTorque, 1).ToString() + " ft*lb @ " + Math.Round(maxTorqueRPM, 0).ToString() + " RPM");
            string maxHPLabel = (" | Max HP: " + Math.Round(maxHP, 1).ToString() + " HP @ " + Math.Round(maxHPRPM, 0).ToString() + " RPM");

            double timeOfTest = timeStampArray.Last();
            string testTime = (" | Length of Test: " + Math.Round(timeOfTest, 2) + " sec");
            dynoDataLabel.Text = (maxTorqueLabel + maxHPLabel + testTime);
        }
    }
}
