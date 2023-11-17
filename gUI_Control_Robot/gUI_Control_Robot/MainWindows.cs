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
        public event Action<int, int, int, int> MotorAnglesChanged;

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
        private void UpdateProgressBarAndLabel(ProgressBar progressBar, Label label, int value, int min, int max, string motorCode)
        {
            try
            {
                progressBar.Minimum = min;
                progressBar.Maximum = max;
                progressBar.Value = value;
                label.Text = value.ToString();

                if (serialPort1.IsOpen && !checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(value + motorCode + "\n");
                }
                MotorAnglesChanged?.Invoke(degree1, degree2, degree3, degree4);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateDegreeAndForwardKinematics(int step, ProgressBar progressBar, Label label, int degree, ref int targetDegree, int min, int max, string motorCode)
        {
            try
            {
                // Update the target degree with the step
                targetDegree += step;

                // Ensure the target degree stays within the specified range
                if (targetDegree > max) targetDegree = max;
                if (targetDegree < min) targetDegree = min;

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

                // Update the progress bar and label for the specific motor
                UpdateProgressBarAndLabel(progressBar, label, targetDegree, min, max, motorCode);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void update_ProgreesBar()
        {
            progressBar_Base.Value = degree1;
            progressBar_J1.Value = degree2;
            progressBar_J2.Value = degree3;
            progressBar_J3.Value = degree4;
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
            update_ProgreesBar();
            update_Label();
        }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox_Forward.Enabled = false;
            groupBox_Inverse.Enabled = false;
            groupBox_gripper.Enabled = false;
            groupBox_Graph.Enabled = false;
            btn_stop_program.Enabled = false;

            btn_run_program.Enabled = true;
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
                serialPort1.PortName = comboBox_portList.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_baudRate.Text);
                serialPort1.Open();

                MessageBox.Show("Success Connected to Robot");
                groupBox_Forward.Enabled = true;
                groupBox_Inverse.Enabled = true;
                groupBox_gripper.Enabled = true;
                groupBox_Graph.Enabled = true;
                btn_stop_program.Enabled = true;

                btn_run_program.Enabled = false;

                degree1 = 0;
                degree2 = degree3 = degree4 = 0;
                update_indexLabel();

                update_ProgreesBar();
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
                    degree1 = 0;
                    degree2 = degree3 = degree4 = 0;

                    if (!checkBox_simultaneous.Checked)
                    {
                        serialPort1.Write(degree1 + "A" + "\n");
                        serialPort1.Write(degree2 + "B" + "\n");
                        serialPort1.Write(degree3 + "C" + "\n");
                        serialPort1.Write(degree4 + "D" + "\n");
                    }
                    
                    serialPort1.Close();

                    MessageBox.Show("Disconnected to Robot");
                    groupBox_Forward.Enabled = false;
                    groupBox_Inverse.Enabled = false;
                    groupBox_gripper.Enabled = false;
                    groupBox_Graph.Enabled = false;
                    btn_stop_program.Enabled = false;

                    btn_run_program.Enabled = true;

                    // group Forward
                    // progessBar
                    update_ProgreesBar();
                    //label
                    update_indexLabel();
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
                    UpdateDegreeAndForwardKinematics(step, progressBar_Base, label_Base, degree1, ref degree1, 0, 180, "A");

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
                    UpdateDegreeAndForwardKinematics(-step, progressBar_Base, label_Base, degree1, ref degree1, 0, 180, "A");

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
                    UpdateDegreeAndForwardKinematics(step, progressBar_J1, label_J1, degree2, ref degree2, 0, 500, "B");

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
                    UpdateDegreeAndForwardKinematics(-step, progressBar_J1, label_J1, degree2, ref degree2, 0, 500, "B");

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
                    UpdateDegreeAndForwardKinematics(step, progressBar_J2, label_J2, degree2, ref degree3, 0, 180, "C");

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
                    UpdateDegreeAndForwardKinematics(-step, progressBar_J2, label_J2, degree2, ref degree3, 0, 180, "C");

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
                    UpdateDegreeAndForwardKinematics(step, progressBar_J3, label_J3, degree4, ref degree4, 0, 180, "D");

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
                    UpdateDegreeAndForwardKinematics(-step, progressBar_J3, label_J3, degree4, ref degree4, 0, 180, "D");

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
                    serialPort1.Write(0 + "H" + "\n");
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


        private void btn_open_gripper_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (!checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(1 + "H" + "\n");
                }
            }
        }

        private void btn_send_data_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (checkBox_simultaneous.Checked)
                {
                    update_ProgreesBar();

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
