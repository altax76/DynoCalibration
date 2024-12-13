using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Animation;
using MathWorks.MATLAB.NET.Arrays;

using calculateCoastDownCoef;

namespace DynoCalibration
{
    public partial class Form6 : Form
    {

        private string configFilePath;

        private double engineWheelRatio;
        private double wheelRollerRatio;
        private double rollerMass;
        private double rollerDiameter;
        private double coastDownStart;
        private double coastDownStop;

        private string runFilePath;
        private string runFileName;

        private bool testStart = false;

        double currentRollerRPM;
        int currentEngineRPM;

        private bool testing = false;
        private bool startButtonPressed = false;
        private bool hasFallenAbovePullStart = false;

        private double initialTimestamp = -1;

        List<double> rollerRPMList = new List<double>();                    //rev/min
        List<double> timeList = new List<double>();

        double[] rollerRPMArray;
        double[] timeStampArray;

        public Form6()
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
                    rollerDiameter = (double)worksheet.Cells[7, 9].Value;
                    coastDownStart = (double)worksheet.Cells[4, 12].Value;
                    coastDownStop = (double)worksheet.Cells[5, 12].Value;


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
            coastDownStartTextBox.Text = coastDownStart.ToString("0");
            coastDownStopTextBox.Text = coastDownStop.ToString("0");
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
                    worksheet.Cells[4, 12].Value = double.Parse(coastDownStartTextBox.Text);
                    worksheet.Cells[5, 12].Value = double.Parse(coastDownStopTextBox.Text);

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
                        currentEngineRPM = (int)((double)currentRollerRPM * engineWheelRatio / wheelRollerRatio);

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

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                serialPort1.Write("rpm_start");
                testStart = true;
                startButton.Text = "Stop";
                StartButtonPressed();
            }
            else if (startButton.Text == "Stop")
            {
                serialPort1.Write("rpm_stop");
                testStart = false;
                startButton.Text = "Start";
            }
        }

        void StartButtonPressed()
        {
            // Reset all necessary variables
            testing = false;
            startButtonPressed = true;
            hasFallenAbovePullStart = false;
            currentEngineRPM = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (testStart)
            {
                currentRPMLabel.Text = currentEngineRPM.ToString() + " RPM";
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
                    // Check if currentRPM falls 100 units below pullStart
                    if (currentEngineRPM >= coastDownStart + 100)
                    {
                        hasFallenAbovePullStart = true;
                    }

                    // Check if currentRPM exceeds pullStart after falling below it
                    if (hasFallenAbovePullStart && currentEngineRPM < coastDownStart)
                    {
                        // Start recording
                        testing = true;
                        hasFallenAbovePullStart = false; // Reset flag
                    }
                }
                else
                {
                    // Stop recording when currentRPM exceeds pullStop
                    if (currentEngineRPM <= coastDownStop)
                    {
                        // Stop recording
                        testing = false;
                        startButtonPressed = false;  // Stop further updates until the button is pressed again
                    }
                }
            }
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
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
                    var worksheet = excel.Workbook.Worksheets[1]; // Accessing the second worksheet


                    worksheet.Cells.Clear();

                    // Modify cells in the worksheet

                    worksheet.Cells[1, 1].Value = "Time [sec]";
                    worksheet.Cells[1, 2].Value = "Roller RPM [rev/min]";


                    double[] rollerRPMArray = rollerRPMList.ToArray();
                    double[] timeStampArray = timeList.ToArray();


                    for (int i = 0; i < rollerRPMArray.Length; i++)
                    {
                        worksheet.Cells[2 + i, 1].Value = timeStampArray[i];
                        worksheet.Cells[2 + i, 2].Value = rollerRPMArray[i];
                    }

                    // Save the modified Excel file
                    excel.Save();

                    Console.WriteLine("Excel file modified and saved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            var output = new calculateCoastDownCoef.Class1();

            double engine_wheel_ratio = engineWheelRatio;
            double wheel_roller_ratio = wheelRollerRatio;
            double linear_equivalent_mass = rollerMass;
            double roller_radius = (double)(rollerDiameter / 2);

            MWNumericArray mwTimeArray = new MWNumericArray(timeStampArray);
            MWNumericArray mwRollerRpmArray = new MWNumericArray(rollerRPMArray);
            MWNumericArray mwEngineWheelRatio = new MWNumericArray(engine_wheel_ratio);
            MWNumericArray mwWheelRollerRatio = new MWNumericArray(wheel_roller_ratio);
            MWNumericArray mwLinearEquivalentMass = new MWNumericArray(linear_equivalent_mass);
            MWNumericArray mwRollerRadius = new MWNumericArray(roller_radius);

            var results = output.calculateCoastDownCoef(2, mwTimeArray, mwRollerRpmArray, mwEngineWheelRatio, mwWheelRollerRatio, mwLinearEquivalentMass, mwRollerRadius);

            double[] TorqueCoefs = (double[])((MWNumericArray)results[0]).ToVector(MWArrayComponent.Real);
            double[] HPCoefs = (double[])((MWNumericArray)results[1]).ToVector(MWArrayComponent.Real);

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
                    var worksheet = excel.Workbook.Worksheets[0]; // Accessing the second worksheet

                    // Modify cells in the worksheet

                    worksheet.Cells[6, 12].Value = TorqueCoefs[0];
                    worksheet.Cells[7, 12].Value = TorqueCoefs[1];
                    worksheet.Cells[8, 12].Value = TorqueCoefs[2];

                    worksheet.Cells[9, 12].Value = HPCoefs[0];
                    worksheet.Cells[10, 12].Value = HPCoefs[1];
                    worksheet.Cells[11, 12].Value = HPCoefs[2];

                    // Save the modified Excel file
                    excel.Save();

                    Console.WriteLine("Excel file modified and saved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            double[] engineRPMArray = new double[rollerRPMArray.Length];
            double[] lostTorqueArray = new double[rollerRPMArray.Length];
            double[] lostHPArray = new double[rollerRPMArray.Length];


            for (int i = 0; i < rollerRPMArray.Length; i++)
            {
                double engineRPM = rollerRPMArray[i] * engineWheelRatio / wheelRollerRatio;
                engineRPMArray[i] = engineRPM;
                lostTorqueArray[i] = Math.Pow(engineRPM,2)*TorqueCoefs[0]+engineRPM*TorqueCoefs[1]+TorqueCoefs[2];
                lostHPArray[i] = Math.Pow(engineRPM, 2) * HPCoefs[0] + engineRPM * HPCoefs[1] + HPCoefs[2];
            }

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            chart1.Series[0].Name = "Torque Losses";
            chart1.Series[1].Name = "HP Losses";

            chart1.Series[0].Points.DataBindXY(engineRPMArray, lostTorqueArray);
            chart1.Series[1].Points.DataBindXY(engineRPMArray, lostHPArray);

        }

        private void coastDownStartTextBox_Validated(object sender, EventArgs e)
        {
            coastDownStart = double.Parse(coastDownStartTextBox.Text);
        }

        private void pullStopTextBox_Validated(object sender, EventArgs e)
        {
            coastDownStop = double.Parse(coastDownStopTextBox.Text);
        }
    }
}
