using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using System.IO.Ports;
using System.Windows.Media.Media3D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using OfficeOpenXml; // Add this namespace after installing EPPlus
using System.Threading;

namespace DynoCalibration
{
    public partial class Form1 : Form
    {
        private string serial;

        private string excelFilePath;

        private double zeroWeightCal;

        private double someWeightCal;

        private double calWeight;

        private double slope;

        private double yIntercept;

        private double W;

        private bool dynoRPMcalibrationTest;

        private bool measureTest;

        private bool PAUTest;

        private bool emergencyPAUTest;

        private double kPMin;
        private double kP;
        private double kPMax;

        private double kIMin;
        private double kI;
        private double kIMax;

        private double kDMin;
        private double kD;
        private double kDMax;

        private double emergencyPAUVoltage;

        private double a0;
        private double a1;
        private double a2;
        private double b0;
        private double b1;
        private double b2;
        private double N;
        private double Ts;


        public Form1()
        {
            InitializeComponent();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            excelFilePath = "C:\\Users\\anton\\source\\repos\\DynoCalibration\\dynoConfig.xlsx";

            serial = "N/A";

            dynoRPMcalibrationTest = false;

            measureTest = false;

            PAUTest = false;

            emergencyPAUTest = false;

            serialPort1.Open();

            Ts = 0.05;
            N = 1;

            

            //Load Saved Data

            //Strain Gauge Calibration
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
                    // Get the first worksheet in the workbook (or you can get a specific one)
                    var worksheet = excel.Workbook.Worksheets[0]; // Accessing the first worksheet

                    // Get cell Data
                    zeroWeightCal = (double)worksheet.Cells[4, 2].Value;
                    someWeightCal = (double)worksheet.Cells[5, 2].Value;
                    calWeight = (double)worksheet.Cells[6, 2].Value;
                    slope = (double)worksheet.Cells[7, 2].Value;
                    yIntercept = (double)worksheet.Cells[8, 2].Value;

                    kPMin = (double)worksheet.Cells[5, 6].Value;
                    kP = (double)worksheet.Cells[6, 6].Value;
                    kPMax = (double)worksheet.Cells[7, 6].Value;

                    kIMin = (double)worksheet.Cells[8, 6].Value;
                    kI = (double)worksheet.Cells[9, 6].Value;
                    kIMax = (double)worksheet.Cells[10, 6].Value;

                    kDMin = (double)worksheet.Cells[11, 6].Value;
                    kD = (double)worksheet.Cells[12, 6].Value;
                    kDMax = (double)worksheet.Cells[13, 6].Value;

                    emergencyPAUVoltage = (double)worksheet.Cells[4, 6].Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //Loading Excel Data
            calWeightTextBox.Text = calWeight.ToString("0.0");


           

            //emergencyVoltageValueTextBox.Text = emergencyPAUVoltage.ToString("0.00");
            emergencyPAUVoltageTrackBar.Value = (int)(emergencyPAUVoltage*100);

        }

        private void rawStrainValueButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("single_strain_value");
            serial = serialPort1.ReadLine();
            rawStrainValue.Text = serial;
        }

        private void zeroWeightButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("single_strain_value");
            serial = serialPort1.ReadLine();
            if (serial.StartsWith("w"))
            {
                serial = serial.Substring(1);
                zeroWeightTestLabel.Text = serial;
                zeroWeightCal = double.Parse(serial);
            }
        }

        private void calWeightTextBox_Validated(object sender, EventArgs e)
        {
            calWeight = double.Parse(calWeightTextBox.Text);
        }

        private void someWeightCalibrationButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("single_strain_value");
            serial = serialPort1.ReadLine();
            if (serial.StartsWith("w"))
            {
                serial = serial.Substring(1);
                someWeightTestLabel.Text = serial;
                someWeightCal = double.Parse(serial);
            }
        }

        private void calculateCalibrationEquationButton_Click(object sender, EventArgs e)
        {
            if (someWeightCal != zeroWeightCal)
            {
                slope = calWeight / (someWeightCal - zeroWeightCal);
                yIntercept = -slope * zeroWeightCal;
            }
            else
            {
                MessageBox.Show("Calibration failed: Zero weight and some weight are the same.");
            }
            calibrationEquationTest.Text = ("y=" + slope.ToString() + "x+" + yIntercept.ToString());

        }

        private void testWeightButton_Click(object sender, EventArgs e)
        {
            if (testWeightButton.Text == "Start Measure")
            {
                serialPort1.Write("strain_measure_start");
                testWeightButton.Text = "Stop Measure";
                serial = serialPort1.ReadLine();
                if (serial.StartsWith("w"))
                {
                    serial = serial.Substring(1);
                    W = slope * double.Parse(serial) + yIntercept;
                    weightLabel.Text = W.ToString();
                    measureTest = true;
                }
            }
            else if (testWeightButton.Text == "Stop Measure")
            {
                serialPort1.Write("strain_measure_stop");
                testWeightButton.Text = "Start Measure";
                weightLabel.Text = "Weight: N/A lbs";
                measureTest = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (dynoRPMcalibrationTest)
            {
                serial = serialPort1.ReadLine();
                if (serial.StartsWith("w"))
                {
                    serial = serial.Substring(1);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        RPMLabel.Text = $"{(serial + " RPM")}";
                    }));
                }
            }
            else if (measureTest)
            {
                serial = serialPort1.ReadLine();
                if (serial.StartsWith("w"))
                {
                    serial = serial.Substring(1);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        W = slope * double.Parse(serial) + yIntercept;
                        weightLabel.Text = $"{("Weight: " + W + " lbs")}";
                    }));
                }
            }
            
            else if (emergencyPAUTest)
            {
                serial = serialPort1.ReadLine();
                if (serial.StartsWith("w"))
                {
                    serial = serial.Substring(1);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        PAUValueLabel.Text = (serial);
                    }));
                    }
            }
        }

        private void dynoCalibrationStartStopButton_Click(object sender, EventArgs e)
        {
            if (dynoCalibrationStartStopButton.Text == "Start")
            {
                dynoCalibrationStartStopButton.Text = "Stop";
                serialPort1.Write("tach_test_start");
                dynoRPMcalibrationTest = true;
            }
            else if (dynoCalibrationStartStopButton.Text == "Stop")
            {
                dynoCalibrationStartStopButton.Text = "Start";
                serialPort1.Write("tach_test_stop");
                RPMLabel.Text = "N/A RPM";
                dynoRPMcalibrationTest = false;
            }
        }

        
        private void saveStrainCalibrationButton_Click(object sender, EventArgs e)
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
                    // Get the first worksheet in the workbook (or you can get a specific one)
                    var worksheet = excel.Workbook.Worksheets[0]; // Accessing the first worksheet

                    // Modify cells in the worksheet
                    worksheet.Cells[4, 2].Value = zeroWeightCal;
                    worksheet.Cells[5, 2].Value = someWeightCal;
                    worksheet.Cells[6, 2].Value = calWeight;
                    worksheet.Cells[7, 2].Value = slope;
                    worksheet.Cells[8, 2].Value = yIntercept;

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

        private void closeButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("DynoStop");
            serialPort1.Write("MeasureStop");
            Environment.Exit(0);
        }


        private void emergencyPAUVoltageTrackBar_Scroll(object sender, EventArgs e)
        {
            double scaledValue = (double)emergencyPAUVoltageTrackBar.Value;
            PAUValueLabel.Text = scaledValue.ToString();
            serialPort1.Write("ePAU" + scaledValue);
        }


        private void startPAUVoltageTestButton_Click(object sender, EventArgs e)
        {
            if (startPAUVoltageTestButton.Text == "Start PAU\r\nVoltage Test")
            {
                serialPort1.Write("pau_voltage_test_start");
                startPAUVoltageTestButton.Text = "Stop PAU\r\nVoltage Test";
                emergencyPAUTest = true;
            }
            else if (startPAUVoltageTestButton.Text == "Stop PAU\r\nVoltage Test")
            {
                serialPort1.Write("pau_voltage_test_stop");
                startPAUVoltageTestButton.Text = "Start PAU\r\nVoltage Test";
                emergencyPAUTest = false;
            }

        }

        private void sendGain_Click(object sender, EventArgs e)
        {
            b0 = kP * (1 + N * Ts) + kI * Ts * (1 + N * Ts) + kD * N;
            b1 = -(kP * (2 + N * Ts) + kI * Ts + 2 * kD * N);
            b2 = kP + kD * N;


            a0 = 1 + N * Ts;
            a1 = -(2 + N * Ts);
            a2 = 1;

            string formattedMessage = string.Format("rkPID{0:0.000} {1:0.000} {2:0.000} {3:0.000} {4:0.000} {5:0.000}",
                                             a0, a1, a2, b0, b1, b2);

            serialPort1.Write("rkPID" + a0.ToString("0.000") + " " + a1.ToString("0.000") + " " + a2.ToString("0.000") + " " + " " + b0.ToString("0.000") + " " + " " + b1.ToString("0.000") + " " + " " + b2.ToString("0.000"));
        }
    }
}
