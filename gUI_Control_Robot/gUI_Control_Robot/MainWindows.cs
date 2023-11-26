using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace gUI_Control_Robot
{
    public partial class MainWindows : Form
    {
        private int degree1;
        private int degree2;
        private int degree3;
        private int degree4;
        private int x, y, z;
        private int t1;
        private int t2;
        private int t3;
        private int t4;

        public int T1 { set { t1 = value; } get { return Convert.ToInt32(label_Base.Text); } }
        public int T2 { set { t2 = value; } get { return Convert.ToInt32(label_J1.Text); } }
        public int T3 { set { t3 = value; } get { return Convert.ToInt32(label_J2.Text); } }
        public int T4 { set { t4 = value; } get { return Convert.ToInt32(label_J3.Text); } }

        public double XValue { get { return Convert.ToDouble(txtBox_X.Text); } }
        public double YValue { get { return Convert.ToDouble(txtBox_Y.Text); } }
        public double ZValue { get { return Convert.ToDouble(txtBox_Z.Text); } }

        public double L0 { get { return 63; } }
        public double L2 { get { return 120; } }
        public double L4 { get { return 125; } }
        public double L5 { get { return 125; } }
        public double L6 { get { return 80; } }
        public double L { get { return 250; } }
        public double Theta234 { get { return 0; } }

        public MainWindows()
        {
            InitializeComponent();
            degree1 = 0;
            degree2 = 0;
            degree3 = 0;
            degree4 = 0;
            x = 100;
            y = 100;
            z = 100;
        }
//----------------------------------------------------------------------------------------------------------------------------------
        private void update_indexLabel()
        {
            step_Base.Text = "9";
            step_J1.Text = "9";
            step_J2.Text = "9";
            step_J3.Text = "9";

            label_Base.Text = "0";
            label_J1.Text = "0";
            label_J2.Text = "0";
            label_J3.Text = "0";

            label_X.Text = "100";
            label_Y.Text = "100";
            label_Z.Text = "100";
        }
//--------------------------------------------------------------------------------------------------------------------------------------------
        private void UpdateProgressBar(ProgressBar progressBar, int value, int max, string motorCode)
        {
            try
            {
                progressBar.Maximum = max;
                progressBar.Value = value;

                if (serialPort1.IsOpen && !checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(value + motorCode + "\n");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateDegreeAndForwardKinematics(int step, ProgressBar progressBar1, ProgressBar progressBar2, Label label, int degree, ref int targetDegree, int min, int max, string motorCode)
        {
            try
            {
                // Update the target degree with the step
                targetDegree += step;
                degree = targetDegree;
                int targetDegree1 = 0;
                int targetDegree2 = 0;

                // Calculate the forward kinematics using the updated target degree
                double newX, newY, newZ;
                forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                // Round the calculated values for better display
                newX = Math.Round(newX, 2);
                newY = Math.Round(newY, 2);
                newZ = Math.Round(newZ, 2);

                // Update the corresponding labels with the calculated values
                label_X.Text = newX.ToString();
                label_Y.Text = newY.ToString();
                label_Z.Text = newZ.ToString();

                // Update the progress bar and label for the specific
                if(targetDegree >= 0)
                {
                    if (targetDegree > max) targetDegree = max;
                    targetDegree1 = targetDegree;
                    UpdateProgressBar(progressBar1, targetDegree1, max, motorCode);
                    targetDegree2 = 0;
                    progressBar2.Value = targetDegree2;
                }
                else
                {
                    if (targetDegree < min) targetDegree = min;
                    targetDegree2 = targetDegree;
                    UpdateProgressBar(progressBar2, Math.Abs(targetDegree2), Math.Abs(min), motorCode);
                    targetDegree1 = 0;
                    progressBar1.Value = targetDegree1;
                }
                label.Text = targetDegree.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void update_ProgreesBarIndex()
        {
            //Base
            progressBar_Base1.Minimum = 0;
            progressBar_Base1.Maximum = 90;
            progressBar_Base2.Value = degree1;

            progressBar_Base2.Minimum = 0;
            progressBar_Base2.Maximum = 90;
            progressBar_Base1.Value = degree1;


            //J1
            progressBar_J1_1.Minimum = 0;
            progressBar_J1_1.Maximum = 135;
            progressBar_J1_1.Value = degree2;

            progressBar_J1_2.Minimum = 0;
            progressBar_J1_2.Maximum = 45;
            progressBar_J1_2.Value = degree2;

            //J2
            progressBar_J2_1.Minimum = 0;
            progressBar_J2_1.Maximum = 120;
            progressBar_J2_1.Value = degree3;

            progressBar_J2_2.Minimum = 0;
            progressBar_J2_2.Maximum = 90;
            progressBar_J2_2.Value = degree3;

            //J3
            progressBar_J3_1.Minimum = 0;
            progressBar_J3_1.Maximum = 135;
            progressBar_J3_1.Value = degree4;

            progressBar_J3_2.Minimum = 0;
            progressBar_J3_2.Maximum = 135;
            progressBar_J3_2.Value = degree4;
        }
        private void update_Label()
        {
            label_Base.Text = degree1.ToString();
            label_J1.Text = degree2.ToString();
            label_J2.Text = degree3.ToString();
            label_J3.Text = degree4.ToString();
        }
        public void UpdateAngles(int t1, int t2, int t3, int t4)
        {
            this.T1 = t1;
            this.T2 = t2;
            this.T3 = t3;
            this.T4 = t4;

            degree1 = t1;
            degree2 = t2;
            degree3 = t3;
            degree4 = t4;
            update_ProgreesBarIndex();
            update_Label();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            degree1 = 0;
            degree2 = 0;
            degree3 = 0;
            degree4 = 0;
            groupBox_Forward.Enabled = false;
            groupBox_Inverse.Enabled = false;
            groupBox_gripper.Enabled = false;
            groupBox_Graph.Enabled = false;
            btn_stop_program.Enabled = false;
            btn_setHome.Enabled = false;

            btn_run_program.Enabled = true;
            update_ProgreesBarIndex();
            update_indexLabel();
        }
        private void comboBox_portList_DropDown(object sender, EventArgs e)
        {
            string[] portlists = SerialPort.GetPortNames();
            comboBox_portList.Items.Clear();
            comboBox_portList.Items.AddRange(portlists);
        }

        private void btn_run_program_Click(object sender, EventArgs e)
        {
            try
            {
                degree1 = 0;
                degree2 = 0;
                degree3 = 0;
                degree4 = 0;
                serialPort1.PortName = comboBox_portList.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_baudRate.Text);
                serialPort1.Open();

                MessageBox.Show("Success Connected to Robot");
                groupBox_Forward.Enabled = true;
                groupBox_Inverse.Enabled = true;
                groupBox_gripper.Enabled = true;
                groupBox_Graph.Enabled = true;
                btn_stop_program.Enabled = true;
                btn_setHome.Enabled = true;

                btn_run_program.Enabled = false;

                update_indexLabel();
                update_ProgreesBarIndex();
            
                if (!checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(degree1 + "A" + "\n");
                    serialPort1.Write(degree2 + "B" + "\n");
                    serialPort1.Write(degree3 + "C" + "\n");
                    serialPort1.Write(degree4 + "D" + "\n");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_stop_program_Click(object sender, EventArgs e)
        {
            try
            {
                if(serialPort1.IsOpen)
                {
                    /*degree1 = 0;
                    degree2 = degree3 = degree4 = 0;

                    if (!checkBox_simultaneous.Checked)
                    {
                        serialPort1.Write(degree1 + "A" + "\n");
                        serialPort1.Write(degree2 + "B" + "\n");
                        serialPort1.Write(degree3 + "C" + "\n");
                        serialPort1.Write(degree4 + "D" + "\n");
                    }*/
                    
                    serialPort1.Close();

                    MessageBox.Show("Disconnected to Robot");
                    groupBox_Forward.Enabled = false;
                    groupBox_Inverse.Enabled = false;
                    groupBox_gripper.Enabled = false;
                    groupBox_Graph.Enabled = false;
                    btn_stop_program.Enabled = false;
                    btn_setHome.Enabled = false;

                    btn_run_program.Enabled = true;

                    // group Forward
                    // progessBar
                    //update_ProgreesBarIndex();
                    //label
                    //update_indexLabel();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_plus_Base_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_Base.Text != null)
                {
                    int step = Convert.ToInt32(step_Base.Text);
                    UpdateDegreeAndForwardKinematics(step, progressBar_Base1, progressBar_Base2, label_Base, degree1, ref degree1, -90, 90, "A");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_sub_Base_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_Base.Text != null)
                {
                    int step = Convert.ToInt32(step_Base.Text);
                    UpdateDegreeAndForwardKinematics(-step, progressBar_Base1, progressBar_Base2, label_Base, degree1, ref degree1, -90, 90, "A");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }  

        private void btn_plus_J1_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_J1 != null)
                {
                    int step = Convert.ToInt32(step_J1.Text);
                    UpdateDegreeAndForwardKinematics(step, progressBar_J1_1, progressBar_J1_2, label_J1, degree2, ref degree2, -45, 135, "B");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_sub_J1_Click(object sender, EventArgs e)
        {

            try
            {
                if (step_J1 != null)
                {
                    int step = Convert.ToInt32(step_J1.Text);
                    UpdateDegreeAndForwardKinematics(-step, progressBar_J1_1, progressBar_J1_2, label_J1, degree2, ref degree2, -45, 135, "B");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_plus_J2_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_J2 != null)
                {
                    int step = Convert.ToInt32(step_J2.Text);
                    UpdateDegreeAndForwardKinematics(step, progressBar_J2_1, progressBar_J2_2, label_J2, degree3, ref degree3, -90, 120, "C");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_sub_J2_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_J2 != null)
                {
                    int step = Convert.ToInt32(step_J2.Text);
                    UpdateDegreeAndForwardKinematics(-step, progressBar_J2_1, progressBar_J2_2, label_J2, degree3, ref degree3, -90, 120, "C");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_plus_J3_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_J3 != null)
                {
                    int step = Convert.ToInt32(step_J3.Text);
                    UpdateDegreeAndForwardKinematics(step, progressBar_J3_1, progressBar_J3_2, label_J3, degree4, ref degree4, -135, 120, "D");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_sub_J3_Click(object sender, EventArgs e)
        {
            try
            {
                if (step_J3 != null)
                {
                    int step = Convert.ToInt32(step_J3.Text);
                    UpdateDegreeAndForwardKinematics(-step, progressBar_J3_1, progressBar_J3_2, label_J3, degree4, ref degree4, -135, 120, "D");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_close_gripper_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(0 + "E" + "\n");
                }
            }
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                calculateWindows calculateForm = new calculateWindows(this);

                calculateForm.Show();
                label_X.Text = txtBox_X.Text;
                label_Y.Text = txtBox_Y.Text;
                label_Z.Text = txtBox_Z.Text;
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(degree1 + "A" + "\n");
                    serialPort1.Write(degree2 + "B" + "\n");
                    serialPort1.Write(degree3 + "C" + "\n");
                    serialPort1.Write(degree4 + "D" + "\n");
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_Graph_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    GraphMonitor graphFrom = new GraphMonitor(this);
                    graphFrom.Show();

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_setHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(1 + "H" + "\n");
                }


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_open_gripper_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(1 + "E" + "\n");
                }
            }
        }

        private void btn_send_data_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBox_simultaneous.Checked)
                {
                    update_ProgreesBarIndex();

                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    serialPort1.Write(degree1 + "A" + "\n");
                    serialPort1.Write(degree2 + "B" + "\n");
                    serialPort1.Write(degree3 + "C" + "\n");
                    serialPort1.Write(degree4 + "D" + "\n");
                    serialPort1.Write(x + "E" + "\n");
                    serialPort1.Write(y + "F" + "\n");
                    serialPort1.Write(z + "G" + "\n");
                }
            }
        }
    }
}
