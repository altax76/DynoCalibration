namespace DynoCalibration
{
    partial class Form2
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
            this.dynoMenuLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.dynoCalibrationButton = new System.Windows.Forms.Button();
            this.inertiaPullButton = new System.Windows.Forms.Button();
            this.PIDDiagnosticsButton = new System.Windows.Forms.Button();
            this.testPage = new System.Windows.Forms.Button();
            this.coastDownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dynoMenuLabel
            // 
            this.dynoMenuLabel.AutoSize = true;
            this.dynoMenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dynoMenuLabel.Location = new System.Drawing.Point(303, 21);
            this.dynoMenuLabel.Name = "dynoMenuLabel";
            this.dynoMenuLabel.Size = new System.Drawing.Size(184, 38);
            this.dynoMenuLabel.TabIndex = 0;
            this.dynoMenuLabel.Text = "Dyno Menu";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(694, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(94, 42);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dynoCalibrationButton
            // 
            this.dynoCalibrationButton.Location = new System.Drawing.Point(109, 99);
            this.dynoCalibrationButton.Name = "dynoCalibrationButton";
            this.dynoCalibrationButton.Size = new System.Drawing.Size(126, 30);
            this.dynoCalibrationButton.TabIndex = 2;
            this.dynoCalibrationButton.Text = "Dyno Calibration";
            this.dynoCalibrationButton.UseVisualStyleBackColor = true;
            this.dynoCalibrationButton.Click += new System.EventHandler(this.dynoCalibrationButton_Click);
            // 
            // inertiaPullButton
            // 
            this.inertiaPullButton.Location = new System.Drawing.Point(109, 171);
            this.inertiaPullButton.Name = "inertiaPullButton";
            this.inertiaPullButton.Size = new System.Drawing.Size(126, 30);
            this.inertiaPullButton.TabIndex = 3;
            this.inertiaPullButton.Text = "Inertia Pull";
            this.inertiaPullButton.UseVisualStyleBackColor = true;
            this.inertiaPullButton.Click += new System.EventHandler(this.inertiaPullButton_Click);
            // 
            // PIDDiagnosticsButton
            // 
            this.PIDDiagnosticsButton.Location = new System.Drawing.Point(109, 135);
            this.PIDDiagnosticsButton.Name = "PIDDiagnosticsButton";
            this.PIDDiagnosticsButton.Size = new System.Drawing.Size(126, 30);
            this.PIDDiagnosticsButton.TabIndex = 4;
            this.PIDDiagnosticsButton.Text = "PID Diagnostics";
            this.PIDDiagnosticsButton.UseVisualStyleBackColor = true;
            this.PIDDiagnosticsButton.Click += new System.EventHandler(this.PIDDiagnosticsButton_Click);
            // 
            // testPage
            // 
            this.testPage.Location = new System.Drawing.Point(109, 243);
            this.testPage.Name = "testPage";
            this.testPage.Size = new System.Drawing.Size(126, 30);
            this.testPage.TabIndex = 5;
            this.testPage.Text = "Test Page";
            this.testPage.UseVisualStyleBackColor = true;
            this.testPage.Click += new System.EventHandler(this.testPage_Click);
            // 
            // coastDownButton
            // 
            this.coastDownButton.Location = new System.Drawing.Point(109, 207);
            this.coastDownButton.Name = "coastDownButton";
            this.coastDownButton.Size = new System.Drawing.Size(126, 30);
            this.coastDownButton.TabIndex = 6;
            this.coastDownButton.Text = "Coast Down Test";
            this.coastDownButton.UseVisualStyleBackColor = true;
            this.coastDownButton.Click += new System.EventHandler(this.coastDownButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.coastDownButton);
            this.Controls.Add(this.testPage);
            this.Controls.Add(this.PIDDiagnosticsButton);
            this.Controls.Add(this.inertiaPullButton);
            this.Controls.Add(this.dynoCalibrationButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dynoMenuLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dynoMenuLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button dynoCalibrationButton;
        private System.Windows.Forms.Button inertiaPullButton;
        private System.Windows.Forms.Button PIDDiagnosticsButton;
        private System.Windows.Forms.Button testPage;
        private System.Windows.Forms.Button coastDownButton;
    }
}