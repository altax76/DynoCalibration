namespace DynoCalibration
{
    partial class Form4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PIDChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataSetOneComboBox = new System.Windows.Forms.ComboBox();
            this.dataSetTwoComboBox = new System.Windows.Forms.ComboBox();
            this.dataSetThreeComboBox = new System.Windows.Forms.ComboBox();
            this.dataSetOneLabel = new System.Windows.Forms.Label();
            this.dataSetTwoLabel = new System.Windows.Forms.Label();
            this.dataSetThreeLabel = new System.Windows.Forms.Label();
            this.fileSaveButton = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xLabelThree = new System.Windows.Forms.Label();
            this.xLabelTwo = new System.Windows.Forms.Label();
            this.xLabelOne = new System.Windows.Forms.Label();
            this.dataSetThreeScaleTextBox = new System.Windows.Forms.TextBox();
            this.dataSetTwoScaleTextBox = new System.Windows.Forms.TextBox();
            this.dataSetOneScaleTextBox = new System.Windows.Forms.TextBox();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.sendGain = new System.Windows.Forms.Button();
            this.targetRPMTextBox = new System.Windows.Forms.TextBox();
            this.setTargetRPMLabel = new System.Windows.Forms.Label();
            this.PIDGainSaveButton = new System.Windows.Forms.Button();
            this.kDValueLabel = new System.Windows.Forms.Label();
            this.kDValueTextBox = new System.Windows.Forms.TextBox();
            this.kDMaxTextBox = new System.Windows.Forms.TextBox();
            this.kDMinTextBox = new System.Windows.Forms.TextBox();
            this.kDTrackBar = new System.Windows.Forms.TrackBar();
            this.kIValueLabel = new System.Windows.Forms.Label();
            this.kIValueTextBox = new System.Windows.Forms.TextBox();
            this.kIMaxTextBox = new System.Windows.Forms.TextBox();
            this.kIMinTextBox = new System.Windows.Forms.TextBox();
            this.kITrackBar = new System.Windows.Forms.TrackBar();
            this.PAULabel = new System.Windows.Forms.Label();
            this.kPValueLabel = new System.Windows.Forms.Label();
            this.kPValueTextBox = new System.Windows.Forms.TextBox();
            this.kPMaxTextBox = new System.Windows.Forms.TextBox();
            this.kPMinTextBox = new System.Windows.Forms.TextBox();
            this.kPTrackBar = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sendTargetRPMButton = new System.Windows.Forms.Button();
            this.RPMLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentRPMLabel = new System.Windows.Forms.Label();
            this.currentTorqueLabel = new System.Windows.Forms.Label();
            this.currentPIDOutputLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.applyBrakeButton = new System.Windows.Forms.Button();
            this.chartRefreshButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.SerialMonitorOutputLabel = new System.Windows.Forms.Label();
            this.SerialMonitorLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PIDChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kDTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kITrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kPTrackBar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // PIDChart
            // 
            chartArea4.Name = "ChartArea1";
            this.PIDChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.PIDChart.Legends.Add(legend4);
            this.PIDChart.Location = new System.Drawing.Point(12, 12);
            this.PIDChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PIDChart.Name = "PIDChart";
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.Name = "Data Set 1";
            series11.BorderWidth = 3;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "Data Set 2";
            series12.BorderWidth = 3;
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.Name = "Data Set 3";
            this.PIDChart.Series.Add(series10);
            this.PIDChart.Series.Add(series11);
            this.PIDChart.Series.Add(series12);
            this.PIDChart.Size = new System.Drawing.Size(899, 473);
            this.PIDChart.TabIndex = 0;
            this.PIDChart.Text = "PIDChart";
            // 
            // dataSetOneComboBox
            // 
            this.dataSetOneComboBox.FormattingEnabled = true;
            this.dataSetOneComboBox.Items.AddRange(new object[] {
            "None",
            "RPM",
            "Torque",
            "Filtered Output",
            "Unfiltered Output"});
            this.dataSetOneComboBox.Location = new System.Drawing.Point(5, 23);
            this.dataSetOneComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataSetOneComboBox.Name = "dataSetOneComboBox";
            this.dataSetOneComboBox.Size = new System.Drawing.Size(121, 24);
            this.dataSetOneComboBox.TabIndex = 1;
            this.dataSetOneComboBox.Text = "None";
            this.dataSetOneComboBox.SelectedIndexChanged += new System.EventHandler(this.dataSetOneComboBox_SelectedIndexChanged);
            // 
            // dataSetTwoComboBox
            // 
            this.dataSetTwoComboBox.FormattingEnabled = true;
            this.dataSetTwoComboBox.Items.AddRange(new object[] {
            "None",
            "RPM",
            "Torque",
            "Filtered Output",
            "Unfiltered Output"});
            this.dataSetTwoComboBox.Location = new System.Drawing.Point(5, 98);
            this.dataSetTwoComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataSetTwoComboBox.Name = "dataSetTwoComboBox";
            this.dataSetTwoComboBox.Size = new System.Drawing.Size(121, 24);
            this.dataSetTwoComboBox.TabIndex = 2;
            this.dataSetTwoComboBox.Text = "None";
            this.dataSetTwoComboBox.SelectedIndexChanged += new System.EventHandler(this.dataSetTwoComboBox_SelectedIndexChanged);
            // 
            // dataSetThreeComboBox
            // 
            this.dataSetThreeComboBox.FormattingEnabled = true;
            this.dataSetThreeComboBox.Items.AddRange(new object[] {
            "None",
            "RPM",
            "Torque",
            "Filtered Output",
            "Unfiltered Output"});
            this.dataSetThreeComboBox.Location = new System.Drawing.Point(5, 174);
            this.dataSetThreeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataSetThreeComboBox.Name = "dataSetThreeComboBox";
            this.dataSetThreeComboBox.Size = new System.Drawing.Size(121, 24);
            this.dataSetThreeComboBox.TabIndex = 3;
            this.dataSetThreeComboBox.Text = "None";
            this.dataSetThreeComboBox.SelectedIndexChanged += new System.EventHandler(this.dataSetThreeComboBox_SelectedIndexChanged);
            // 
            // dataSetOneLabel
            // 
            this.dataSetOneLabel.AutoSize = true;
            this.dataSetOneLabel.Location = new System.Drawing.Point(3, 4);
            this.dataSetOneLabel.Name = "dataSetOneLabel";
            this.dataSetOneLabel.Size = new System.Drawing.Size(72, 16);
            this.dataSetOneLabel.TabIndex = 4;
            this.dataSetOneLabel.Text = "Data Set 1:";
            // 
            // dataSetTwoLabel
            // 
            this.dataSetTwoLabel.AutoSize = true;
            this.dataSetTwoLabel.Location = new System.Drawing.Point(3, 80);
            this.dataSetTwoLabel.Name = "dataSetTwoLabel";
            this.dataSetTwoLabel.Size = new System.Drawing.Size(72, 16);
            this.dataSetTwoLabel.TabIndex = 5;
            this.dataSetTwoLabel.Text = "Data Set 2:";
            // 
            // dataSetThreeLabel
            // 
            this.dataSetThreeLabel.AutoSize = true;
            this.dataSetThreeLabel.Location = new System.Drawing.Point(3, 155);
            this.dataSetThreeLabel.Name = "dataSetThreeLabel";
            this.dataSetThreeLabel.Size = new System.Drawing.Size(72, 16);
            this.dataSetThreeLabel.TabIndex = 6;
            this.dataSetThreeLabel.Text = "Data Set 3:";
            // 
            // fileSaveButton
            // 
            this.fileSaveButton.Location = new System.Drawing.Point(1581, 793);
            this.fileSaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileSaveButton.Name = "fileSaveButton";
            this.fileSaveButton.Size = new System.Drawing.Size(75, 23);
            this.fileSaveButton.TabIndex = 21;
            this.fileSaveButton.Text = "Save Run";
            this.fileSaveButton.UseVisualStyleBackColor = true;
            this.fileSaveButton.Click += new System.EventHandler(this.fileSaveButton_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(1269, 795);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(72, 16);
            this.fileNameLabel.TabIndex = 20;
            this.fileNameLabel.Text = "File Name:";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(880, 795);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(62, 16);
            this.filePathLabel.TabIndex = 19;
            this.filePathLabel.Text = "File Path:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(1351, 793);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(209, 22);
            this.fileNameTextBox.TabIndex = 18;
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(948, 793);
            this.filePathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(300, 22);
            this.filePathTextBox.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.xLabelThree);
            this.panel1.Controls.Add(this.xLabelTwo);
            this.panel1.Controls.Add(this.xLabelOne);
            this.panel1.Controls.Add(this.dataSetThreeScaleTextBox);
            this.panel1.Controls.Add(this.dataSetTwoScaleTextBox);
            this.panel1.Controls.Add(this.dataSetOneScaleTextBox);
            this.panel1.Controls.Add(this.scaleLabel);
            this.panel1.Controls.Add(this.dataSetOneLabel);
            this.panel1.Controls.Add(this.dataSetOneComboBox);
            this.panel1.Controls.Add(this.dataSetTwoComboBox);
            this.panel1.Controls.Add(this.dataSetThreeComboBox);
            this.panel1.Controls.Add(this.dataSetTwoLabel);
            this.panel1.Controls.Add(this.dataSetThreeLabel);
            this.panel1.Location = new System.Drawing.Point(929, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 220);
            this.panel1.TabIndex = 22;
            // 
            // xLabelThree
            // 
            this.xLabelThree.AutoSize = true;
            this.xLabelThree.Location = new System.Drawing.Point(179, 178);
            this.xLabelThree.Name = "xLabelThree";
            this.xLabelThree.Size = new System.Drawing.Size(13, 16);
            this.xLabelThree.TabIndex = 24;
            this.xLabelThree.Text = "x";
            // 
            // xLabelTwo
            // 
            this.xLabelTwo.AutoSize = true;
            this.xLabelTwo.Location = new System.Drawing.Point(179, 103);
            this.xLabelTwo.Name = "xLabelTwo";
            this.xLabelTwo.Size = new System.Drawing.Size(13, 16);
            this.xLabelTwo.TabIndex = 27;
            this.xLabelTwo.Text = "x";
            // 
            // xLabelOne
            // 
            this.xLabelOne.AutoSize = true;
            this.xLabelOne.Location = new System.Drawing.Point(179, 27);
            this.xLabelOne.Name = "xLabelOne";
            this.xLabelOne.Size = new System.Drawing.Size(13, 16);
            this.xLabelOne.TabIndex = 23;
            this.xLabelOne.Text = "x";
            // 
            // dataSetThreeScaleTextBox
            // 
            this.dataSetThreeScaleTextBox.Location = new System.Drawing.Point(139, 175);
            this.dataSetThreeScaleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataSetThreeScaleTextBox.Name = "dataSetThreeScaleTextBox";
            this.dataSetThreeScaleTextBox.Size = new System.Drawing.Size(33, 22);
            this.dataSetThreeScaleTextBox.TabIndex = 26;
            this.dataSetThreeScaleTextBox.Text = "1";
            this.dataSetThreeScaleTextBox.Validated += new System.EventHandler(this.dataSetThreeScaleTextBox_Validated);
            // 
            // dataSetTwoScaleTextBox
            // 
            this.dataSetTwoScaleTextBox.Location = new System.Drawing.Point(139, 100);
            this.dataSetTwoScaleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataSetTwoScaleTextBox.Name = "dataSetTwoScaleTextBox";
            this.dataSetTwoScaleTextBox.Size = new System.Drawing.Size(33, 22);
            this.dataSetTwoScaleTextBox.TabIndex = 25;
            this.dataSetTwoScaleTextBox.Text = "1";
            this.dataSetTwoScaleTextBox.Validated += new System.EventHandler(this.dataSetTwoScaleTextBox_Validated);
            // 
            // dataSetOneScaleTextBox
            // 
            this.dataSetOneScaleTextBox.Location = new System.Drawing.Point(139, 25);
            this.dataSetOneScaleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataSetOneScaleTextBox.Name = "dataSetOneScaleTextBox";
            this.dataSetOneScaleTextBox.Size = new System.Drawing.Size(33, 22);
            this.dataSetOneScaleTextBox.TabIndex = 24;
            this.dataSetOneScaleTextBox.Text = "1";
            this.dataSetOneScaleTextBox.Validated += new System.EventHandler(this.dataSetOneScaleTextBox_Validated);
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(144, 4);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(42, 16);
            this.scaleLabel.TabIndex = 23;
            this.scaleLabel.Text = "Scale";
            // 
            // sendGain
            // 
            this.sendGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendGain.Location = new System.Drawing.Point(171, 350);
            this.sendGain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendGain.Name = "sendGain";
            this.sendGain.Size = new System.Drawing.Size(143, 47);
            this.sendGain.TabIndex = 77;
            this.sendGain.Text = "Send";
            this.sendGain.UseVisualStyleBackColor = true;
            this.sendGain.Click += new System.EventHandler(this.sendGain_Click);
            // 
            // targetRPMTextBox
            // 
            this.targetRPMTextBox.Location = new System.Drawing.Point(180, 89);
            this.targetRPMTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.targetRPMTextBox.Name = "targetRPMTextBox";
            this.targetRPMTextBox.Size = new System.Drawing.Size(132, 22);
            this.targetRPMTextBox.TabIndex = 75;
            this.targetRPMTextBox.Text = "1400";
            // 
            // setTargetRPMLabel
            // 
            this.setTargetRPMLabel.AutoSize = true;
            this.setTargetRPMLabel.Location = new System.Drawing.Point(56, 92);
            this.setTargetRPMLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.setTargetRPMLabel.Name = "setTargetRPMLabel";
            this.setTargetRPMLabel.Size = new System.Drawing.Size(106, 16);
            this.setTargetRPMLabel.TabIndex = 74;
            this.setTargetRPMLabel.Text = "Set Target RPM:";
            // 
            // PIDGainSaveButton
            // 
            this.PIDGainSaveButton.Location = new System.Drawing.Point(341, 415);
            this.PIDGainSaveButton.Margin = new System.Windows.Forms.Padding(4);
            this.PIDGainSaveButton.Name = "PIDGainSaveButton";
            this.PIDGainSaveButton.Size = new System.Drawing.Size(161, 33);
            this.PIDGainSaveButton.TabIndex = 72;
            this.PIDGainSaveButton.Text = "Save PID Gain";
            this.PIDGainSaveButton.UseVisualStyleBackColor = true;
            this.PIDGainSaveButton.Click += new System.EventHandler(this.PIDGainSaveButton_Click);
            // 
            // kDValueLabel
            // 
            this.kDValueLabel.AutoSize = true;
            this.kDValueLabel.Location = new System.Drawing.Point(1536, 309);
            this.kDValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kDValueLabel.Name = "kDValueLabel";
            this.kDValueLabel.Size = new System.Drawing.Size(51, 16);
            this.kDValueLabel.TabIndex = 71;
            this.kDValueLabel.Text = "D Gain:";
            // 
            // kDValueTextBox
            // 
            this.kDValueTextBox.Location = new System.Drawing.Point(1597, 305);
            this.kDValueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kDValueTextBox.Name = "kDValueTextBox";
            this.kDValueTextBox.Size = new System.Drawing.Size(36, 22);
            this.kDValueTextBox.TabIndex = 70;
            this.kDValueTextBox.Text = "0";
            this.kDValueTextBox.Validated += new System.EventHandler(this.kDValueTextBox_Validated);
            // 
            // kDMaxTextBox
            // 
            this.kDMaxTextBox.Location = new System.Drawing.Point(1457, 305);
            this.kDMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kDMaxTextBox.Name = "kDMaxTextBox";
            this.kDMaxTextBox.Size = new System.Drawing.Size(60, 22);
            this.kDMaxTextBox.TabIndex = 69;
            this.kDMaxTextBox.Text = "10";
            this.kDMaxTextBox.Validated += new System.EventHandler(this.kDMaxTextBox_Validated);
            // 
            // kDMinTextBox
            // 
            this.kDMinTextBox.Location = new System.Drawing.Point(1155, 305);
            this.kDMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kDMinTextBox.Name = "kDMinTextBox";
            this.kDMinTextBox.Size = new System.Drawing.Size(60, 22);
            this.kDMinTextBox.TabIndex = 68;
            this.kDMinTextBox.Text = "0";
            this.kDMinTextBox.Validated += new System.EventHandler(this.kDMinTextBox_Validated);
            // 
            // kDTrackBar
            // 
            this.kDTrackBar.Location = new System.Drawing.Point(1224, 305);
            this.kDTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.kDTrackBar.Maximum = 1000;
            this.kDTrackBar.Name = "kDTrackBar";
            this.kDTrackBar.Size = new System.Drawing.Size(225, 56);
            this.kDTrackBar.TabIndex = 67;
            this.kDTrackBar.TickFrequency = 100;
            this.kDTrackBar.Scroll += new System.EventHandler(this.kDTrackBar_Scroll);
            // 
            // kIValueLabel
            // 
            this.kIValueLabel.AutoSize = true;
            this.kIValueLabel.Location = new System.Drawing.Point(1536, 245);
            this.kIValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kIValueLabel.Name = "kIValueLabel";
            this.kIValueLabel.Size = new System.Drawing.Size(44, 16);
            this.kIValueLabel.TabIndex = 66;
            this.kIValueLabel.Text = "I Gain:";
            // 
            // kIValueTextBox
            // 
            this.kIValueTextBox.Location = new System.Drawing.Point(1597, 240);
            this.kIValueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kIValueTextBox.Name = "kIValueTextBox";
            this.kIValueTextBox.Size = new System.Drawing.Size(36, 22);
            this.kIValueTextBox.TabIndex = 65;
            this.kIValueTextBox.Text = "0";
            this.kIValueTextBox.Validated += new System.EventHandler(this.kIValueTextBox_Validated);
            // 
            // kIMaxTextBox
            // 
            this.kIMaxTextBox.Location = new System.Drawing.Point(1457, 240);
            this.kIMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kIMaxTextBox.Name = "kIMaxTextBox";
            this.kIMaxTextBox.Size = new System.Drawing.Size(60, 22);
            this.kIMaxTextBox.TabIndex = 64;
            this.kIMaxTextBox.Text = "10";
            this.kIMaxTextBox.Validated += new System.EventHandler(this.kIMaxTextBox_Validated);
            // 
            // kIMinTextBox
            // 
            this.kIMinTextBox.Location = new System.Drawing.Point(1155, 240);
            this.kIMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kIMinTextBox.Name = "kIMinTextBox";
            this.kIMinTextBox.Size = new System.Drawing.Size(60, 22);
            this.kIMinTextBox.TabIndex = 63;
            this.kIMinTextBox.Text = "0";
            this.kIMinTextBox.Validated += new System.EventHandler(this.kIMinTextBox_Validated);
            // 
            // kITrackBar
            // 
            this.kITrackBar.Location = new System.Drawing.Point(1224, 240);
            this.kITrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.kITrackBar.Maximum = 1000;
            this.kITrackBar.Name = "kITrackBar";
            this.kITrackBar.Size = new System.Drawing.Size(225, 56);
            this.kITrackBar.TabIndex = 62;
            this.kITrackBar.TickFrequency = 100;
            this.kITrackBar.Scroll += new System.EventHandler(this.kITrackBar_Scroll);
            // 
            // PAULabel
            // 
            this.PAULabel.AutoSize = true;
            this.PAULabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAULabel.Location = new System.Drawing.Point(136, 18);
            this.PAULabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PAULabel.Name = "PAULabel";
            this.PAULabel.Size = new System.Drawing.Size(281, 62);
            this.PAULabel.TabIndex = 61;
            this.PAULabel.Text = "Power Absorbtion \r\nUnit (PAU) Calibration\r\n";
            this.PAULabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // kPValueLabel
            // 
            this.kPValueLabel.AutoSize = true;
            this.kPValueLabel.Location = new System.Drawing.Point(1536, 182);
            this.kPValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kPValueLabel.Name = "kPValueLabel";
            this.kPValueLabel.Size = new System.Drawing.Size(50, 16);
            this.kPValueLabel.TabIndex = 60;
            this.kPValueLabel.Text = "P Gain:";
            // 
            // kPValueTextBox
            // 
            this.kPValueTextBox.Location = new System.Drawing.Point(1597, 178);
            this.kPValueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kPValueTextBox.Name = "kPValueTextBox";
            this.kPValueTextBox.Size = new System.Drawing.Size(36, 22);
            this.kPValueTextBox.TabIndex = 59;
            this.kPValueTextBox.Text = "0";
            this.kPValueTextBox.Validated += new System.EventHandler(this.kPValueTextBox_Validated);
            // 
            // kPMaxTextBox
            // 
            this.kPMaxTextBox.Location = new System.Drawing.Point(1457, 178);
            this.kPMaxTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kPMaxTextBox.Name = "kPMaxTextBox";
            this.kPMaxTextBox.Size = new System.Drawing.Size(60, 22);
            this.kPMaxTextBox.TabIndex = 58;
            this.kPMaxTextBox.Text = "10";
            this.kPMaxTextBox.Validated += new System.EventHandler(this.kPMaxTextBox_Validated);
            // 
            // kPMinTextBox
            // 
            this.kPMinTextBox.Location = new System.Drawing.Point(1155, 178);
            this.kPMinTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.kPMinTextBox.Name = "kPMinTextBox";
            this.kPMinTextBox.Size = new System.Drawing.Size(60, 22);
            this.kPMinTextBox.TabIndex = 57;
            this.kPMinTextBox.Text = "0";
            this.kPMinTextBox.Validated += new System.EventHandler(this.kPMinTextBox_Validated);
            // 
            // kPTrackBar
            // 
            this.kPTrackBar.Location = new System.Drawing.Point(1224, 178);
            this.kPTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.kPTrackBar.Maximum = 1000;
            this.kPTrackBar.Name = "kPTrackBar";
            this.kPTrackBar.Size = new System.Drawing.Size(225, 56);
            this.kPTrackBar.TabIndex = 56;
            this.kPTrackBar.TickFrequency = 100;
            this.kPTrackBar.Scroll += new System.EventHandler(this.kPTrackBar_Scroll);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.sendTargetRPMButton);
            this.panel2.Controls.Add(this.sendGain);
            this.panel2.Controls.Add(this.PIDGainSaveButton);
            this.panel2.Controls.Add(this.PAULabel);
            this.panel2.Controls.Add(this.setTargetRPMLabel);
            this.panel2.Controls.Add(this.targetRPMTextBox);
            this.panel2.Location = new System.Drawing.Point(1135, 31);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(509, 454);
            this.panel2.TabIndex = 78;
            // 
            // sendTargetRPMButton
            // 
            this.sendTargetRPMButton.Location = new System.Drawing.Point(321, 86);
            this.sendTargetRPMButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendTargetRPMButton.Name = "sendTargetRPMButton";
            this.sendTargetRPMButton.Size = new System.Drawing.Size(161, 30);
            this.sendTargetRPMButton.TabIndex = 78;
            this.sendTargetRPMButton.Text = "Send Target RPM";
            this.sendTargetRPMButton.UseVisualStyleBackColor = true;
            this.sendTargetRPMButton.Click += new System.EventHandler(this.sendTargetRPMButton_Click);
            // 
            // RPMLabel
            // 
            this.RPMLabel.AutoSize = true;
            this.RPMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPMLabel.Location = new System.Drawing.Point(45, 635);
            this.RPMLabel.Name = "RPMLabel";
            this.RPMLabel.Size = new System.Drawing.Size(180, 69);
            this.RPMLabel.TabIndex = 79;
            this.RPMLabel.Text = "RPM:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 635);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 69);
            this.label1.TabIndex = 80;
            this.label1.Text = "Torque:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(557, 635);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 69);
            this.label2.TabIndex = 81;
            this.label2.Text = "PID Output:\r\n";
            // 
            // currentRPMLabel
            // 
            this.currentRPMLabel.AutoSize = true;
            this.currentRPMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRPMLabel.Location = new System.Drawing.Point(45, 705);
            this.currentRPMLabel.Name = "currentRPMLabel";
            this.currentRPMLabel.Size = new System.Drawing.Size(162, 69);
            this.currentRPMLabel.TabIndex = 82;
            this.currentRPMLabel.Text = "1400";
            // 
            // currentTorqueLabel
            // 
            this.currentTorqueLabel.AutoSize = true;
            this.currentTorqueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTorqueLabel.Location = new System.Drawing.Point(323, 705);
            this.currentTorqueLabel.Name = "currentTorqueLabel";
            this.currentTorqueLabel.Size = new System.Drawing.Size(146, 69);
            this.currentTorqueLabel.TabIndex = 83;
            this.currentTorqueLabel.Text = "46.2";
            // 
            // currentPIDOutputLabel
            // 
            this.currentPIDOutputLabel.AutoSize = true;
            this.currentPIDOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPIDOutputLabel.Location = new System.Drawing.Point(631, 705);
            this.currentPIDOutputLabel.Name = "currentPIDOutputLabel";
            this.currentPIDOutputLabel.Size = new System.Drawing.Size(129, 69);
            this.currentPIDOutputLabel.TabIndex = 84;
            this.currentPIDOutputLabel.Text = "255";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(37, 625);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(235, 150);
            this.panel3.TabIndex = 85;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(875, 784);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(789, 38);
            this.panel4.TabIndex = 87;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(279, 625);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(263, 150);
            this.panel5.TabIndex = 88;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(548, 625);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(399, 150);
            this.panel6.TabIndex = 89;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM7";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // applyBrakeButton
            // 
            this.applyBrakeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyBrakeButton.Location = new System.Drawing.Point(520, 510);
            this.applyBrakeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applyBrakeButton.Name = "applyBrakeButton";
            this.applyBrakeButton.Size = new System.Drawing.Size(215, 97);
            this.applyBrakeButton.TabIndex = 92;
            this.applyBrakeButton.Text = "Apply Brake";
            this.applyBrakeButton.UseVisualStyleBackColor = true;
            this.applyBrakeButton.Click += new System.EventHandler(this.applyBrakeButton_Click);
            // 
            // chartRefreshButton
            // 
            this.chartRefreshButton.Location = new System.Drawing.Point(836, 490);
            this.chartRefreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartRefreshButton.Name = "chartRefreshButton";
            this.chartRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.chartRefreshButton.TabIndex = 91;
            this.chartRefreshButton.Text = "Refresh";
            this.chartRefreshButton.UseVisualStyleBackColor = true;
            this.chartRefreshButton.Click += new System.EventHandler(this.chartRefreshButton_Click);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(161, 510);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(215, 97);
            this.startButton.TabIndex = 90;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.SerialMonitorOutputLabel);
            this.panel7.Controls.Add(this.SerialMonitorLabel);
            this.panel7.Location = new System.Drawing.Point(55, 784);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1375, 38);
            this.panel7.TabIndex = 88;
            // 
            // SerialMonitorOutputLabel
            // 
            this.SerialMonitorOutputLabel.AutoSize = true;
            this.SerialMonitorOutputLabel.Location = new System.Drawing.Point(102, 11);
            this.SerialMonitorOutputLabel.Name = "SerialMonitorOutputLabel";
            this.SerialMonitorOutputLabel.Size = new System.Drawing.Size(30, 16);
            this.SerialMonitorOutputLabel.TabIndex = 1;
            this.SerialMonitorOutputLabel.Text = "N/A";
            // 
            // SerialMonitorLabel
            // 
            this.SerialMonitorLabel.AutoSize = true;
            this.SerialMonitorLabel.Location = new System.Drawing.Point(4, 10);
            this.SerialMonitorLabel.Name = "SerialMonitorLabel";
            this.SerialMonitorLabel.Size = new System.Drawing.Size(92, 16);
            this.SerialMonitorLabel.TabIndex = 0;
            this.SerialMonitorLabel.Text = "Serial Monitor:";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1669, 827);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.applyBrakeButton);
            this.Controls.Add(this.chartRefreshButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.currentPIDOutputLabel);
            this.Controls.Add(this.currentTorqueLabel);
            this.Controls.Add(this.currentRPMLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RPMLabel);
            this.Controls.Add(this.kDValueLabel);
            this.Controls.Add(this.kDValueTextBox);
            this.Controls.Add(this.kDMaxTextBox);
            this.Controls.Add(this.kDMinTextBox);
            this.Controls.Add(this.kDTrackBar);
            this.Controls.Add(this.kIValueLabel);
            this.Controls.Add(this.kIValueTextBox);
            this.Controls.Add(this.kIMaxTextBox);
            this.Controls.Add(this.kIMinTextBox);
            this.Controls.Add(this.kITrackBar);
            this.Controls.Add(this.kPValueLabel);
            this.Controls.Add(this.kPValueTextBox);
            this.Controls.Add(this.kPMaxTextBox);
            this.Controls.Add(this.kPMinTextBox);
            this.Controls.Add(this.kPTrackBar);
            this.Controls.Add(this.fileSaveButton);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.PIDChart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.PIDChart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kDTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kITrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kPTrackBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart PIDChart;
        private System.Windows.Forms.ComboBox dataSetOneComboBox;
        private System.Windows.Forms.ComboBox dataSetTwoComboBox;
        private System.Windows.Forms.ComboBox dataSetThreeComboBox;
        private System.Windows.Forms.Label dataSetOneLabel;
        private System.Windows.Forms.Label dataSetTwoLabel;
        private System.Windows.Forms.Label dataSetThreeLabel;
        private System.Windows.Forms.Button fileSaveButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox dataSetThreeScaleTextBox;
        private System.Windows.Forms.TextBox dataSetTwoScaleTextBox;
        private System.Windows.Forms.TextBox dataSetOneScaleTextBox;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.Label xLabelThree;
        private System.Windows.Forms.Label xLabelTwo;
        private System.Windows.Forms.Label xLabelOne;
        private System.Windows.Forms.Button sendGain;
        private System.Windows.Forms.TextBox targetRPMTextBox;
        private System.Windows.Forms.Label setTargetRPMLabel;
        private System.Windows.Forms.Button PIDGainSaveButton;
        private System.Windows.Forms.Label kDValueLabel;
        private System.Windows.Forms.TextBox kDValueTextBox;
        private System.Windows.Forms.TextBox kDMaxTextBox;
        private System.Windows.Forms.TextBox kDMinTextBox;
        private System.Windows.Forms.TrackBar kDTrackBar;
        private System.Windows.Forms.Label kIValueLabel;
        private System.Windows.Forms.TextBox kIValueTextBox;
        private System.Windows.Forms.TextBox kIMaxTextBox;
        private System.Windows.Forms.TextBox kIMinTextBox;
        private System.Windows.Forms.TrackBar kITrackBar;
        private System.Windows.Forms.Label PAULabel;
        private System.Windows.Forms.Label kPValueLabel;
        private System.Windows.Forms.TextBox kPValueTextBox;
        private System.Windows.Forms.TextBox kPMaxTextBox;
        private System.Windows.Forms.TextBox kPMinTextBox;
        private System.Windows.Forms.TrackBar kPTrackBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label RPMLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentRPMLabel;
        private System.Windows.Forms.Label currentTorqueLabel;
        private System.Windows.Forms.Label currentPIDOutputLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button applyBrakeButton;
        private System.Windows.Forms.Button chartRefreshButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button sendTargetRPMButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label SerialMonitorOutputLabel;
        private System.Windows.Forms.Label SerialMonitorLabel;
        private System.Windows.Forms.Timer timer1;
    }
}