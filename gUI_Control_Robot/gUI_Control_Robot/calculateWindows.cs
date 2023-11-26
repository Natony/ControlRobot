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

                double l0 = mainForm.L0;
                double l2 = mainForm.L2;
                double l4 = mainForm.L4;
                double l5 = mainForm.L5;
                double l6 = mainForm.L6;
                double l = mainForm.L;
                double theta234 = mainForm.Theta234;

                double S1T1, S1T2, S1T3, S1T4;
                double S2T1, S2T2, S2T3, S2T4;
                double S3T1, S3T2, S3T3, S3T4;
                double S4T1, S4T2, S4T3, S4T4;

                char checkS1, checkS2, checkS3, checkS4;
                double[,] thetaArray = inverse_Kinematics.CalculateInverseKinematics(xValue, xValue, xValue, l0, l2, l4, l5, l6, l, theta234);

                S1T1 = thetaArray[0, 0];
                S1T2 = thetaArray[0, 1];
                S1T3 = thetaArray[0, 2];
                S1T4 = thetaArray[0, 3];
                Console.WriteLine("S1T1: {0}", S1T1);
                S2T1 = thetaArray[1, 0];
                S2T2 = thetaArray[1, 1];
                S2T3 = thetaArray[1, 2];
                S2T4 = thetaArray[1, 3];

                S3T1 = thetaArray[2, 0];
                S3T2 = thetaArray[2, 1];
                S3T3 = thetaArray[2, 2];
                S3T4 = thetaArray[2, 3];

                S4T1 = thetaArray[3, 0];
                S4T2 = thetaArray[3, 1];
                S4T3 = thetaArray[3, 2];
                S4T4 = thetaArray[3, 3];

   
                label_S1T1.Text = Math.Round(S1T1, 2).ToString();
                label_S1T2.Text = Math.Round(S1T2, 2).ToString();
                label_S1T3.Text = Math.Round(S1T3, 2).ToString();
                label_S1T4.Text = Math.Round(S1T4, 2).ToString();
                checkS1 = check_Forward.CheckForward(xValue, yValue, zValue, S1T1, S1T2, S1T3, S1T4);
                Check1.Text = checkS1.ToString();

                label_S2T1.Text = Math.Round(S2T1, 2).ToString();
                label_S2T2.Text = Math.Round(S2T2, 2).ToString();
                label_S2T3.Text = Math.Round(S2T3, 2).ToString();
                label_S2T4.Text = Math.Round(S2T4, 2).ToString();
                checkS2 = check_Forward.CheckForward(xValue, yValue, zValue, S2T1, S2T2, S2T3, S2T4);
                Check2.Text = checkS2.ToString();

                label_S3T1.Text = Math.Round(S3T1, 2).ToString();
                label_S3T2.Text = Math.Round(S3T2, 2).ToString();
                label_S3T3.Text = Math.Round(S3T3, 2).ToString();
                label_S3T4.Text = Math.Round(S3T4, 2).ToString();
                checkS3 = check_Forward.CheckForward(xValue, yValue, zValue, S3T1, S3T2, S3T3, S3T4);
                Check3.Text = checkS3.ToString();

                label_S4T1.Text = Math.Round(S4T1, 2).ToString();
                label_S4T2.Text = Math.Round(S4T2, 2).ToString();
                label_S4T3.Text = Math.Round(S4T3, 2).ToString();
                label_S4T4.Text = Math.Round(S4T4, 2).ToString();
                checkS4 = check_Forward.CheckForward(xValue, yValue, zValue, S4T1, S4T2, S4T3, S4T4);
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
