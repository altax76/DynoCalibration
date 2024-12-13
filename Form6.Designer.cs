namespace DynoCalibration
{
    partial class Form6
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
            this.coastDownStopTextBox = new System.Windows.Forms.TextBox();
            this.coastDownStartTextBox = new System.Windows.Forms.TextBox();
            this.pullStopLabel = new System.Windows.Forms.Label();
            this.pullStartLabel = new System.Windows.Forms.Label();
            this.rollerDiameterTextBox = new System.Windows.Forms.TextBox();
            this.rollerMassTextBox = new System.Windows.Forms.TextBox();
            this.rollerDiameterLabel = new System.Windows.Forms.Label();
            this.rollerMassLabel = new System.Windows.Forms.Label();
            this.wheelToRollerRatioTextBox = new System.Windows.Forms.TextBox();
            this.engineToWheelRatioTextBox = new System.Windows.Forms.TextBox();
            this.wheelToRollerRatioLabel = new System.Windows.Forms.Label();
            this.engineToWheelRatioLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveVehicleData = new System.Windows.Forms.Button();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.currentRPMLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // coastDownStopTextBox
            // 
            this.coastDownStopTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coastDownStopTextBox.Location = new System.Drawing.Point(225, 223);
            this.coastDownStopTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.coastDownStopTextBox.Name = "coastDownStopTextBox";
            this.coastDownStopTextBox.Size = new System.Drawing.Size(100, 34);
            this.coastDownStopTextBox.TabIndex = 38;
            this.coastDownStopTextBox.Validated += new System.EventHandler(this.pullStopTextBox_Validated);
            // 
            // coastDownStartTextBox
            // 
            this.coastDownStartTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coastDownStartTextBox.Location = new System.Drawing.Point(225, 165);
            this.coastDownStartTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.coastDownStartTextBox.Name = "coastDownStartTextBox";
            this.coastDownStartTextBox.Size = new System.Drawing.Size(100, 34);
            this.coastDownStartTextBox.TabIndex = 37;
            this.coastDownStartTextBox.Validated += new System.EventHandler(this.coastDownStartTextBox_Validated);
            // 
            // pullStopLabel
            // 
            this.pullStopLabel.AutoSize = true;
            this.pullStopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pullStopLabel.Location = new System.Drawing.Point(17, 242);
            this.pullStopLabel.Name = "pullStopLabel";
            this.pullStopLabel.Size = new System.Drawing.Size(197, 20);
            this.pullStopLabel.TabIndex = 36;
            this.pullStopLabel.Text = "Coast Down Stop [RPM]:";
            // 
            // pullStartLabel
            // 
            this.pullStartLabel.AutoSize = true;
            this.pullStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pullStartLabel.Location = new System.Drawing.Point(3, 171);
            this.pullStartLabel.Name = "pullStartLabel";
            this.pullStartLabel.Size = new System.Drawing.Size(199, 20);
            this.pullStartLabel.TabIndex = 35;
            this.pullStartLabel.Text = "Coast Down Start [RPM]:";
            // 
            // rollerDiameterTextBox
            // 
            this.rollerDiameterTextBox.Location = new System.Drawing.Point(205, 124);
            this.rollerDiameterTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rollerDiameterTextBox.Name = "rollerDiameterTextBox";
            this.rollerDiameterTextBox.Size = new System.Drawing.Size(100, 22);
            this.rollerDiameterTextBox.TabIndex = 34;
            // 
            // rollerMassTextBox
            // 
            this.rollerMassTextBox.Location = new System.Drawing.Point(205, 92);
            this.rollerMassTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rollerMassTextBox.Name = "rollerMassTextBox";
            this.rollerMassTextBox.Size = new System.Drawing.Size(100, 22);
            this.rollerMassTextBox.TabIndex = 33;
            // 
            // rollerDiameterLabel
            // 
            this.rollerDiameterLabel.AutoSize = true;
            this.rollerDiameterLabel.Location = new System.Drawing.Point(43, 124);
            this.rollerDiameterLabel.Name = "rollerDiameterLabel";
            this.rollerDiameterLabel.Size = new System.Drawing.Size(125, 16);
            this.rollerDiameterLabel.TabIndex = 32;
            this.rollerDiameterLabel.Text = "Roller Diameter [in]:";
            // 
            // rollerMassLabel
            // 
            this.rollerMassLabel.AutoSize = true;
            this.rollerMassLabel.Location = new System.Drawing.Point(43, 92);
            this.rollerMassLabel.Name = "rollerMassLabel";
            this.rollerMassLabel.Size = new System.Drawing.Size(104, 16);
            this.rollerMassLabel.TabIndex = 31;
            this.rollerMassLabel.Text = "Roller Mass [lb]:";
            // 
            // wheelToRollerRatioTextBox
            // 
            this.wheelToRollerRatioTextBox.Location = new System.Drawing.Point(205, 60);
            this.wheelToRollerRatioTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wheelToRollerRatioTextBox.Name = "wheelToRollerRatioTextBox";
            this.wheelToRollerRatioTextBox.Size = new System.Drawing.Size(100, 22);
            this.wheelToRollerRatioTextBox.TabIndex = 30;
            // 
            // engineToWheelRatioTextBox
            // 
            this.engineToWheelRatioTextBox.Location = new System.Drawing.Point(205, 28);
            this.engineToWheelRatioTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.engineToWheelRatioTextBox.Name = "engineToWheelRatioTextBox";
            this.engineToWheelRatioTextBox.Size = new System.Drawing.Size(100, 22);
            this.engineToWheelRatioTextBox.TabIndex = 29;
            // 
            // wheelToRollerRatioLabel
            // 
            this.wheelToRollerRatioLabel.AutoSize = true;
            this.wheelToRollerRatioLabel.Location = new System.Drawing.Point(43, 60);
            this.wheelToRollerRatioLabel.Name = "wheelToRollerRatioLabel";
            this.wheelToRollerRatioLabel.Size = new System.Drawing.Size(137, 16);
            this.wheelToRollerRatioLabel.TabIndex = 28;
            this.wheelToRollerRatioLabel.Text = "Wheel to Roller Ratio:";
            // 
            // engineToWheelRatioLabel
            // 
            this.engineToWheelRatioLabel.AutoSize = true;
            this.engineToWheelRatioLabel.Location = new System.Drawing.Point(43, 28);
            this.engineToWheelRatioLabel.Name = "engineToWheelRatioLabel";
            this.engineToWheelRatioLabel.Size = new System.Drawing.Size(143, 16);
            this.engineToWheelRatioLabel.TabIndex = 27;
            this.engineToWheelRatioLabel.Text = "Engine to Wheel Ratio:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.saveVehicleData);
            this.panel1.Controls.Add(this.pullStartLabel);
            this.panel1.Controls.Add(this.coastDownStartTextBox);
            this.panel1.Controls.Add(this.coastDownStopTextBox);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 358);
            this.panel1.TabIndex = 39;
            // 
            // saveVehicleData
            // 
            this.saveVehicleData.Location = new System.Drawing.Point(99, 297);
            this.saveVehicleData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveVehicleData.Name = "saveVehicleData";
            this.saveVehicleData.Size = new System.Drawing.Size(160, 43);
            this.saveVehicleData.TabIndex = 25;
            this.saveVehicleData.Text = "Save Car Data";
            this.saveVehicleData.UseVisualStyleBackColor = true;
            this.saveVehicleData.Click += new System.EventHandler(this.saveVehicleData_Click);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDataButton.Location = new System.Drawing.Point(1268, 748);
            this.saveDataButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(331, 44);
            this.saveDataButton.TabIndex = 40;
            this.saveDataButton.Text = "Save Coast Down Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // currentRPMLabel
            // 
            this.currentRPMLabel.AutoSize = true;
            this.currentRPMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRPMLabel.Location = new System.Drawing.Point(57, 594);
            this.currentRPMLabel.Name = "currentRPMLabel";
            this.currentRPMLabel.Size = new System.Drawing.Size(393, 91);
            this.currentRPMLabel.TabIndex = 42;
            this.currentRPMLabel.Text = "RPM: N/A";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(761, 578);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(397, 160);
            this.startButton.TabIndex = 41;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM7";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(391, 12);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 5;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "RPM";
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "None";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1208, 519);
            this.chart1.TabIndex = 43;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 805);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.currentRPMLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.pullStopLabel);
            this.Controls.Add(this.rollerDiameterTextBox);
            this.Controls.Add(this.rollerMassTextBox);
            this.Controls.Add(this.rollerDiameterLabel);
            this.Controls.Add(this.rollerMassLabel);
            this.Controls.Add(this.wheelToRollerRatioTextBox);
            this.Controls.Add(this.engineToWheelRatioTextBox);
            this.Controls.Add(this.wheelToRollerRatioLabel);
            this.Controls.Add(this.engineToWheelRatioLabel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form6";
            this.Text = "Form6";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox coastDownStopTextBox;
        private System.Windows.Forms.TextBox coastDownStartTextBox;
        private System.Windows.Forms.Label pullStopLabel;
        private System.Windows.Forms.Label pullStartLabel;
        private System.Windows.Forms.TextBox rollerDiameterTextBox;
        private System.Windows.Forms.TextBox rollerMassTextBox;
        private System.Windows.Forms.Label rollerDiameterLabel;
        private System.Windows.Forms.Label rollerMassLabel;
        private System.Windows.Forms.TextBox wheelToRollerRatioTextBox;
        private System.Windows.Forms.TextBox engineToWheelRatioTextBox;
        private System.Windows.Forms.Label wheelToRollerRatioLabel;
        private System.Windows.Forms.Label engineToWheelRatioLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveVehicleData;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Label currentRPMLabel;
        private System.Windows.Forms.Button startButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}