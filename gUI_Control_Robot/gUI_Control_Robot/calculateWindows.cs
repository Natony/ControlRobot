using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gUI_Control_Robot
{
    public partial class calculateWindows : Form
    {
        private MainWindows mainForm;

        public calculateWindows(MainWindows mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void calculateWindows_Load(object sender, EventArgs e)
        {
            double xValue = mainForm.XValue;
            double yValue = mainForm.YValue;
            double zValue = mainForm.ZValue;

            double S1T1, S1T2, S1T3, S1T4;
            double S2T1, S2T2, S2T3, S2T4;
            double S3T1, S3T2, S3T3, S3T4;
            double S4T1, S4T2, S4T3, S4T4;

            char checkS1, checkS2, checkS3, checkS4;

            inverse_Kinematics.Set1(xValue, yValue, zValue, out S1T1, out S1T2, out S1T3, out S1T4, out checkS1);
            inverse_Kinematics.Set2(xValue, yValue, zValue, out S2T1, out S2T2, out S2T3, out S2T4, out checkS2);
            inverse_Kinematics.Set3(xValue, yValue, zValue, out S3T1, out S3T2, out S3T3, out S3T4, out checkS3);
            inverse_Kinematics.Set4(xValue, yValue, zValue, out S4T1, out S4T2, out S4T3, out S4T4, out checkS4);

            label_S1T1.Text = S1T1.ToString();
            label_S1T2.Text = S1T2.ToString();
            label_S1T3.Text = S1T3.ToString();
            label_S1T4.Text = S1T4.ToString();
            Check1.Text = checkS1.ToString();

            label_S2T1.Text = S2T1.ToString();
            label_S2T2.Text = S2T2.ToString();
            label_S2T3.Text = S2T3.ToString();
            label_S2T4.Text = S2T4.ToString();
            Check2.Text = checkS2.ToString();

            label_S3T1.Text = S3T1.ToString();
            label_S3T2.Text = S3T2.ToString();
            label_S3T3.Text = S3T3.ToString();
            label_S3T4.Text = S3T4.ToString();
            Check3.Text = checkS3.ToString();

            label_S4T1.Text = S4T1.ToString();
            label_S4T2.Text = S4T2.ToString();
            label_S4T3.Text = S4T3.ToString();
            label_S4T4.Text = S4T4.ToString();
            Check4.Text = checkS4.ToString();
        }
    }
}
