namespace DynoCalibration
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dynoCalibrationLabel = new System.Windows.Forms.Label();
            this.strainGaugeCalibrationLabel = new System.Windows.Forms.Label();
            this.dynoCalibrationStartStopButton = new System.Windows.Forms.Button();
            this.RPMLabel = new System.Windows.Forms.Label();
            this.zeroWeightLabel = new System.Windows.Forms.Label();
            this.calibrationEquationLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.lbsLabel = new System.Windows.Forms.Label();
            this.zeroWeightButton = new System.Windows.Forms.Button();
            this.someWeightCalibrationButton = new System.Windows.Forms.Button();
            this.calculateCalibrationEquationButton = new System.Windows.Forms.Button();
            this.testWeightButton = new System.Windows.Forms.Button();
            this.rawStrainValueButton = new System.Windows.Forms.Button();
            this.rawStrainValue = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.calWeightTextBox = new System.Windows.Forms.TextBox();
            this.zeroWeightTestLabel = new System.Windows.Forms.Label();
            this.someWeightTestLabel = new System.Windows.Forms.Label();
            this.calibrationEquationTest = new System.Windows.Forms.Label();
            this.saveStrainCalibrationButton = new System.Windows.Forms.Button();
            this.emergencyPAUVoltageLabel = new System.Windows.Forms.Label();
            this.emergencyPAUVoltageTrackBar = new System.Windows.Forms.TrackBar();
            this.zeroVoltLabel = new System.Windows.Forms.Label();
            this.threePointThreeVoltLabel = new System.Windows.Forms.Label();
            this.emergencyPAUVoltageValueLabel = new System.Windows.Forms.Label();
            this.startPAUVoltageTestButton = new System.Windows.Forms.Button();
            this.PAUValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.emergencyPAUVoltageTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // dynoCalibrationLabel
            // 
            this.dynoCalibrationLabel.AutoSize = true;
            this.dynoCalibrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dynoCalibrationLabel.Location = new System.Drawing.Point(581, 32);
            this.dynoCalibrationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dynoCalibrationLabel.Name = "dynoCalibrationLabel";
            this.dynoCalibrationLabel.Size = new System.Drawing.Size(146, 62);
            this.dynoCalibrationLabel.TabIndex = 19;
            this.dynoCalibrationLabel.Text = "Dyno Tach\r\nCalibration\r\n";
            this.dynoCalibrationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // strainGaugeCalibrationLabel
            // 
            this.strainGaugeCalibrationLabel.AutoSize = true;
            this.strainGaugeCalibrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strainGaugeCalibrationLabel.Location = new System.Drawing.Point(105, 32);
            this.strainGaugeCalibrationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.strainGaugeCalibrationLabel.Name = "strainGaugeCalibrationLabel";
            this.strainGaugeCalibrationLabel.Size = new System.Drawing.Size(180, 62);
            this.strainGaugeCalibrationLabel.TabIndex = 20;
            this.strainGaugeCalibrationLabel.Text = "Strain Gauge \r\nCalibration\r\n";
            this.strainGaugeCalibrationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dynoCalibrationStartStopButton
            // 
            this.dynoCalibrationStartStopButton.Location = new System.Drawing.Point(611, 111);
            this.dynoCalibrationStartStopButton.Margin = new System.Windows.Forms.Padding(4);
            this.dynoCalibrationStartStopButton.Name = "dynoCalibrationStartStopButton";
            this.dynoCalibrationStartStopButton.Size = new System.Drawing.Size(100, 28);
            this.dynoCalibrationStartStopButton.TabIndex = 21;
            this.dynoCalibrationStartStopButton.Text = "Start";
            this.dynoCalibrationStartStopButton.UseVisualStyleBackColor = true;
            this.dynoCalibrationStartStopButton.Click += new System.EventHandler(this.dynoCalibrationStartStopButton_Click);
            // 
            // RPMLabel
            // 
            this.RPMLabel.AutoSize = true;
            this.RPMLabel.Location = new System.Drawing.Point(627, 155);
            this.RPMLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RPMLabel.Name = "RPMLabel";
            this.RPMLabel.Size = new System.Drawing.Size(63, 16);
            this.RPMLabel.TabIndex = 22;
            this.RPMLabel.Text = "N/A RPM";
            // 
            // zeroWeightLabel
            // 
            this.zeroWeightLabel.AutoSize = true;
            this.zeroWeightLabel.Location = new System.Drawing.Point(44, 111);
            this.zeroWeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zeroWeightLabel.Name = "zeroWeightLabel";
            this.zeroWeightLabel.Size = new System.Drawing.Size(83, 16);
            this.zeroWeightLabel.TabIndex = 23;
            this.zeroWeightLabel.Text = "Zero Weight:";
            // 
            // calibrationEquationLabel
            // 
            this.calibrationEquationLabel.AutoSize = true;
            this.calibrationEquationLabel.Location = new System.Drawing.Point(44, 224);
            this.calibrationEquationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.calibrationEquationLabel.Name = "calibrationEquationLabel";
            this.calibrationEquationLabel.Size = new System.Drawing.Size(71, 32);
            this.calibrationEquationLabel.TabIndex = 24;
            this.calibrationEquationLabel.Text = "Calibration\r\nEquation";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(44, 297);
            this.weightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(99, 16);
            this.weightLabel.TabIndex = 25;
            this.weightLabel.Text = "Weight: N/A lbs";
            // 
            // lbsLabel
            // 
            this.lbsLabel.AutoSize = true;
            this.lbsLabel.Location = new System.Drawing.Point(111, 169);
            this.lbsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbsLabel.Name = "lbsLabel";
            this.lbsLabel.Size = new System.Drawing.Size(25, 16);
            this.lbsLabel.TabIndex = 26;
            this.lbsLabel.Text = "lbs";
            // 
            // zeroWeightButton
            // 
            this.zeroWeightButton.Location = new System.Drawing.Point(216, 105);
            this.zeroWeightButton.Margin = new System.Windows.Forms.Padding(4);
            this.zeroWeightButton.Name = "zeroWeightButton";
            this.zeroWeightButton.Size = new System.Drawing.Size(100, 28);
            this.zeroWeightButton.TabIndex = 27;
            this.zeroWeightButton.Text = "Calibrate";
            this.zeroWeightButton.UseVisualStyleBackColor = true;
            this.zeroWeightButton.Click += new System.EventHandler(this.zeroWeightButton_Click);
            // 
            // someWeightCalibrationButton
            // 
            this.someWeightCalibrationButton.Location = new System.Drawing.Point(216, 161);
            this.someWeightCalibrationButton.Margin = new System.Windows.Forms.Padding(4);
            this.someWeightCalibrationButton.Name = "someWeightCalibrationButton";
            this.someWeightCalibrationButton.Size = new System.Drawing.Size(100, 28);
            this.someWeightCalibrationButton.TabIndex = 28;
            this.someWeightCalibrationButton.Text = "Calibrate";
            this.someWeightCalibrationButton.UseVisualStyleBackColor = true;
            this.someWeightCalibrationButton.Click += new System.EventHandler(this.someWeightCalibrationButton_Click);
            // 
            // calculateCalibrationEquationButton
            // 
            this.calculateCalibrationEquationButton.Location = new System.Drawing.Point(216, 224);
            this.calculateCalibrationEquationButton.Margin = new System.Windows.Forms.Padding(4);
            this.calculateCalibrationEquationButton.Name = "calculateCalibrationEquationButton";
            this.calculateCalibrationEquationButton.Size = new System.Drawing.Size(100, 28);
            this.calculateCalibrationEquationButton.TabIndex = 29;
            this.calculateCalibrationEquationButton.Text = "Calculate";
            this.calculateCalibrationEquationButton.UseVisualStyleBackColor = true;
            this.calculateCalibrationEquationButton.Click += new System.EventHandler(this.calculateCalibrationEquationButton_Click);
            // 
            // testWeightButton
            // 
            this.testWeightButton.Location = new System.Drawing.Point(216, 289);
            this.testWeightButton.Margin = new System.Windows.Forms.Padding(4);
            this.testWeightButton.Name = "testWeightButton";
            this.testWeightButton.Size = new System.Drawing.Size(115, 30);
            this.testWeightButton.TabIndex = 30;
            this.testWeightButton.Text = "Start Measure";
            this.testWeightButton.UseVisualStyleBackColor = true;
            this.testWeightButton.Click += new System.EventHandler(this.testWeightButton_Click);
            // 
            // rawStrainValueButton
            // 
            this.rawStrainValueButton.Location = new System.Drawing.Point(81, 513);
            this.rawStrainValueButton.Margin = new System.Windows.Forms.Padding(4);
            this.rawStrainValueButton.Name = "rawStrainValueButton";
            this.rawStrainValueButton.Size = new System.Drawing.Size(184, 27);
            this.rawStrainValueButton.TabIndex = 31;
            this.rawStrainValueButton.Text = "Raw Strain Value";
            this.rawStrainValueButton.UseVisualStyleBackColor = true;
            this.rawStrainValueButton.Click += new System.EventHandler(this.rawStrainValueButton_Click);
            // 
            // rawStrainValue
            // 
            this.rawStrainValue.AutoSize = true;
            this.rawStrainValue.Location = new System.Drawing.Point(77, 557);
            this.rawStrainValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rawStrainValue.Name = "rawStrainValue";
            this.rawStrainValue.Size = new System.Drawing.Size(145, 16);
            this.rawStrainValue.TabIndex = 32;
            this.rawStrainValue.Text = "Raw Strain Value = N/A";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM7";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // calWeightTextBox
            // 
            this.calWeightTextBox.Location = new System.Drawing.Point(48, 165);
            this.calWeightTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.calWeightTextBox.Name = "calWeightTextBox";
            this.calWeightTextBox.Size = new System.Drawing.Size(53, 22);
            this.calWeightTextBox.TabIndex = 33;
            this.calWeightTextBox.Validated += new System.EventHandler(this.calWeightTextBox_Validated);
            // 
            // zeroWeightTestLabel
            // 
            this.zeroWeightTestLabel.AutoSize = true;
            this.zeroWeightTestLabel.Location = new System.Drawing.Point(364, 111);
            this.zeroWeightTestLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zeroWeightTestLabel.Name = "zeroWeightTestLabel";
            this.zeroWeightTestLabel.Size = new System.Drawing.Size(30, 16);
            this.zeroWeightTestLabel.TabIndex = 34;
            this.zeroWeightTestLabel.Text = "N/A";
            // 
            // someWeightTestLabel
            // 
            this.someWeightTestLabel.AutoSize = true;
            this.someWeightTestLabel.Location = new System.Drawing.Point(364, 169);
            this.someWeightTestLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.someWeightTestLabel.Name = "someWeightTestLabel";
            this.someWeightTestLabel.Size = new System.Drawing.Size(30, 16);
            this.someWeightTestLabel.TabIndex = 35;
            this.someWeightTestLabel.Text = "N/A";
            // 
            // calibrationEquationTest
            // 
            this.calibrationEquationTest.AutoSize = true;
            this.calibrationEquationTest.Location = new System.Drawing.Point(364, 230);
            this.calibrationEquationTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.calibrationEquationTest.Name = "calibrationEquationTest";
            this.calibrationEquationTest.Size = new System.Drawing.Size(30, 16);
            this.calibrationEquationTest.TabIndex = 36;
            this.calibrationEquationTest.Text = "N/A";
            // 
            // saveStrainCalibrationButton
            // 
            this.saveStrainCalibrationButton.Location = new System.Drawing.Point(81, 351);
            this.saveStrainCalibrationButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveStrainCalibrationButton.Name = "saveStrainCalibrationButton";
            this.saveStrainCalibrationButton.Size = new System.Drawing.Size(216, 30);
            this.saveStrainCalibrationButton.TabIndex = 39;
            this.saveStrainCalibrationButton.Text = "Save Strain Gauge Calibration";
            this.saveStrainCalibrationButton.UseVisualStyleBackColor = true;
            this.saveStrainCalibrationButton.Click += new System.EventHandler(this.saveStrainCalibrationButton_Click);
            // 
            // emergencyPAUVoltageLabel
            // 
            this.emergencyPAUVoltageLabel.AutoSize = true;
            this.emergencyPAUVoltageLabel.Location = new System.Drawing.Point(436, 453);
            this.emergencyPAUVoltageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emergencyPAUVoltageLabel.Name = "emergencyPAUVoltageLabel";
            this.emergencyPAUVoltageLabel.Size = new System.Drawing.Size(110, 32);
            this.emergencyPAUVoltageLabel.TabIndex = 45;
            this.emergencyPAUVoltageLabel.Text = "Emergency PAU \r\nVoltage:";
            this.emergencyPAUVoltageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // emergencyPAUVoltageTrackBar
            // 
            this.emergencyPAUVoltageTrackBar.Location = new System.Drawing.Point(567, 453);
            this.emergencyPAUVoltageTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.emergencyPAUVoltageTrackBar.Maximum = 255;
            this.emergencyPAUVoltageTrackBar.Name = "emergencyPAUVoltageTrackBar";
            this.emergencyPAUVoltageTrackBar.Size = new System.Drawing.Size(436, 56);
            this.emergencyPAUVoltageTrackBar.TabIndex = 46;
            this.emergencyPAUVoltageTrackBar.TickFrequency = 5;
            this.emergencyPAUVoltageTrackBar.Scroll += new System.EventHandler(this.emergencyPAUVoltageTrackBar_Scroll);
            // 
            // zeroVoltLabel
            // 
            this.zeroVoltLabel.AutoSize = true;
            this.zeroVoltLabel.Location = new System.Drawing.Point(554, 453);
            this.zeroVoltLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zeroVoltLabel.Name = "zeroVoltLabel";
            this.zeroVoltLabel.Size = new System.Drawing.Size(14, 16);
            this.zeroVoltLabel.TabIndex = 47;
            this.zeroVoltLabel.Text = "0";
            // 
            // threePointThreeVoltLabel
            // 
            this.threePointThreeVoltLabel.AutoSize = true;
            this.threePointThreeVoltLabel.Location = new System.Drawing.Point(1033, 462);
            this.threePointThreeVoltLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.threePointThreeVoltLabel.Name = "threePointThreeVoltLabel";
            this.threePointThreeVoltLabel.Size = new System.Drawing.Size(28, 16);
            this.threePointThreeVoltLabel.TabIndex = 48;
            this.threePointThreeVoltLabel.Text = "255";
            // 
            // emergencyPAUVoltageValueLabel
            // 
            this.emergencyPAUVoltageValueLabel.AutoSize = true;
            this.emergencyPAUVoltageValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emergencyPAUVoltageValueLabel.Location = new System.Drawing.Point(765, 523);
            this.emergencyPAUVoltageValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emergencyPAUVoltageValueLabel.Name = "emergencyPAUVoltageValueLabel";
            this.emergencyPAUVoltageValueLabel.Size = new System.Drawing.Size(186, 38);
            this.emergencyPAUVoltageValueLabel.TabIndex = 49;
            this.emergencyPAUVoltageValueLabel.Text = "PAU Value:";
            this.emergencyPAUVoltageValueLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // startPAUVoltageTestButton
            // 
            this.startPAUVoltageTestButton.Location = new System.Drawing.Point(438, 512);
            this.startPAUVoltageTestButton.Name = "startPAUVoltageTestButton";
            this.startPAUVoltageTestButton.Size = new System.Drawing.Size(270, 100);
            this.startPAUVoltageTestButton.TabIndex = 53;
            this.startPAUVoltageTestButton.Text = "Start PAU\r\nVoltage Test";
            this.startPAUVoltageTestButton.UseVisualStyleBackColor = true;
            this.startPAUVoltageTestButton.Click += new System.EventHandler(this.startPAUVoltageTestButton_Click);
            // 
            // PAUValueLabel
            // 
            this.PAUValueLabel.AutoSize = true;
            this.PAUValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAUValueLabel.Location = new System.Drawing.Point(966, 513);
            this.PAUValueLabel.Name = "PAUValueLabel";
            this.PAUValueLabel.Size = new System.Drawing.Size(94, 51);
            this.PAUValueLabel.TabIndex = 54;
            this.PAUValueLabel.Text = "N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 628);
            this.Controls.Add(this.PAUValueLabel);
            this.Controls.Add(this.startPAUVoltageTestButton);
            this.Controls.Add(this.emergencyPAUVoltageValueLabel);
            this.Controls.Add(this.threePointThreeVoltLabel);
            this.Controls.Add(this.zeroVoltLabel);
            this.Controls.Add(this.emergencyPAUVoltageTrackBar);
            this.Controls.Add(this.emergencyPAUVoltageLabel);
            this.Controls.Add(this.saveStrainCalibrationButton);
            this.Controls.Add(this.calibrationEquationTest);
            this.Controls.Add(this.someWeightTestLabel);
            this.Controls.Add(this.zeroWeightTestLabel);
            this.Controls.Add(this.calWeightTextBox);
            this.Controls.Add(this.rawStrainValue);
            this.Controls.Add(this.rawStrainValueButton);
            this.Controls.Add(this.testWeightButton);
            this.Controls.Add(this.calculateCalibrationEquationButton);
            this.Controls.Add(this.someWeightCalibrationButton);
            this.Controls.Add(this.zeroWeightButton);
            this.Controls.Add(this.lbsLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.calibrationEquationLabel);
            this.Controls.Add(this.zeroWeightLabel);
            this.Controls.Add(this.RPMLabel);
            this.Controls.Add(this.dynoCalibrationStartStopButton);
            this.Controls.Add(this.strainGaugeCalibrationLabel);
            this.Controls.Add(this.dynoCalibrationLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.emergencyPAUVoltageTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dynoCalibrationLabel;
        private System.Windows.Forms.Label strainGaugeCalibrationLabel;
        private System.Windows.Forms.Button dynoCalibrationStartStopButton;
        private System.Windows.Forms.Label RPMLabel;
        private System.Windows.Forms.Label zeroWeightLabel;
        private System.Windows.Forms.Label calibrationEquationLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label lbsLabel;
        private System.Windows.Forms.Button zeroWeightButton;
        private System.Windows.Forms.Button someWeightCalibrationButton;
        private System.Windows.Forms.Button calculateCalibrationEquationButton;
        private System.Windows.Forms.Button testWeightButton;
        private System.Windows.Forms.Button rawStrainValueButton;
        private System.Windows.Forms.Label rawStrainValue;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox calWeightTextBox;
        private System.Windows.Forms.Label zeroWeightTestLabel;
        private System.Windows.Forms.Label someWeightTestLabel;
        private System.Windows.Forms.Label calibrationEquationTest;
        private System.Windows.Forms.Button saveStrainCalibrationButton;
        private System.Windows.Forms.Label emergencyPAUVoltageLabel;
        private System.Windows.Forms.TrackBar emergencyPAUVoltageTrackBar;
        private System.Windows.Forms.Label zeroVoltLabel;
        private System.Windows.Forms.Label threePointThreeVoltLabel;
        private System.Windows.Forms.Label emergencyPAUVoltageValueLabel;
        private System.Windows.Forms.Button startPAUVoltageTestButton;
        private System.Windows.Forms.Label PAUValueLabel;
    }
}

