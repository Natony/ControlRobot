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
        private int t1Cal, t2Cal, t3Cal, t4Cal;

        private void SetAngle(Label the1, Label the2, Label the3, Label the4)
        {
            t1Cal = Convert.ToInt32(Convert.ToDouble(the1.Text));
            t2Cal = Convert.ToInt32(Convert.ToDouble(the2.Text));
            t3Cal = Convert.ToInt32(Convert.ToDouble(the3.Text));
            t4Cal = Convert.ToInt32(Convert.ToDouble(the4.Text));

        }
        public calculateWindows(MainWindows mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        private void calculateWindows_Load(object sender, EventArgs e)
        {
            try
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
   
                label_S1T1.Text = Math.Round(S1T1, 2).ToString();
                label_S1T2.Text = Math.Round(S1T2, 2).ToString();
                label_S1T3.Text = Math.Round(S1T3, 2).ToString();
                label_S1T4.Text = Math.Round(S1T4, 2).ToString();
                Check1.Text = checkS1.ToString();

                label_S2T1.Text = Math.Round(S2T1, 2).ToString();
                label_S2T2.Text = Math.Round(S2T2, 2).ToString();
                label_S2T3.Text = Math.Round(S2T3, 2).ToString();
                label_S2T4.Text = Math.Round(S2T4, 2).ToString();
                Check2.Text = checkS2.ToString();

                label_S3T1.Text = Math.Round(S3T1, 2).ToString();
                label_S3T2.Text = Math.Round(S3T2, 2).ToString();
                label_S3T3.Text = Math.Round(S3T3, 2).ToString();
                label_S3T4.Text = Math.Round(S3T4, 2).ToString();
                Check3.Text = checkS3.ToString();

                label_S4T1.Text = Math.Round(S4T1, 2).ToString();
                label_S4T2.Text = Math.Round(S4T2, 2).ToString();
                label_S4T3.Text = Math.Round(S4T3, 2).ToString();
                label_S4T4.Text = Math.Round(S4T4, 2).ToString();
                Check4.Text = checkS4.ToString();
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_Move1_Click(object sender, EventArgs e)
        {
            SetAngle(label_S1T1, label_S1T2, label_S1T3, label_S1T4);
            mainForm.UpdateAngles(t1Cal, t2Cal, t3Cal, t4Cal);
        }

        private void btn_Move2_Click(object sender, EventArgs e)
        {
            SetAngle(label_S2T1, label_S2T2, label_S2T3, label_S2T4);
            mainForm.UpdateAngles(t1Cal, t2Cal, t3Cal, t4Cal);
        }

        private void btn_Move3_Click(object sender, EventArgs e)
        {
            SetAngle(label_S3T1, label_S3T2, label_S3T3, label_S3T4);
            mainForm.UpdateAngles(t1Cal, t2Cal, t3Cal, t4Cal);
        }

        private void btn_Move4_Click(object sender, EventArgs e)
        {
            SetAngle(label_S4T1, label_S4T2, label_S4T3, label_S4T4);
            mainForm.UpdateAngles(t1Cal, t2Cal, t3Cal, t4Cal);
        }
    }
}
