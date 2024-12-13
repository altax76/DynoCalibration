namespace DynoCalibration
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.engineToWheelRatioLabel = new System.Windows.Forms.Label();
            this.wheelToRollerRatioLabel = new System.Windows.Forms.Label();
            this.engineToWheelRatioTextBox = new System.Windows.Forms.TextBox();
            this.wheelToRollerRatioTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRefreshButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.fileSaveButton = new System.Windows.Forms.Button();
            this.rollerDiameterTextBox = new System.Windows.Forms.TextBox();
            this.rollerMassTextBox = new System.Windows.Forms.TextBox();
            this.rollerDiameterLabel = new System.Windows.Forms.Label();
            this.rollerMassLabel = new System.Windows.Forms.Label();
            this.pullStopTextBox = new System.Windows.Forms.TextBox();
            this.pullStartTextBox = new System.Windows.Forms.TextBox();
            this.pullStopLabel = new System.Windows.Forms.Label();
            this.pullStartLabel = new System.Windows.Forms.Label();
            this.saveVehicleData = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.currentRPMLabel = new System.Windows.Forms.Label();
            this.applyBrakeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.calculate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dynoDataLabel = new System.Windows.Forms.Label();
            this.addLossesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inertial Pull";
            // 
            // engineToWheelRatioLabel
            // 
            this.engineToWheelRatioLabel.AutoSize = true;
            this.engineToWheelRatioLabel.Location = new System.Drawing.Point(34, 61);
            this.engineToWheelRatioLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.engineToWheelRatioLabel.Name = "engineToWheelRatioLabel";
            this.engineToWheelRatioLabel.Size = new System.Drawing.Size(117, 13);
            this.engineToWheelRatioLabel.TabIndex = 1;
            this.engineToWheelRatioLabel.Text = "Engine to Wheel Ratio:";
            // 
            // wheelToRollerRatioLabel
            // 
            this.wheelToRollerRatioLabel.AutoSize = true;
            this.wheelToRollerRatioLabel.Location = new System.Drawing.Point(34, 87);
            this.wheelToRollerRatioLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.wheelToRollerRatioLabel.Name = "wheelToRollerRatioLabel";
            this.wheelToRollerRatioLabel.Size = new System.Drawing.Size(111, 13);
            this.wheelToRollerRatioLabel.TabIndex = 2;
            this.wheelToRollerRatioLabel.Text = "Wheel to Roller Ratio:";
            // 
            // engineToWheelRatioTextBox
            // 
            this.engineToWheelRatioTextBox.Location = new System.Drawing.Point(155, 61);
            this.engineToWheelRatioTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.engineToWheelRatioTextBox.Name = "engineToWheelRatioTextBox";
            this.engineToWheelRatioTextBox.Size = new System.Drawing.Size(76, 20);
            this.engineToWheelRatioTextBox.TabIndex = 3;
            // 
            // wheelToRollerRatioTextBox
            // 
            this.wheelToRollerRatioTextBox.Location = new System.Drawing.Point(155, 87);
            this.wheelToRollerRatioTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wheelToRollerRatioTextBox.Name = "wheelToRollerRatioTextBox";
            this.wheelToRollerRatioTextBox.Size = new System.Drawing.Size(76, 20);
            this.wheelToRollerRatioTextBox.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(529, 624);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(149, 92);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(259, 27);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "RPM";
            series2.BorderWidth = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "None";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(901, 477);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // chartRefreshButton
            // 
            this.chartRefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartRefreshButton.Location = new System.Drawing.Point(1067, 538);
            this.chartRefreshButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chartRefreshButton.Name = "chartRefreshButton";
            this.chartRefreshButton.Size = new System.Drawing.Size(93, 35);
            this.chartRefreshButton.TabIndex = 11;
            this.chartRefreshButton.Text = "Refresh";
            this.chartRefreshButton.UseVisualStyleBackColor = true;
            this.chartRefreshButton.Click += new System.EventHandler(this.chartRefreshButton_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM7";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(50, 2);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(238, 20);
            this.filePathTextBox.TabIndex = 12;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(350, 2);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(158, 20);
            this.fileNameTextBox.TabIndex = 13;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(2, 5);
            this.filePathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(51, 13);
            this.filePathLabel.TabIndex = 14;
            this.filePathLabel.Text = "File Path:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(291, 5);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fileNameLabel.TabIndex = 15;
            this.fileNameLabel.Text = "File Name:";
            // 
            // fileSaveButton
            // 
            this.fileSaveButton.Location = new System.Drawing.Point(511, 2);
            this.fileSaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileSaveButton.Name = "fileSaveButton";
            this.fileSaveButton.Size = new System.Drawing.Size(56, 19);
            this.fileSaveButton.TabIndex = 16;
            this.fileSaveButton.Text = "Save Run";
            this.fileSaveButton.UseVisualStyleBackColor = true;
            this.fileSaveButton.Click += new System.EventHandler(this.fileSaveButton_Click);
            // 
            // rollerDiameterTextBox
            // 
            this.rollerDiameterTextBox.Location = new System.Drawing.Point(155, 139);
            this.rollerDiameterTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rollerDiameterTextBox.Name = "rollerDiameterTextBox";
            this.rollerDiameterTextBox.Size = new System.Drawing.Size(76, 20);
            this.rollerDiameterTextBox.TabIndex = 20;
            this.rollerDiameterTextBox.Validated += new System.EventHandler(this.rollerDiameterTextBox_Validated);
            // 
            // rollerMassTextBox
            // 
            this.rollerMassTextBox.Location = new System.Drawing.Point(155, 113);
            this.rollerMassTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rollerMassTextBox.Name = "rollerMassTextBox";
            this.rollerMassTextBox.Size = new System.Drawing.Size(76, 20);
            this.rollerMassTextBox.TabIndex = 19;
            this.rollerMassTextBox.Validated += new System.EventHandler(this.rollerMassTextBox_Validated);
            // 
            // rollerDiameterLabel
            // 
            this.rollerDiameterLabel.AutoSize = true;
            this.rollerDiameterLabel.Location = new System.Drawing.Point(34, 139);
            this.rollerDiameterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollerDiameterLabel.Name = "rollerDiameterLabel";
            this.rollerDiameterLabel.Size = new System.Drawing.Size(99, 13);
            this.rollerDiameterLabel.TabIndex = 18;
            this.rollerDiameterLabel.Text = "Roller Diameter [in]:";
            // 
            // rollerMassLabel
            // 
            this.rollerMassLabel.AutoSize = true;
            this.rollerMassLabel.Location = new System.Drawing.Point(34, 113);
            this.rollerMassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollerMassLabel.Name = "rollerMassLabel";
            this.rollerMassLabel.Size = new System.Drawing.Size(82, 13);
            this.rollerMassLabel.TabIndex = 17;
            this.rollerMassLabel.Text = "Roller Mass [lb]:";
            // 
            // pullStopTextBox
            // 
            this.pullStopTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pullStopTextBox.Location = new System.Drawing.Point(161, 231);
            this.pullStopTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pullStopTextBox.Name = "pullStopTextBox";
            this.pullStopTextBox.Size = new System.Drawing.Size(76, 28);
            this.pullStopTextBox.TabIndex = 24;
            this.pullStopTextBox.Validated += new System.EventHandler(this.pullStopTextBox_Validated);
            // 
            // pullStartTextBox
            // 
            this.pullStartTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pullStartTextBox.Location = new System.Drawing.Point(161, 184);
            this.pullStartTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pullStartTextBox.Name = "pullStartTextBox";
            this.pullStartTextBox.Size = new System.Drawing.Size(76, 28);
            this.pullStartTextBox.TabIndex = 23;
            this.pullStartTextBox.Validated += new System.EventHandler(this.pullStartTextBox_Validated);
            // 
            // pullStopLabel
            // 
            this.pullStopLabel.AutoSize = true;
            this.pullStopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pullStopLabel.Location = new System.Drawing.Point(14, 231);
            this.pullStopLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pullStopLabel.Name = "pullStopLabel";
            this.pullStopLabel.Size = new System.Drawing.Size(145, 24);
            this.pullStopLabel.TabIndex = 22;
            this.pullStopLabel.Text = "Pull Stop [RPM]:";
            // 
            // pullStartLabel
            // 
            this.pullStartLabel.AutoSize = true;
            this.pullStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pullStartLabel.Location = new System.Drawing.Point(14, 184);
            this.pullStartLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pullStartLabel.Name = "pullStartLabel";
            this.pullStartLabel.Size = new System.Drawing.Size(143, 24);
            this.pullStartLabel.TabIndex = 21;
            this.pullStartLabel.Text = "Pull Start [RPM]:";
            // 
            // saveVehicleData
            // 
            this.saveVehicleData.Location = new System.Drawing.Point(74, 241);
            this.saveVehicleData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveVehicleData.Name = "saveVehicleData";
            this.saveVehicleData.Size = new System.Drawing.Size(89, 21);
            this.saveVehicleData.TabIndex = 25;
            this.saveVehicleData.Text = "Save Car Data";
            this.saveVehicleData.UseVisualStyleBackColor = true;
            this.saveVehicleData.Click += new System.EventHandler(this.saveVehicleData_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.saveVehicleData);
            this.panel1.Location = new System.Drawing.Point(9, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 280);
            this.panel1.TabIndex = 26;
            // 
            // currentRPMLabel
            // 
            this.currentRPMLabel.AutoSize = true;
            this.currentRPMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRPMLabel.Location = new System.Drawing.Point(44, 628);
            this.currentRPMLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentRPMLabel.Name = "currentRPMLabel";
            this.currentRPMLabel.Size = new System.Drawing.Size(316, 73);
            this.currentRPMLabel.TabIndex = 30;
            this.currentRPMLabel.Text = "RPM: N/A";
            // 
            // applyBrakeButton
            // 
            this.applyBrakeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyBrakeButton.Location = new System.Drawing.Point(815, 624);
            this.applyBrakeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.applyBrakeButton.Name = "applyBrakeButton";
            this.applyBrakeButton.Size = new System.Drawing.Size(139, 92);
            this.applyBrakeButton.TabIndex = 31;
            this.applyBrakeButton.Text = "Apply Brake";
            this.applyBrakeButton.UseVisualStyleBackColor = true;
            this.applyBrakeButton.Click += new System.EventHandler(this.applyBrakeButton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.filePathTextBox);
            this.panel2.Controls.Add(this.filePathLabel);
            this.panel2.Controls.Add(this.fileNameLabel);
            this.panel2.Controls.Add(this.fileNameTextBox);
            this.panel2.Controls.Add(this.fileSaveButton);
            this.panel2.Location = new System.Drawing.Point(592, 767);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 26);
            this.panel2.TabIndex = 32;
            // 
            // calculate
            // 
            this.calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate.Location = new System.Drawing.Point(259, 538);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(203, 33);
            this.calculate.TabIndex = 33;
            this.calculate.Text = "Calculate Torque and HP";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dynoDataLabel);
            this.panel3.Location = new System.Drawing.Point(259, 508);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(901, 29);
            this.panel3.TabIndex = 34;
            // 
            // dynoDataLabel
            // 
            this.dynoDataLabel.AutoSize = true;
            this.dynoDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dynoDataLabel.Location = new System.Drawing.Point(2, 0);
            this.dynoDataLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dynoDataLabel.Name = "dynoDataLabel";
            this.dynoDataLabel.Size = new System.Drawing.Size(241, 24);
            this.dynoDataLabel.TabIndex = 0;
            this.dynoDataLabel.Text = "Conduct test to Display Data";
            // 
            // addLossesButton
            // 
            this.addLossesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLossesButton.Location = new System.Drawing.Point(464, 538);
            this.addLossesButton.Name = "addLossesButton";
            this.addLossesButton.Size = new System.Drawing.Size(264, 33);
            this.addLossesButton.TabIndex = 35;
            this.addLossesButton.Text = "Add Drivetrain and Dyno Losses";
            this.addLossesButton.UseVisualStyleBackColor = true;
            this.addLossesButton.Click += new System.EventHandler(this.addLossesButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 799);
            this.Controls.Add(this.addLossesButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.applyBrakeButton);
            this.Controls.Add(this.currentRPMLabel);
            this.Controls.Add(this.pullStopTextBox);
            this.Controls.Add(this.pullStartTextBox);
            this.Controls.Add(this.pullStopLabel);
            this.Controls.Add(this.pullStartLabel);
            this.Controls.Add(this.rollerDiameterTextBox);
            this.Controls.Add(this.rollerMassTextBox);
            this.Controls.Add(this.rollerDiameterLabel);
            this.Controls.Add(this.rollerMassLabel);
            this.Controls.Add(this.chartRefreshButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.wheelToRollerRatioTextBox);
            this.Controls.Add(this.engineToWheelRatioTextBox);
            this.Controls.Add(this.wheelToRollerRatioLabel);
            this.Controls.Add(this.engineToWheelRatioLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label engineToWheelRatioLabel;
        private System.Windows.Forms.Label wheelToRollerRatioLabel;
        private System.Windows.Forms.TextBox engineToWheelRatioTextBox;
        private System.Windows.Forms.TextBox wheelToRollerRatioTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button chartRefreshButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button fileSaveButton;
        private System.Windows.Forms.TextBox rollerDiameterTextBox;
        private System.Windows.Forms.TextBox rollerMassTextBox;
        private System.Windows.Forms.Label rollerDiameterLabel;
        private System.Windows.Forms.Label rollerMassLabel;
        private System.Windows.Forms.TextBox pullStopTextBox;
        private System.Windows.Forms.TextBox pullStartTextBox;
        private System.Windows.Forms.Label pullStopLabel;
        private System.Windows.Forms.Label pullStartLabel;
        private System.Windows.Forms.Button saveVehicleData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label currentRPMLabel;
        private System.Windows.Forms.Button applyBrakeButton;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label dynoDataLabel;
        private System.Windows.Forms.Button addLossesButton;
    }
}