using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Animation;
using static OfficeOpenXml.ExcelErrorValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DynoCalibration
{


    public partial class Form4 : Form
    {
        private string serial;

        private string excelFilePath;
        private string configFilePath;

        private string runFilePath;
        private string runFileName;

        private int targetRPM;

        private bool pauTestState = false;

        private bool gainSent = false;
        private bool targetRPMSent = false;

        private double dataSetOneScale = 1;
        private double dataSetTwoScale = 1;
        private double dataSetThreeScale = 1;

        private double strainOffset;
        private double strainSlope;

        private double kPMin;
        private double kP;
        private double kPMax;

        private double kIMin;
        private double kI;
        private double kIMax;

        private double kDMin;
        private double kD;
        private double kDMax;

        private double engineWheelRatio;
        private double wheelRollerRatio;

        private double a0;
        private double a1;
        private double a2;
        private double b0;
        private double b1;
        private double b2;
        private double N;
        private double Ts;

        List<double> timeList = new List<double>();
        List<int> rpmList = new List<int>();
        List<double> torqueList = new List<double>();
        List<int> filteredOutputList = new List<int>();
        List<int> unfilteredOutputList = new List<int>();
        List<double> pGainList = new List<double>();
        List<double> iGainList = new List<double>();
        List<double> dGainList = new List<double>();
        List<int> targetRPMList = new List<int>();
        List<double> throttlePositionList = new List<double>();
        List<int> motecRPMList = new List<int>();

        private double[] timeArray = { 1, 2, 3, 4, 5 };

        private int[] RPMArray = { 200, 4000, 5000, 6000, 6000 };
        private double[] torqueArray = { 50, 50, 40, 50, 40 };
        private int[] filteredOutputArray = { 1, 40, 50, 70, 70 };
        private int[] unfilteredOutputArray = { 1000, 4000, 5000, 2000, 2500 };

        private double[] pGainArray = { 2, 2, 2, 2, 2 };
        private double[] iGainArray = { 2, 2, 2, 2, 2 };
        private double[] dGainArray = { 2, 2, 2, 2, 2 };

        private int[] targetRPMArray = {1000, 1000, 1000, 1000, 1000};
        private double[] throttlePositionArray = { 0, 0, 0, 0, 0 };
        private int[] motecRPMArray = { 0, 0, 0, 0, 0 };

        private double slope = 0;
        private double intercept = 0;

        public Form4()
        {
            InitializeComponent();

            excelFilePath = "C:\\Users\\anton\\source\\repos\\DynoCalibration\\dynoConfig.xlsx";
            serialPort1.Open();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            configFilePath = "C:\\Users\\anton\\source\\repos\\DynoCalibration\\dynoConfig.xlsx";
            Ts = 0.01;
            N = 1;

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

                    runFilePath = (string)worksheet.Cells[10, 9].Value;
                    runFileName = (string)worksheet.Cells[11, 9].Value;

                    kPMin = (double)worksheet.Cells[5, 6].Value;
                    kP = (double)worksheet.Cells[6, 6].Value;
                    kPMax = (double)worksheet.Cells[7, 6].Value;

                    kIMin = (double)worksheet.Cells[8, 6].Value;
                    kI = (double)worksheet.Cells[9, 6].Value;
                    kIMax = (double)worksheet.Cells[10, 6].Value;

                    kDMin = (double)worksheet.Cells[11, 6].Value;
                    kD = (double)worksheet.Cells[12, 6].Value;
                    kDMax = (double)worksheet.Cells[13, 6].Value;

                    dataSetOneComboBox.SelectedItem = (string)worksheet.Cells[15, 6].Value;
                    dataSetOneScaleTextBox.Text = ((double)worksheet.Cells[16,6].Value).ToString();
                    dataSetOneScale = double.Parse(dataSetOneScaleTextBox.Text);
                    dataSetTwoComboBox.SelectedItem = (string)worksheet.Cells[17, 6].Value;
                    dataSetTwoScaleTextBox.Text = ((double)worksheet.Cells[18, 6].Value).ToString();
                    dataSetTwoScale = double.Parse(dataSetTwoScaleTextBox.Text);
                    dataSetThreeComboBox.SelectedItem = (string)worksheet.Cells[19, 6].Value;
                    dataSetThreeScaleTextBox.Text = ((double)worksheet.Cells[20, 6].Value).ToString();
                    dataSetThreeScale = double.Parse(dataSetThreeScaleTextBox.Text);

                    targetRPMTextBox.Text = ((double)worksheet.Cells[22,6].Value).ToString();

                    strainOffset = (double)worksheet.Cells[8, 2].Value;
                    strainSlope = (double)worksheet.Cells[7, 2].Value;

                    engineWheelRatio = (double)worksheet.Cells[4, 9].Value;
                    wheelRollerRatio = (double)worksheet.Cells[5, 9].Value;

            



                }

                serialPort1.Write("strainCal" + strainSlope.ToString("0.00000000000000") + " " + strainOffset.ToString("0.00000000000000"));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //Loading Excel Data
            filePathTextBox.Text = runFilePath;
            fileNameTextBox.Text = runFileName;

            kPMinTextBox.Text = kPMin.ToString("0.00");
            kPTrackBar.Minimum = (int)(kPMin * 100);
            kPValueTextBox.Text = kP.ToString("0.00");
            kPMaxTextBox.Text = kPMax.ToString("0.00");
            kPTrackBar.Maximum = (int)(kPMax * 100);
            kPTrackBar.Value = (int)(kP * 100);

            kIMinTextBox.Text = kIMin.ToString("0.00");
            kITrackBar.Minimum = (int)(kIMin * 100);
            kIValueTextBox.Text = kI.ToString("0.00");
            kIMaxTextBox.Text = kIMax.ToString("0.00");
            kITrackBar.Maximum = (int)(kIMax * 100);
            kITrackBar.Value = (int)(kI * 100);

            kDMinTextBox.Text = kDMin.ToString("0.00");
            kDTrackBar.Minimum = (int)(kDMin * 100);
            kDValueTextBox.Text = kD.ToString("0.00");
            kDMaxTextBox.Text = kDMax.ToString("0.00");
            kDTrackBar.Maximum = (int)(kDMax * 100);
            kDTrackBar.Value = (int)(kD * 100);
        }

        private double initialTimestamp = -1;

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            if (pauTestState)
            {
                string serial = serialPort1.ReadLine();
                
                this.Invoke(new MethodInvoker(delegate
                {
                    SerialMonitorOutputLabel.Text = serial;
                }));

                if (serial.StartsWith("s"))
                {
                    serial = serial.Substring(1);
                    string[] parts = serial.Split(' ');

                    if (parts.Length == 8)
                    {
                        double timestamp = double.Parse(parts[0]);
                        int rpm = (int)(double.Parse(parts[1]) * engineWheelRatio / wheelRollerRatio);
                        double torque = double.Parse(parts[2]);
                        int unfilteredOutput = int.Parse(parts[3]);
                        int filteredOutput = int.Parse(parts[4]);
                        int targetRPMRequest = int.Parse(parts[5]);
                        double TPS = double.Parse(parts[6]);
                        int motecEngineRPM = int.Parse(parts[7]);




                        this.Invoke(new MethodInvoker(delegate
                        {
                            if (initialTimestamp < 0)
                            {
                                initialTimestamp = timestamp;
                            }

                            double offsetTimestamp = timestamp - initialTimestamp;

                            currentRPMLabel.Text = rpm.ToString();
                            currentTorqueLabel.Text = Math.Round((torque*strainSlope+strainOffset),1).ToString();
                            currentPIDOutputLabel.Text = filteredOutput.ToString();
                            engineRPMFromMotecLabel.Text = ("Motec RPM: " + motecEngineRPM.ToString());
                            TPSLabel.Text = TPS.ToString();

                            label3.Text = ((int)(targetRPMRequest * engineWheelRatio / wheelRollerRatio)).ToString();

                            if (timeList.Count > 150)
                            {
                                timeList.RemoveAt(0);
                                rpmList.RemoveAt(0);
                                torqueList.RemoveAt(0);
                                filteredOutputList.RemoveAt(0);
                                unfilteredOutputList.RemoveAt(0);
                                pGainList.RemoveAt(0);
                                iGainList.RemoveAt(0);
                                dGainList.RemoveAt(0);
                                targetRPMList.RemoveAt(0);
                                throttlePositionList.RemoveAt(0);
                                motecRPMList.RemoveAt(0);



                                timeList.Add(offsetTimestamp);
                                rpmList.Add(rpm);
                                torqueList.Add(torque * strainSlope + strainOffset);
                                filteredOutputList.Add(filteredOutput);
                                unfilteredOutputList.Add(unfilteredOutput);
                                pGainList.Add(kP);
                                iGainList.Add(kI);
                                dGainList.Add(kD);
                                targetRPMList.Add(targetRPM);
                                throttlePositionList.Add(TPS);
                                motecRPMList.Add(motecEngineRPM);

                            } else
                            {
                                timeList.Add(offsetTimestamp);
                                rpmList.Add(rpm);
                                torqueList.Add(torque * strainSlope + strainOffset);
                                filteredOutputList.Add(filteredOutput);
                                unfilteredOutputList.Add(unfilteredOutput);
                                pGainList.Add(kP);
                                iGainList.Add(kI);
                                dGainList.Add(kD);
                                targetRPMList.Add(targetRPM);
                                throttlePositionList.Add(TPS);
                                motecRPMList.Add(motecEngineRPM);
                            }

                            UpdateChart();
                            }));
                        
                    }
                }
            }
        }
    

        private void UpdateChart()
        {
            double[] scaledArrayOne;
            double[] scaledArrayTwo;
            double[] scaledArrayThree;

            PIDChart.Series[0].Points.Clear();
            PIDChart.Series[1].Points.Clear();
            PIDChart.Series[2].Points.Clear();

            timeArray = timeList.ToArray();
            RPMArray = rpmList.ToArray();
            torqueArray = torqueList.ToArray();
            filteredOutputArray = filteredOutputList.ToArray();
            unfilteredOutputArray = unfilteredOutputList.ToArray();
            targetRPMArray = targetRPMList.ToArray();
            throttlePositionArray = throttlePositionList.ToArray();
            motecRPMArray = motecRPMList.ToArray();

            switch (dataSetOneComboBox.SelectedItem.ToString())
            {
                case "None":
                    PIDChart.Series[0].Enabled = false;
                    break;

                case "RPM":
                    PIDChart.Series[0].Enabled = true;
                    scaledArrayOne = RPMArray.Select(x => x * dataSetOneScale).ToArray();
                    PIDChart.Series[0].Points.DataBindXY(timeArray, scaledArrayOne);
                    break;

                case "Torque":
                    PIDChart.Series[0].Enabled = true;
                    scaledArrayOne = torqueArray.Select(x => x * dataSetOneScale).ToArray();
                    PIDChart.Series[0].Points.DataBindXY(timeArray, scaledArrayOne);
                    break;

                case "Filtered Output":
                    PIDChart.Series[0].Enabled = true;
                    scaledArrayOne = filteredOutputArray.Select(x => x * dataSetOneScale).ToArray();
                    PIDChart.Series[0].Points.DataBindXY(timeArray, scaledArrayOne);
                    break;

                case "Unfiltered Output":
                    PIDChart.Series[0].Enabled = true;
                    scaledArrayOne = unfilteredOutputArray.Select(x => x * dataSetOneScale).ToArray();
                    PIDChart.Series[0].Points.DataBindXY(timeArray, scaledArrayOne);
                    break;
                case "Throttle Position":
                    PIDChart.Series[0].Enabled = true;
                    scaledArrayOne = throttlePositionArray.Select(x => x * dataSetOneScale).ToArray();
                    PIDChart.Series[0].Points.DataBindXY(timeArray, scaledArrayOne);
                    break;
                case "Motec RPM":
                    PIDChart.Series[0].Enabled = true;
                    scaledArrayOne = motecRPMArray.Select(x => x * dataSetOneScale).ToArray();
                    PIDChart.Series[0].Points.DataBindXY(timeArray, scaledArrayOne);
                    break;
                default:
                    PIDChart.Series[0].Enabled = false;
                    break;
            }

            switch (dataSetTwoComboBox.SelectedItem.ToString())
            {
                case "None":
                    PIDChart.Series[1].Enabled = false;
                    break;

                case "RPM":
                    PIDChart.Series[1].Enabled = true;
                    scaledArrayTwo = RPMArray.Select(x => x * dataSetTwoScale).ToArray();
                    PIDChart.Series[1].Points.DataBindXY(timeArray, scaledArrayTwo);
                    break;

                case "Torque":
                    PIDChart.Series[1].Enabled = true;
                    scaledArrayTwo = torqueArray.Select(x => x * dataSetTwoScale).ToArray();
                    PIDChart.Series[1].Points.DataBindXY(timeArray, scaledArrayTwo);
                    break;

                case "Filtered Output":
                    PIDChart.Series[1].Enabled = true;
                    scaledArrayTwo = filteredOutputArray.Select(x => x * dataSetTwoScale).ToArray();
                    PIDChart.Series[1].Points.DataBindXY(timeArray, scaledArrayTwo);
                    break;

                case "Unfiltered Output":
                    PIDChart.Series[1].Enabled = true;
                    scaledArrayTwo = unfilteredOutputArray.Select(x => x * dataSetTwoScale).ToArray();
                    PIDChart.Series[1].Points.DataBindXY(timeArray, scaledArrayTwo);
                    break;
                case "Throttle Position":
                    PIDChart.Series[1].Enabled = true;
                    scaledArrayTwo = throttlePositionArray.Select(x => x * dataSetTwoScale).ToArray();
                    PIDChart.Series[1].Points.DataBindXY(timeArray, scaledArrayTwo);
                    break;
                case "Motec RPM":
                    PIDChart.Series[1].Enabled = true;
                    scaledArrayTwo = motecRPMArray.Select(x => x * dataSetTwoScale).ToArray();
                    PIDChart.Series[1].Points.DataBindXY(timeArray, scaledArrayTwo);
                    break;
                default:
                    PIDChart.Series[1].Enabled = false;
                    break;
            }

            switch (dataSetThreeComboBox.SelectedItem.ToString())
            {
                case "None":
                    PIDChart.Series[2].Enabled = false;
                    break;

                case "RPM":
                    PIDChart.Series[2].Enabled = true;
                    scaledArrayThree = RPMArray.Select(x => x * dataSetThreeScale).ToArray();
                    PIDChart.Series[2].Points.DataBindXY(timeArray, scaledArrayThree);
                    break;

                case "Torque":
                    PIDChart.Series[2].Enabled = true;
                    scaledArrayThree = torqueArray.Select(x => x * dataSetThreeScale).ToArray();
                    PIDChart.Series[2].Points.DataBindXY(timeArray, scaledArrayThree);
                    break;

                case "Filtered Output":
                    PIDChart.Series[2].Enabled = true;
                    scaledArrayThree = filteredOutputArray.Select(x => x * dataSetThreeScale).ToArray();
                    PIDChart.Series[2].Points.DataBindXY(timeArray, scaledArrayThree);
                    break;

                case "Unfiltered Output":
                    PIDChart.Series[2].Enabled = true;
                    scaledArrayThree = unfilteredOutputArray.Select(x => x * dataSetThreeScale).ToArray();
                    PIDChart.Series[2].Points.DataBindXY(timeArray, scaledArrayThree);
                    break;

                case "Throttle Position":
                    PIDChart.Series[2].Enabled = true;
                    scaledArrayThree = throttlePositionArray.Select(x => x * dataSetThreeScale).ToArray();
                    PIDChart.Series[2].Points.DataBindXY(timeArray, scaledArrayThree);
                    break;

                case "Motec RPM":
                    PIDChart.Series[2].Enabled = true;
                    scaledArrayThree = motecRPMArray.Select(x => x * dataSetThreeScale).ToArray();
                    PIDChart.Series[2].Points.DataBindXY(timeArray, scaledArrayThree);
                    break;
                default:
                    PIDChart.Series[2].Enabled = false;
                    break;
            }


        }

        private void dataSetOneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void dataSetTwoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void dataSetThreeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void fileSaveButton_Click(object sender, EventArgs e)
        {
            excelFilePath = filePathTextBox.Text + "\\" + fileNameTextBox.Text + ".xlsx";

            using (ExcelPackage package = new ExcelPackage())

            {
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Write some data to the worksheet
                worksheet.Cells[1, 1].Value = "Time [sec]";
                worksheet.Cells[1, 2].Value = "RPM [rev/min]";
                worksheet.Cells[1, 3].Value = "Torque [ft lb]";
                worksheet.Cells[1, 4].Value = "Filtered Output [8 bit]";
                worksheet.Cells[1, 5].Value = "Unfilterd Output [8 bit]";
                worksheet.Cells[1, 6].Value = "P Gain";
                worksheet.Cells[1, 7].Value = "I Gain";
                worksheet.Cells[1, 8].Value = "D Gain";
                worksheet.Cells[1, 9].Value = "Target RPM";


                timeArray = timeList.ToArray();
                RPMArray = rpmList.ToArray();
                torqueArray = torqueList.ToArray();
                filteredOutputArray = filteredOutputList.ToArray();
                unfilteredOutputArray = unfilteredOutputList.ToArray();
                pGainArray = pGainList.ToArray();
                iGainArray = iGainList.ToArray();
                dGainArray = dGainList.ToArray();
                targetRPMArray = targetRPMList.ToArray();
                throttlePositionArray = throttlePositionList.ToArray();


                for (int i = 0; i < timeArray.Length; i++)
                {
                    worksheet.Cells[2 + i, 1].Value = timeArray[i];
                    worksheet.Cells[2 + i, 2].Value = RPMArray[i];
                    worksheet.Cells[2 + i, 3].Value = torqueArray[i];
                    worksheet.Cells[2 + i, 4].Value = filteredOutputArray[i];
                    worksheet.Cells[2 + i, 5].Value = unfilteredOutputArray[i];
                    worksheet.Cells[2 + i, 6].Value = pGainArray[i];
                    worksheet.Cells[2 + i, 7].Value = iGainArray[i];
                    worksheet.Cells[2 + i, 8].Value = dGainArray[i];
                    worksheet.Cells[2 + i, 9].Value = targetRPMArray[i];
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
        }

        private void dataSetOneScaleTextBox_Validated(object sender, EventArgs e)
        {
            // Check if the TextBox is empty or only contains white spaces
            if (string.IsNullOrWhiteSpace(dataSetOneScaleTextBox.Text))
            {
                // Set default value of 1
                dataSetOneScaleTextBox.Text = dataSetOneScale.ToString();
            }

            // Parse the value to a double
            dataSetOneScale = double.Parse(dataSetOneScaleTextBox.Text);
            UpdateChart();
        }

        private void dataSetTwoScaleTextBox_Validated(object sender, EventArgs e)
        {
            // Check if the TextBox is empty or only contains white spaces
            if (string.IsNullOrWhiteSpace(dataSetTwoScaleTextBox.Text))
            {
                // Set default value of 1
                dataSetTwoScaleTextBox.Text = "1";
            }

            // Parse the value to a double
            dataSetTwoScale = double.Parse(dataSetTwoScaleTextBox.Text);
            UpdateChart();
        }

        private void dataSetThreeScaleTextBox_Validated(object sender, EventArgs e)
        {
            // Check if the TextBox is empty or only contains white spaces
            if (string.IsNullOrWhiteSpace(dataSetThreeScaleTextBox.Text))
            {
                // Set default value of 1
                dataSetThreeScaleTextBox.Text = "1";
            }

            // Parse the value to a double
            dataSetThreeScale = double.Parse(dataSetThreeScaleTextBox.Text);
            UpdateChart();
        }
        private void kPTrackBar_Scroll(object sender, EventArgs e)
        {
            double scaledValue = (double)kPTrackBar.Value / 100;
            kPValueTextBox.Text = scaledValue.ToString("0.00");
            //kP = (double)kPTrackBar.Value / 100;
        }

        private void kPMinTextBox_Validated(object sender, EventArgs e)
        {
            double scaledValue = double.Parse(kPMinTextBox.Text) * 100;
            kPTrackBar.Minimum = (int)(scaledValue);
        }

        private void kPMaxTextBox_Validated(object sender, EventArgs e)
        {
            double scaledValue = double.Parse(kPMaxTextBox.Text) * 100;
            kPTrackBar.Maximum = (int)(scaledValue);

        }

        private void kPValueTextBox_Validated(object sender, EventArgs e)
        {
            double value = double.Parse(kPValueTextBox.Text);
            //kP = value;
            if ((int)(value * 100) > kPTrackBar.Maximum)
            {
                kPTrackBar.Maximum = (int)(value * 100);
                kPMaxTextBox.Text = (kPTrackBar.Maximum / 100).ToString("0.00");
            }
            else if ((int)(value * 100) < kPTrackBar.Minimum)
            {
                kPTrackBar.Minimum = (int)(value * 100);
                kPMinTextBox.Text = (kPTrackBar.Minimum / 100).ToString("0.00");
            }
            kPTrackBar.Value = (int)(value * 100);
        }

        private void kITrackBar_Scroll(object sender, EventArgs e)
        {
            double scaledValue = (double)kITrackBar.Value / 100;
            kIValueTextBox.Text = scaledValue.ToString("0.00");
            //kI = (double)kITrackBar.Value / 100;
        }

        private void kIMinTextBox_Validated(object sender, EventArgs e)
        {
            double scaledValue = double.Parse(kIMinTextBox.Text) * 100;
            kITrackBar.Minimum = (int)(scaledValue);
        }

        private void kIMaxTextBox_Validated(object sender, EventArgs e)
        {
            double scaledValue = double.Parse(kIMaxTextBox.Text) * 100;
            kITrackBar.Maximum = (int)(scaledValue);
        }

        private void kIValueTextBox_Validated(object sender, EventArgs e)
        {
            double value = double.Parse(kIValueTextBox.Text);
            //kI = value;
            if ((int)(value * 100) > kITrackBar.Maximum)
            {
                kITrackBar.Maximum = (int)(value * 100);
                kIMaxTextBox.Text = (kITrackBar.Maximum / 100).ToString("0.00");
            }
            else if ((int)(value * 100) < kITrackBar.Minimum)
            {
                kITrackBar.Minimum = (int)(value * 100);
                kIMinTextBox.Text = (kITrackBar.Minimum / 100).ToString("0.00");
            }
            kITrackBar.Value = (int)(value * 100);
        }

        private void kDTrackBar_Scroll(object sender, EventArgs e)
        {
            double scaledValue = (double)kDTrackBar.Value / 100;
            kDValueTextBox.Text = scaledValue.ToString("0.00");
            //kD = (double)kDTrackBar.Value / 100;
        }

        private void kDMinTextBox_Validated(object sender, EventArgs e)
        {
            double scaledValue = double.Parse(kDMinTextBox.Text) * 100;
            kDTrackBar.Minimum = (int)(scaledValue);
        }

        private void kDMaxTextBox_Validated(object sender, EventArgs e)
        {
            double scaledValue = double.Parse(kDMaxTextBox.Text) * 100;
            kDTrackBar.Maximum = (int)(scaledValue);
        }

        private void kDValueTextBox_Validated(object sender, EventArgs e)
        {
            double value = double.Parse(kDValueTextBox.Text);
            //kD = value;
            if ((int)(value * 100) > kDTrackBar.Maximum)
            {
                kDTrackBar.Maximum = (int)(value * 100);
                kDMaxTextBox.Text = (kDTrackBar.Maximum / 100).ToString("0.00");
            }
            else if ((int)(value * 100) < kDTrackBar.Minimum)
            {
                kDTrackBar.Minimum = (int)(value * 100);
                kDMinTextBox.Text = (kDTrackBar.Minimum / 100).ToString("0.00");
            }
            kDTrackBar.Value = (int)(value * 100);
        }

        private void sendGain_Click(object sender, EventArgs e)
        {
            kP = double.Parse(kPValueTextBox.Text) / 100;
            kI = double.Parse(kIValueTextBox.Text) / 100;
            kD = double.Parse(kDValueTextBox.Text) / 100;


            b0 = kP * (1 + N * Ts) + kI * Ts * (1 + N * Ts) + kD * N;
            b1 = -(kP * (2 + N * Ts) + kI * Ts + 2 * kD * N);
            b2 = kP + kD * N;


            a0 = 1 + N * Ts;
            a1 = -(2 + N * Ts);
            a2 = 1;

            string formattedMessage = string.Format("rkPID{0:0.00000000} {1:0.00000000} {2:0.00000000} {3:0.00000000} {4:0.00000000} {5:0.00000000}",
                                             a0, a1, a2, b0, b1, b2);

            serialPort1.Write("rkPID" + a0.ToString("0.00000000") + " " + a1.ToString("0.00000000") + " " + a2.ToString("0.00000000") + " " + " " + b0.ToString("0.00000000") + " " + " " + b1.ToString("0.00000000") + " " + " " + b2.ToString("0.00000000"));
            gainSent = true;
        }

        private void PIDGainSaveButton_Click(object sender, EventArgs e)
        {
            kPMin = double.Parse(kPMinTextBox.Text);
            kP = double.Parse(kPValueTextBox.Text);
            kPMax = double.Parse(kPMaxTextBox.Text);

            kIMin = double.Parse(kIMinTextBox.Text);
            kI = double.Parse(kIValueTextBox.Text);
            kIMax = double.Parse(kIMaxTextBox.Text);

            kDMin = double.Parse(kDMinTextBox.Text);
            kD = double.Parse(kDValueTextBox.Text);
            kDMax = double.Parse(kDMaxTextBox.Text);

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
                    //worksheet.Cells[5, 6].Value = kP;
                    //worksheet.Cells[6, 6].Value = kI;
                    //worksheet.Cells[7, 6].Value = kD;

                    worksheet.Cells[5, 6].Value = kPMin;
                    worksheet.Cells[6, 6].Value = kP;
                    worksheet.Cells[7, 6].Value = kPMax;

                    worksheet.Cells[8, 6].Value = kIMin;
                    worksheet.Cells[9, 6].Value = kI;
                    worksheet.Cells[10, 6].Value = kIMax;

                    worksheet.Cells[11, 6].Value = kDMin;
                    worksheet.Cells[12, 6].Value = kD;
                    worksheet.Cells[13, 6].Value = kDMax;

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

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!gainSent && !targetRPMSent)
            {
                MessageBox.Show("Gain and Target RPM not set.\nPlease set Gain and Target RPM before running test.", "Test Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!targetRPMSent)
            {
                MessageBox.Show("Target RPM not set.\nPlease set Target RPM before running test.", "Test Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!gainSent)
            {
                MessageBox.Show("Gain not set.\nPlease set Gain before running test.", "Test Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (startButton.Text == "Start" && gainSent && targetRPMSent)
            {
                serialPort1.Write("pau_test_start");
                pauTestState = true;
                startButton.Text = "Stop";
                timer1.Enabled = true;
                
            }
            else if (startButton.Text == "Stop")
            {
                serialPort1.Write("pau_test_stop");
                pauTestState = false;
                startButton.Text = "Start";
                timer1.Enabled = false;
            }
        }

        private void applyBrakeButton_Click(object sender, EventArgs e)
        {
            if (pauTestState)
            {
                MessageBox.Show("Test is currently running.\nUnable to apply the brake.", "Brake Not Available", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (applyBrakeButton.Text == "Apply Brake" && !pauTestState)
            {
                serialPort1.Write("applyBrakeOn");
                applyBrakeButton.Text = "Turn Off Brake";
            }
            else if (applyBrakeButton.Text == "Turn Off Brake")
            {
                serialPort1.Write("applyBrakeOff");
                applyBrakeButton.Text = "Apply Brake";
            }
        }

        private void sendTargetRPMButton_Click(object sender, EventArgs e)
        {
            targetRPMSent = true;
            double targetRPMa = double.Parse(targetRPMTextBox.Text) / engineWheelRatio * wheelRollerRatio;
            targetRPM = (int)targetRPMa;

            serialPort1.Write("target_rpm" + targetRPM.ToString());

        }

        private void chartRefreshButton_Click(object sender, EventArgs e)
        {
            rpmList.Clear();
            timeList.Clear();
            torqueList.Clear();
            filteredOutputList.Clear();
            unfilteredOutputList.Clear();
            pGainList.Clear();
            iGainList.Clear();
            dGainList.Clear();
            throttlePositionList.Clear();
            motecRPMList.Clear();
            initialTimestamp = -1; // Reset the initial timestamp
            serialPort1.DiscardInBuffer(); // Clear the input buffer
            serialPort1.DiscardOutBuffer(); // Clear the output buffer
            UpdateChart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
 
                serialPort1.Write("request_data");
  
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                                                  "Confirm Exit",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevent the form from closing
            }
            if (result == DialogResult.Yes)
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

                        worksheet.Cells[15, 6].Value = dataSetOneComboBox.SelectedItem;
                        worksheet.Cells[16, 6].Value = double.Parse(dataSetOneScaleTextBox.Text);
                        worksheet.Cells[17, 6].Value = dataSetTwoComboBox.SelectedItem;
                        worksheet.Cells[18, 6].Value = double.Parse(dataSetTwoScaleTextBox.Text);
                        worksheet.Cells[19, 6].Value = dataSetThreeComboBox.SelectedItem;
                        worksheet.Cells[20, 6].Value = double.Parse(dataSetThreeScaleTextBox.Text);

                        worksheet.Cells[22, 6].Value = double.Parse(targetRPMTextBox.Text);



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
        }

        private void minus250Button_Click(object sender, EventArgs e)
        {
            targetRPMTextBox.Text = (int.Parse(targetRPMTextBox.Text)-250).ToString();
        }

        private void plus250Button_Click(object sender, EventArgs e)
        {
            targetRPMTextBox.Text = (int.Parse(targetRPMTextBox.Text) + 250).ToString();
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            try
            {
                // Retrieve the error information
                SerialError errorType = e.EventType;

                // Show the error in a message box
                MessageBox.Show($"Serial Port Error: {errorType}", "Error Received", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
