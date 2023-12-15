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
        private char checkS1, checkS2;
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

                double[,] thetaArray = inverse_Kinematics.CalculateInverseKinematics(xValue, yValue, zValue);


                S1T1 = thetaArray[0, 0];
                S1T2 = thetaArray[0, 1];
                S1T3 = thetaArray[0, 2];
                S1T4 = thetaArray[0, 3];
                S2T1 = thetaArray[1, 0];
                S2T2 = thetaArray[1, 1];
                S2T3 = thetaArray[1, 2];
                S2T4 = thetaArray[1, 3];

   
                label_S1T1.Text = Math.Round(S1T1, 2).ToString();
                label_S1T2.Text = Math.Round(S1T2, 2).ToString();
                label_S1T3.Text = Math.Round(S1T3, 2).ToString();
                label_S1T4.Text = Math.Round(S1T4, 2).ToString();
                checkS1 = check_Forward.CheckForward(S1T1, S1T2, S1T3, S1T4);
                Check1.Text = checkS1.ToString();
                
                label_S2T1.Text = Math.Round(S2T1, 2).ToString();
                label_S2T2.Text = Math.Round(S2T2, 2).ToString();
                label_S2T3.Text = Math.Round(S2T3, 2).ToString();
                label_S2T4.Text = Math.Round(S2T4, 2).ToString();
                checkS2 = check_Forward.CheckForward( S2T1, S2T2, S2T3, S2T4);
                Check2.Text = checkS2.ToString();

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_Move1_Click(object sender, EventArgs e)
        {
            SetAngle(label_S1T1, label_S1T2, label_S1T3, label_S1T4);
            if(checkS1 == 'C')
            {
                mainForm.UpdateAngles(t1Cal, t2Cal, t3Cal, t4Cal);
            }
            else
            {
                MessageBox.Show("The current solution is incorrect. Please choose a correct configuration.");
            }
            
        }

        private void btn_Move2_Click(object sender, EventArgs e)
        {
            SetAngle(label_S2T1, label_S2T2, label_S2T3, label_S2T4);
            if(checkS2 == 'C')
            {
                mainForm.UpdateAngles(t1Cal, t2Cal, t3Cal, t4Cal);
            }
            else
            {
                MessageBox.Show("The current solution is incorrect. Please choose a correct configuration.");
            }
            
        }
    }
}
