
namespace gUI_Control_Robot
{
    partial class MainWindows
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
            this.txtBox_X = new System.Windows.Forms.TextBox();
            this.txtBox_Y = new System.Windows.Forms.TextBox();
            this.txtBox_Z = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_close_gripper = new System.Windows.Forms.Button();
            this.btn_open_gripper = new System.Windows.Forms.Button();
            this.btn_run_program = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox_Forward = new System.Windows.Forms.GroupBox();
            this.label_J3 = new System.Windows.Forms.Label();
            this.label_J2 = new System.Windows.Forms.Label();
            this.label_J1 = new System.Windows.Forms.Label();
            this.label_Base = new System.Windows.Forms.Label();
            this.btn_send_data = new System.Windows.Forms.Button();
            this.checkBox_simultaneous = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.step_J3 = new System.Windows.Forms.TextBox();
            this.btn_sub_J3 = new System.Windows.Forms.Button();
            this.btn_plus_J3 = new System.Windows.Forms.Button();
            this.progressBar_J3 = new System.Windows.Forms.ProgressBar();
            this.step_J2 = new System.Windows.Forms.TextBox();
            this.btn_sub_J2 = new System.Windows.Forms.Button();
            this.btn_plus_J2 = new System.Windows.Forms.Button();
            this.progressBar_J2 = new System.Windows.Forms.ProgressBar();
            this.step_J1 = new System.Windows.Forms.TextBox();
            this.btn_sub_J1 = new System.Windows.Forms.Button();
            this.btn_plus_J1 = new System.Windows.Forms.Button();
            this.progressBar_J1 = new System.Windows.Forms.ProgressBar();
            this.step_Base = new System.Windows.Forms.TextBox();
            this.btn_sub_Base = new System.Windows.Forms.Button();
            this.btn_plus_Base = new System.Windows.Forms.Button();
            this.progressBar_Base = new System.Windows.Forms.ProgressBar();
            this.groupBox_Inverse = new System.Windows.Forms.GroupBox();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.label_Z = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_X = new System.Windows.Forms.Label();
            this.groupBox_gripper = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_portList = new System.Windows.Forms.ComboBox();
            this.comboBox_baudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_stop_program = new System.Windows.Forms.Button();
            this.groupBox_Graph = new System.Windows.Forms.GroupBox();
            this.btn_Graph = new System.Windows.Forms.Button();
            this.groupBox_Forward.SuspendLayout();
            this.groupBox_Inverse.SuspendLayout();
            this.groupBox_gripper.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox_Graph.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox_X
            // 
            this.txtBox_X.Location = new System.Drawing.Point(31, 20);
            this.txtBox_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_X.Name = "txtBox_X";
            this.txtBox_X.Size = new System.Drawing.Size(89, 22);
            this.txtBox_X.TabIndex = 30;
            // 
            // txtBox_Y
            // 
            this.txtBox_Y.Location = new System.Drawing.Point(157, 20);
            this.txtBox_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_Y.Name = "txtBox_Y";
            this.txtBox_Y.Size = new System.Drawing.Size(89, 22);
            this.txtBox_Y.TabIndex = 31;
            // 
            // txtBox_Z
            // 
            this.txtBox_Z.Location = new System.Drawing.Point(275, 20);
            this.txtBox_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_Z.Name = "txtBox_Z";
            this.txtBox_Z.Size = new System.Drawing.Size(89, 22);
            this.txtBox_Z.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "X :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Y :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(271, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "Z :";
            // 
            // btn_close_gripper
            // 
            this.btn_close_gripper.Location = new System.Drawing.Point(5, 28);
            this.btn_close_gripper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_close_gripper.Name = "btn_close_gripper";
            this.btn_close_gripper.Size = new System.Drawing.Size(115, 47);
            this.btn_close_gripper.TabIndex = 41;
            this.btn_close_gripper.Text = "CLOSE";
            this.btn_close_gripper.UseVisualStyleBackColor = true;
            this.btn_close_gripper.Click += new System.EventHandler(this.btn_close_gripper_Click);
            // 
            // btn_open_gripper
            // 
            this.btn_open_gripper.Location = new System.Drawing.Point(125, 28);
            this.btn_open_gripper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_open_gripper.Name = "btn_open_gripper";
            this.btn_open_gripper.Size = new System.Drawing.Size(115, 47);
            this.btn_open_gripper.TabIndex = 42;
            this.btn_open_gripper.Text = "OPEN";
            this.btn_open_gripper.UseVisualStyleBackColor = true;
            this.btn_open_gripper.Click += new System.EventHandler(this.btn_open_gripper_Click);
            // 
            // btn_run_program
            // 
            this.btn_run_program.Location = new System.Drawing.Point(656, 487);
            this.btn_run_program.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_run_program.Name = "btn_run_program";
            this.btn_run_program.Size = new System.Drawing.Size(115, 75);
            this.btn_run_program.TabIndex = 45;
            this.btn_run_program.Text = "RUN PROGRAM";
            this.btn_run_program.UseVisualStyleBackColor = true;
            this.btn_run_program.Click += new System.EventHandler(this.btn_run_program_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(498, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 17);
            this.label11.TabIndex = 46;
            this.label11.Text = "CONTROL PANEL";
            // 
            // groupBox_Forward
            // 
            this.groupBox_Forward.Controls.Add(this.label_J3);
            this.groupBox_Forward.Controls.Add(this.label_J2);
            this.groupBox_Forward.Controls.Add(this.label_J1);
            this.groupBox_Forward.Controls.Add(this.label_Base);
            this.groupBox_Forward.Controls.Add(this.btn_send_data);
            this.groupBox_Forward.Controls.Add(this.checkBox_simultaneous);
            this.groupBox_Forward.Controls.Add(this.label1);
            this.groupBox_Forward.Controls.Add(this.label12);
            this.groupBox_Forward.Controls.Add(this.label13);
            this.groupBox_Forward.Controls.Add(this.label14);
            this.groupBox_Forward.Controls.Add(this.step_J3);
            this.groupBox_Forward.Controls.Add(this.btn_sub_J3);
            this.groupBox_Forward.Controls.Add(this.btn_plus_J3);
            this.groupBox_Forward.Controls.Add(this.progressBar_J3);
            this.groupBox_Forward.Controls.Add(this.step_J2);
            this.groupBox_Forward.Controls.Add(this.btn_sub_J2);
            this.groupBox_Forward.Controls.Add(this.btn_plus_J2);
            this.groupBox_Forward.Controls.Add(this.progressBar_J2);
            this.groupBox_Forward.Controls.Add(this.step_J1);
            this.groupBox_Forward.Controls.Add(this.btn_sub_J1);
            this.groupBox_Forward.Controls.Add(this.btn_plus_J1);
            this.groupBox_Forward.Controls.Add(this.progressBar_J1);
            this.groupBox_Forward.Controls.Add(this.step_Base);
            this.groupBox_Forward.Controls.Add(this.btn_sub_Base);
            this.groupBox_Forward.Controls.Add(this.btn_plus_Base);
            this.groupBox_Forward.Controls.Add(this.progressBar_Base);
            this.groupBox_Forward.Location = new System.Drawing.Point(75, 61);
            this.groupBox_Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Forward.Name = "groupBox_Forward";
            this.groupBox_Forward.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Forward.Size = new System.Drawing.Size(491, 511);
            this.groupBox_Forward.TabIndex = 47;
            this.groupBox_Forward.TabStop = false;
            this.groupBox_Forward.Text = "FORWARD KINEMATICS";
            // 
            // label_J3
            // 
            this.label_J3.AutoSize = true;
            this.label_J3.Location = new System.Drawing.Point(388, 371);
            this.label_J3.Name = "label_J3";
            this.label_J3.Size = new System.Drawing.Size(16, 17);
            this.label_J3.TabIndex = 58;
            this.label_J3.Text = "0";
            // 
            // label_J2
            // 
            this.label_J2.AutoSize = true;
            this.label_J2.Location = new System.Drawing.Point(388, 256);
            this.label_J2.Name = "label_J2";
            this.label_J2.Size = new System.Drawing.Size(16, 17);
            this.label_J2.TabIndex = 57;
            this.label_J2.Text = "0";
            // 
            // label_J1
            // 
            this.label_J1.AutoSize = true;
            this.label_J1.Location = new System.Drawing.Point(388, 146);
            this.label_J1.Name = "label_J1";
            this.label_J1.Size = new System.Drawing.Size(16, 17);
            this.label_J1.TabIndex = 56;
            this.label_J1.Text = "0";
            // 
            // label_Base
            // 
            this.label_Base.AutoSize = true;
            this.label_Base.Location = new System.Drawing.Point(388, 38);
            this.label_Base.Name = "label_Base";
            this.label_Base.Size = new System.Drawing.Size(16, 17);
            this.label_Base.TabIndex = 52;
            this.label_Base.Text = "0";
            // 
            // btn_send_data
            // 
            this.btn_send_data.Location = new System.Drawing.Point(259, 471);
            this.btn_send_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_send_data.Name = "btn_send_data";
            this.btn_send_data.Size = new System.Drawing.Size(149, 30);
            this.btn_send_data.TabIndex = 55;
            this.btn_send_data.Text = "SEND ALL DATA";
            this.btn_send_data.UseVisualStyleBackColor = true;
            this.btn_send_data.Click += new System.EventHandler(this.btn_send_data_Click);
            // 
            // checkBox_simultaneous
            // 
            this.checkBox_simultaneous.AutoSize = true;
            this.checkBox_simultaneous.Location = new System.Drawing.Point(18, 477);
            this.checkBox_simultaneous.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_simultaneous.Name = "checkBox_simultaneous";
            this.checkBox_simultaneous.Size = new System.Drawing.Size(229, 21);
            this.checkBox_simultaneous.TabIndex = 54;
            this.checkBox_simultaneous.Text = "SIMULTANEOUS MOVEMENT: ";
            this.checkBox_simultaneous.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 53;
            this.label1.Text = "J3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 256);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 17);
            this.label12.TabIndex = 52;
            this.label12.Text = "J2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 17);
            this.label13.TabIndex = 51;
            this.label13.Text = "J1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 17);
            this.label14.TabIndex = 50;
            this.label14.Text = "Base";
            // 
            // step_J3
            // 
            this.step_J3.Location = new System.Drawing.Point(187, 422);
            this.step_J3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.step_J3.Name = "step_J3";
            this.step_J3.Size = new System.Drawing.Size(97, 22);
            this.step_J3.TabIndex = 48;
            // 
            // btn_sub_J3
            // 
            this.btn_sub_J3.Location = new System.Drawing.Point(300, 418);
            this.btn_sub_J3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sub_J3.Name = "btn_sub_J3";
            this.btn_sub_J3.Size = new System.Drawing.Size(82, 28);
            this.btn_sub_J3.TabIndex = 47;
            this.btn_sub_J3.Text = "JOG-";
            this.btn_sub_J3.UseVisualStyleBackColor = true;
            this.btn_sub_J3.Click += new System.EventHandler(this.btn_sub_J3_Click);
            // 
            // btn_plus_J3
            // 
            this.btn_plus_J3.Location = new System.Drawing.Point(89, 418);
            this.btn_plus_J3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_plus_J3.Name = "btn_plus_J3";
            this.btn_plus_J3.Size = new System.Drawing.Size(82, 28);
            this.btn_plus_J3.TabIndex = 46;
            this.btn_plus_J3.Text = "JOG+";
            this.btn_plus_J3.UseVisualStyleBackColor = true;
            this.btn_plus_J3.Click += new System.EventHandler(this.btn_plus_J3_Click);
            // 
            // progressBar_J3
            // 
            this.progressBar_J3.Location = new System.Drawing.Point(89, 359);
            this.progressBar_J3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar_J3.Name = "progressBar_J3";
            this.progressBar_J3.Size = new System.Drawing.Size(293, 35);
            this.progressBar_J3.TabIndex = 45;
            // 
            // step_J2
            // 
            this.step_J2.Location = new System.Drawing.Point(187, 306);
            this.step_J2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.step_J2.Name = "step_J2";
            this.step_J2.Size = new System.Drawing.Size(97, 22);
            this.step_J2.TabIndex = 43;
            // 
            // btn_sub_J2
            // 
            this.btn_sub_J2.Location = new System.Drawing.Point(300, 303);
            this.btn_sub_J2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sub_J2.Name = "btn_sub_J2";
            this.btn_sub_J2.Size = new System.Drawing.Size(82, 28);
            this.btn_sub_J2.TabIndex = 42;
            this.btn_sub_J2.Text = "JOG-";
            this.btn_sub_J2.UseVisualStyleBackColor = true;
            this.btn_sub_J2.Click += new System.EventHandler(this.btn_sub_J2_Click);
            // 
            // btn_plus_J2
            // 
            this.btn_plus_J2.Location = new System.Drawing.Point(89, 303);
            this.btn_plus_J2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_plus_J2.Name = "btn_plus_J2";
            this.btn_plus_J2.Size = new System.Drawing.Size(82, 28);
            this.btn_plus_J2.TabIndex = 41;
            this.btn_plus_J2.Text = "JOG+";
            this.btn_plus_J2.UseVisualStyleBackColor = true;
            this.btn_plus_J2.Click += new System.EventHandler(this.btn_plus_J2_Click);
            // 
            // progressBar_J2
            // 
            this.progressBar_J2.Location = new System.Drawing.Point(89, 244);
            this.progressBar_J2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar_J2.Name = "progressBar_J2";
            this.progressBar_J2.Size = new System.Drawing.Size(293, 35);
            this.progressBar_J2.TabIndex = 40;
            // 
            // step_J1
            // 
            this.step_J1.Location = new System.Drawing.Point(187, 197);
            this.step_J1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.step_J1.Name = "step_J1";
            this.step_J1.Size = new System.Drawing.Size(97, 22);
            this.step_J1.TabIndex = 38;
            // 
            // btn_sub_J1
            // 
            this.btn_sub_J1.Location = new System.Drawing.Point(300, 194);
            this.btn_sub_J1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sub_J1.Name = "btn_sub_J1";
            this.btn_sub_J1.Size = new System.Drawing.Size(82, 28);
            this.btn_sub_J1.TabIndex = 37;
            this.btn_sub_J1.Text = "JOG-";
            this.btn_sub_J1.UseVisualStyleBackColor = true;
            this.btn_sub_J1.Click += new System.EventHandler(this.btn_sub_J1_Click);
            // 
            // btn_plus_J1
            // 
            this.btn_plus_J1.Location = new System.Drawing.Point(89, 194);
            this.btn_plus_J1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_plus_J1.Name = "btn_plus_J1";
            this.btn_plus_J1.Size = new System.Drawing.Size(82, 28);
            this.btn_plus_J1.TabIndex = 36;
            this.btn_plus_J1.Text = "JOG+";
            this.btn_plus_J1.UseVisualStyleBackColor = true;
            this.btn_plus_J1.Click += new System.EventHandler(this.btn_plus_J1_Click);
            // 
            // progressBar_J1
            // 
            this.progressBar_J1.Location = new System.Drawing.Point(89, 134);
            this.progressBar_J1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar_J1.Name = "progressBar_J1";
            this.progressBar_J1.Size = new System.Drawing.Size(293, 35);
            this.progressBar_J1.TabIndex = 35;
            // 
            // step_Base
            // 
            this.step_Base.Location = new System.Drawing.Point(187, 88);
            this.step_Base.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.step_Base.Name = "step_Base";
            this.step_Base.Size = new System.Drawing.Size(97, 22);
            this.step_Base.TabIndex = 33;
            // 
            // btn_sub_Base
            // 
            this.btn_sub_Base.Location = new System.Drawing.Point(300, 85);
            this.btn_sub_Base.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sub_Base.Name = "btn_sub_Base";
            this.btn_sub_Base.Size = new System.Drawing.Size(82, 28);
            this.btn_sub_Base.TabIndex = 32;
            this.btn_sub_Base.Text = "JOG-";
            this.btn_sub_Base.UseVisualStyleBackColor = true;
            this.btn_sub_Base.Click += new System.EventHandler(this.btn_sub_Base_Click);
            // 
            // btn_plus_Base
            // 
            this.btn_plus_Base.Location = new System.Drawing.Point(89, 85);
            this.btn_plus_Base.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_plus_Base.Name = "btn_plus_Base";
            this.btn_plus_Base.Size = new System.Drawing.Size(82, 28);
            this.btn_plus_Base.TabIndex = 31;
            this.btn_plus_Base.Text = "JOG+";
            this.btn_plus_Base.UseVisualStyleBackColor = true;
            this.btn_plus_Base.Click += new System.EventHandler(this.btn_plus_Base_Click);
            // 
            // progressBar_Base
            // 
            this.progressBar_Base.Location = new System.Drawing.Point(89, 26);
            this.progressBar_Base.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar_Base.Name = "progressBar_Base";
            this.progressBar_Base.Size = new System.Drawing.Size(293, 35);
            this.progressBar_Base.TabIndex = 30;
            // 
            // groupBox_Inverse
            // 
            this.groupBox_Inverse.Controls.Add(this.btn_Calculate);
            this.groupBox_Inverse.Controls.Add(this.label_Z);
            this.groupBox_Inverse.Controls.Add(this.label_Y);
            this.groupBox_Inverse.Controls.Add(this.label_X);
            this.groupBox_Inverse.Controls.Add(this.txtBox_Y);
            this.groupBox_Inverse.Controls.Add(this.txtBox_X);
            this.groupBox_Inverse.Controls.Add(this.txtBox_Z);
            this.groupBox_Inverse.Controls.Add(this.label6);
            this.groupBox_Inverse.Controls.Add(this.label7);
            this.groupBox_Inverse.Controls.Add(this.label8);
            this.groupBox_Inverse.Location = new System.Drawing.Point(651, 61);
            this.groupBox_Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Inverse.Name = "groupBox_Inverse";
            this.groupBox_Inverse.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Inverse.Size = new System.Drawing.Size(376, 139);
            this.groupBox_Inverse.TabIndex = 48;
            this.groupBox_Inverse.TabStop = false;
            this.groupBox_Inverse.Text = "INVERSE KINEMATICS";
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.Location = new System.Drawing.Point(112, 88);
            this.btn_Calculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(160, 44);
            this.btn_Calculate.TabIndex = 43;
            this.btn_Calculate.Text = "CALCULATE";
            this.btn_Calculate.UseVisualStyleBackColor = true;
            this.btn_Calculate.Click += new System.EventHandler(this.btn_Calculate_Click);
            // 
            // label_Z
            // 
            this.label_Z.AutoSize = true;
            this.label_Z.Location = new System.Drawing.Point(300, 50);
            this.label_Z.Name = "label_Z";
            this.label_Z.Size = new System.Drawing.Size(16, 17);
            this.label_Z.TabIndex = 42;
            this.label_Z.Text = "0";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(184, 50);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(16, 17);
            this.label_Y.TabIndex = 41;
            this.label_Y.Text = "0";
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(64, 50);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(16, 17);
            this.label_X.TabIndex = 40;
            this.label_X.Text = "0";
            // 
            // groupBox_gripper
            // 
            this.groupBox_gripper.Controls.Add(this.btn_close_gripper);
            this.groupBox_gripper.Controls.Add(this.btn_open_gripper);
            this.groupBox_gripper.Location = new System.Drawing.Point(651, 230);
            this.groupBox_gripper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_gripper.Name = "groupBox_gripper";
            this.groupBox_gripper.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_gripper.Size = new System.Drawing.Size(242, 80);
            this.groupBox_gripper.TabIndex = 49;
            this.groupBox_gripper.TabStop = false;
            this.groupBox_gripper.Text = "GRIPPER";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox_portList);
            this.groupBox4.Controls.Add(this.comboBox_baudRate);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(656, 341);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(222, 114);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SETUP";
            // 
            // comboBox_portList
            // 
            this.comboBox_portList.FormattingEnabled = true;
            this.comboBox_portList.Items.AddRange(new object[] {
            "9600",
            "38400",
            "57600",
            "115200"});
            this.comboBox_portList.Location = new System.Drawing.Point(66, 25);
            this.comboBox_portList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_portList.Name = "comboBox_portList";
            this.comboBox_portList.Size = new System.Drawing.Size(108, 24);
            this.comboBox_portList.TabIndex = 55;
            this.comboBox_portList.DropDown += new System.EventHandler(this.comboBox_portList_DropDown);
            // 
            // comboBox_baudRate
            // 
            this.comboBox_baudRate.FormattingEnabled = true;
            this.comboBox_baudRate.Items.AddRange(new object[] {
            "9600",
            "38400",
            "57600",
            "115200"});
            this.comboBox_baudRate.Location = new System.Drawing.Point(68, 65);
            this.comboBox_baudRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_baudRate.Name = "comboBox_baudRate";
            this.comboBox_baudRate.Size = new System.Drawing.Size(108, 24);
            this.comboBox_baudRate.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "BAUD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "COM :";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 57600;
            this.serialPort1.PortName = "COM6";
            // 
            // btn_stop_program
            // 
            this.btn_stop_program.Location = new System.Drawing.Point(792, 487);
            this.btn_stop_program.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_stop_program.Name = "btn_stop_program";
            this.btn_stop_program.Size = new System.Drawing.Size(116, 75);
            this.btn_stop_program.TabIndex = 51;
            this.btn_stop_program.Text = "STOP PROGRAM";
            this.btn_stop_program.UseVisualStyleBackColor = true;
            this.btn_stop_program.Click += new System.EventHandler(this.btn_stop_program_Click);
            // 
            // groupBox_Graph
            // 
            this.groupBox_Graph.Controls.Add(this.btn_Graph);
            this.groupBox_Graph.Location = new System.Drawing.Point(902, 230);
            this.groupBox_Graph.Name = "groupBox_Graph";
            this.groupBox_Graph.Size = new System.Drawing.Size(200, 80);
            this.groupBox_Graph.TabIndex = 52;
            this.groupBox_Graph.TabStop = false;
            this.groupBox_Graph.Text = "Graph";
            // 
            // btn_Graph
            // 
            this.btn_Graph.Location = new System.Drawing.Point(52, 28);
            this.btn_Graph.Name = "btn_Graph";
            this.btn_Graph.Size = new System.Drawing.Size(102, 46);
            this.btn_Graph.TabIndex = 0;
            this.btn_Graph.Text = "Graph";
            this.btn_Graph.UseVisualStyleBackColor = true;
            this.btn_Graph.Click += new System.EventHandler(this.btn_Graph_Click);
            // 
            // MainWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 590);
            this.Controls.Add(this.groupBox_Graph);
            this.Controls.Add(this.btn_stop_program);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_gripper);
            this.Controls.Add(this.groupBox_Inverse);
            this.Controls.Add(this.groupBox_Forward);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_run_program);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindows";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Forward.ResumeLayout(false);
            this.groupBox_Forward.PerformLayout();
            this.groupBox_Inverse.ResumeLayout(false);
            this.groupBox_Inverse.PerformLayout();
            this.groupBox_gripper.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox_Graph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBox_X;
        private System.Windows.Forms.TextBox txtBox_Y;
        private System.Windows.Forms.TextBox txtBox_Z;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_close_gripper;
        private System.Windows.Forms.Button btn_open_gripper;
        private System.Windows.Forms.Button btn_run_program;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox_Forward;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox step_J3;
        private System.Windows.Forms.Button btn_sub_J3;
        private System.Windows.Forms.Button btn_plus_J3;
        private System.Windows.Forms.ProgressBar progressBar_J3;
        private System.Windows.Forms.TextBox step_J2;
        private System.Windows.Forms.Button btn_sub_J2;
        private System.Windows.Forms.Button btn_plus_J2;
        private System.Windows.Forms.ProgressBar progressBar_J2;
        private System.Windows.Forms.TextBox step_J1;
        private System.Windows.Forms.Button btn_sub_J1;
        private System.Windows.Forms.Button btn_plus_J1;
        private System.Windows.Forms.ProgressBar progressBar_J1;
        private System.Windows.Forms.TextBox step_Base;
        private System.Windows.Forms.Button btn_sub_Base;
        private System.Windows.Forms.Button btn_plus_Base;
        private System.Windows.Forms.ProgressBar progressBar_Base;
        private System.Windows.Forms.GroupBox groupBox_Inverse;
        private System.Windows.Forms.GroupBox groupBox_gripper;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_baudRate;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox_portList;
        private System.Windows.Forms.Button btn_stop_program;
        private System.Windows.Forms.Button btn_send_data;
        private System.Windows.Forms.CheckBox checkBox_simultaneous;
        private System.Windows.Forms.Label label_Base;
        private System.Windows.Forms.Label label_J3;
        private System.Windows.Forms.Label label_J2;
        private System.Windows.Forms.Label label_J1;
        private System.Windows.Forms.Label label_Z;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.GroupBox groupBox_Graph;
        private System.Windows.Forms.Button btn_Graph;
    }
}

