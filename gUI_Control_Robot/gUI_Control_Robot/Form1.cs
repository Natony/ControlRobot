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
    public partial class Form1 : Form
    {
        private int degree1;
        private int degree2;
        private int degree3;
        private int degree4;
        private int x, y, z;

        public Form1()
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
        private void update_Label()
        {
            step_Base.Text = "9";
            step_J1.Text = "9";
            step_J2.Text = "9";
            step_J3.Text = "9";

            label_Base.Text = degree1.ToString();
            label_J1.Text = degree2.ToString();
            label_J2.Text = degree3.ToString();
            label_J3.Text = degree4.ToString();

            label_X.Text = "100";
            label_Y.Text = "100";
            label_Z.Text = "100";
        }
        private void update_ProgreesBar()
        {
            progressBar_Base.Value = degree1;
            progressBar_J1.Value = degree1;
            progressBar_J2.Value = degree1;
            progressBar_J3.Value = degree1;
        }
        private void updateNewProgressBar()
        {
            progressBar_Base.Value = degree1;
            progressBar_J1.Value = degree2;
            progressBar_J2.Value = degree3;
            progressBar_J3.Value = degree4;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox_Forward.Enabled = false;
            groupBox_Inverse.Enabled = false;
            groupBox_gripper.Enabled = false;
            btn_save_position.Enabled = false;
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
                btn_save_position.Enabled = true;
                btn_stop_program.Enabled = true;

                btn_run_program.Enabled = false;

                degree1 = degree2 = degree3 = degree4 = 0;
                update_Label();

                update_ProgreesBar();

                if (!checkBox_simultaneous.Checked)
                {
                    serialPort1.Write(degree1 + "A" + "\n");
                    serialPort1.Write(degree2 + "B" + "\n");
                    serialPort1.Write(degree3 + "C" + "\n");
                    serialPort1.Write(degree4 + "D" + "\n");
                    serialPort1.Write(100 + "E" + "\n");
                    serialPort1.Write(100 + "F" + "\n");
                    serialPort1.Write(100 + "G" + "\n");
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
                    degree1 = degree2 = degree3 = degree4 = 0;

                    if (!checkBox_simultaneous.Checked)
                    {
                        serialPort1.Write(degree1 + "A" + "\n");
                        serialPort1.Write(degree2 + "B" + "\n");
                        serialPort1.Write(degree3 + "C" + "\n");
                        serialPort1.Write(degree4 + "D" + "\n");
                        serialPort1.Write(100 + "E" + "\n");
                        serialPort1.Write(100 + "F" + "\n");
                        serialPort1.Write(100 + "G" + "\n");
                    }
                    serialPort1.Close();

                    MessageBox.Show("Disconnected to Robot");
                    groupBox_Forward.Enabled = false;
                    groupBox_Inverse.Enabled = false;
                    groupBox_gripper.Enabled = false;
                    btn_save_position.Enabled = false;
                    btn_stop_program.Enabled = false;

                    btn_run_program.Enabled = true;

                    // group Forward
                    // progessBar
                    update_ProgreesBar();
                    //label
                    update_Label();
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
                    int i = Convert.ToInt32(step_Base.Text);
                    progressBar_Base.Minimum = 0;
                    progressBar_Base.Maximum = 180;
                    degree1 += i;

                    if (degree1 >= progressBar_Base.Maximum) degree1 = progressBar_Base.Maximum;
                    if (degree1 <= progressBar_Base.Minimum) degree1 = progressBar_Base.Minimum;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //cập nhật giao diện
                    label_Base.Text = degree1.ToString();
                    progressBar_Base.Value = degree1;

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree1 + "A" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_Base.Text);
                    progressBar_Base.Minimum = 0;
                    progressBar_Base.Maximum = 180;
                    degree1 -= i;
                    if (degree1 >= progressBar_Base.Maximum) degree1 = progressBar_Base.Maximum;
                    if (degree1 <= progressBar_Base.Minimum) degree1 = progressBar_Base.Minimum;

                    label_Base.Text = degree1.ToString();
                    progressBar_Base.Value = degree1;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree1 + "A" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_J1.Text);
                    progressBar_J1.Minimum = 0;
                    progressBar_J1.Maximum = 180;
                    degree2 += i;
                    if (degree2 >= progressBar_J1.Maximum) degree2 = progressBar_J1.Maximum;
                    if (degree2 <= progressBar_J1.Minimum) degree2 = progressBar_J1.Minimum;

                    label_J1.Text = degree2.ToString();
                    progressBar_J1.Value = degree2;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree2 + "B" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_J1.Text);
                    progressBar_J1.Minimum = 0;
                    progressBar_J1.Maximum = 180;
                    degree2 -= i;
                    if (degree2 >= progressBar_J1.Maximum) degree2 = progressBar_J1.Maximum;
                    if (degree2 <= progressBar_J1.Minimum) degree2 = progressBar_J1.Minimum;

                    label_J1.Text = degree2.ToString();
                    progressBar_J1.Value = degree2;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree2 + "B" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_J2.Text);
                    progressBar_J2.Minimum = 0;
                    progressBar_J2.Maximum = 180;
                    degree3 += i;
                    if (degree3 >= progressBar_J2.Maximum) degree3 = progressBar_J2.Maximum;
                    if (degree3 <= progressBar_J2.Minimum) degree3 = progressBar_J2.Minimum;

                    label_J2.Text = degree3.ToString();
                    progressBar_J2.Value = degree3;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree3 + "C" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_J2.Text);
                    progressBar_J2.Minimum = 0;
                    progressBar_J2.Maximum = 180;
                    degree3 -= i;
                    if (degree3 >= progressBar_J2.Maximum) degree3 = progressBar_J2.Maximum;
                    if (degree3 <= progressBar_J2.Minimum) degree3 = progressBar_J2.Minimum;

                    label_J2.Text = degree3.ToString();
                    progressBar_J2.Value = degree3;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree3 + "C" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_J3.Text);
                    progressBar_J3.Minimum = 0;
                    progressBar_J3.Maximum = 180;
                    degree4 += i;
                    if (degree4 >= progressBar_J3.Maximum) degree4 = progressBar_J3.Maximum;
                    if (degree4 <= progressBar_J3.Minimum) degree4 = progressBar_J3.Minimum;

                    label_J3.Text = degree4.ToString();
                    progressBar_J3.Value = degree4;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree4 + "D" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
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
                    int i = Convert.ToInt32(step_J3.Text);
                    progressBar_J3.Minimum = 0;
                    progressBar_J3.Maximum = 180;
                    degree4 -= i;
                    if (degree4 >= progressBar_J3.Maximum) degree4 = progressBar_J3.Maximum;
                    if (degree4 <= progressBar_J3.Minimum) degree4 = progressBar_J3.Minimum;

                    label_J3.Text = degree4.ToString();
                    progressBar_J3.Value = degree4;

                    // tính lại x, y, z sử dụng forward kinematics
                    double newX, newY, newZ;
                    forward_Kinematics.CalculateXYZ(degree1, degree2, degree3, degree4, out newX, out newY, out newZ);

                    //Hiển thị x, y, z 
                    label_X.Text = newX.ToString();
                    label_Y.Text = newY.ToString();
                    label_Z.Text = newZ.ToString();

                    if (serialPort1.IsOpen)
                    {
                        if (!checkBox_simultaneous.Checked)
                        {
                            serialPort1.Write(degree4 + "D" + "\n");
                            serialPort1.Write(newX + "E" + "\n");
                            serialPort1.Write(newY + "F" + "\n");
                            serialPort1.Write(newZ + "G" + "\n");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtBox_X != null && txtBox_Y != null && txtBox_Z != null)
                {
                    int x = Convert.ToInt32(txtBox_X.Text);
                    int y = Convert.ToInt32(txtBox_Y.Text);
                    int z = Convert.ToInt32(txtBox_Z.Text);

                    label_X.Text = txtBox_X.Text;
                    label_Y.Text = txtBox_Y.Text;
                    label_Z.Text = txtBox_Z.Text;

                    if (!checkBox_simultaneous.Checked)
                    {
                        serialPort1.Write(x + "E" + "\n");
                        serialPort1.Write(y + "F" + "\n");
                        serialPort1.Write(z + "G" + "\n");
                    }
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
                    updateNewProgressBar();

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
