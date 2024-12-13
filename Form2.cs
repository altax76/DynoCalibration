using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynoCalibration
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dynoCalibrationButton_Click(object sender, EventArgs e)
        {
                // Create an instance of Form1
                Form1 form1 = new Form1();

                // Handle the FormClosed event of Form1
                form1.FormClosed += (s, args) => this.Show();

                // Show Form1
                form1.Show();

                // Close Form2
                this.Hide();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void inertiaPullButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // Handle the FormClosed event of Form1
            form3.FormClosed += (s, args) => this.Show();

            // Show Form1
            form3.Show();

            // Close Form2
            this.Hide();
        }

        private void PIDDiagnosticsButton_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            // Handle the FormClosed event of Form1
            form4.FormClosed += (s, args) => this.Show();

            // Show Form4
            form4.Show();

            // Close Form2
            this.Hide();
        }

        private void testPage_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            // Handle the FormClosed event of Form1
            form5.FormClosed += (s, args) => this.Show();

            // Show Form4
            form5.Show();

            // Close Form2
            this.Hide();
        }

        private void coastDownButton_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();

            // Handle the FormClosed event of Form1
            form6.FormClosed += (s, args) => this.Show();

            // Show Form6
            form6.Show();

            // Close Form
            this.Hide();
        }
    }
}
