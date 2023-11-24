
namespace gUI_Control_Robot
{
    partial class GraphMonitor
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
            this.graphMotor1 = new ZedGraph.ZedGraphControl();
            this.graphMotor2 = new ZedGraph.ZedGraphControl();
            this.graphMotor3 = new ZedGraph.ZedGraphControl();
            this.graphMotor4 = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // graphMotor1
            // 
            this.graphMotor1.Location = new System.Drawing.Point(13, 13);
            this.graphMotor1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphMotor1.Name = "graphMotor1";
            this.graphMotor1.ScrollGrace = 0D;
            this.graphMotor1.ScrollMaxX = 0D;
            this.graphMotor1.ScrollMaxY = 0D;
            this.graphMotor1.ScrollMaxY2 = 0D;
            this.graphMotor1.ScrollMinX = 0D;
            this.graphMotor1.ScrollMinY = 0D;
            this.graphMotor1.ScrollMinY2 = 0D;
            this.graphMotor1.Size = new System.Drawing.Size(611, 362);
            this.graphMotor1.TabIndex = 2;
            this.graphMotor1.UseExtendedPrintDialog = true;
            // 
            // graphMotor2
            // 
            this.graphMotor2.Location = new System.Drawing.Point(674, 13);
            this.graphMotor2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphMotor2.Name = "graphMotor2";
            this.graphMotor2.ScrollGrace = 0D;
            this.graphMotor2.ScrollMaxX = 0D;
            this.graphMotor2.ScrollMaxY = 0D;
            this.graphMotor2.ScrollMaxY2 = 0D;
            this.graphMotor2.ScrollMinX = 0D;
            this.graphMotor2.ScrollMinY = 0D;
            this.graphMotor2.ScrollMinY2 = 0D;
            this.graphMotor2.Size = new System.Drawing.Size(611, 362);
            this.graphMotor2.TabIndex = 3;
            this.graphMotor2.UseExtendedPrintDialog = true;
            // 
            // graphMotor3
            // 
            this.graphMotor3.Location = new System.Drawing.Point(13, 420);
            this.graphMotor3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphMotor3.Name = "graphMotor3";
            this.graphMotor3.ScrollGrace = 0D;
            this.graphMotor3.ScrollMaxX = 0D;
            this.graphMotor3.ScrollMaxY = 0D;
            this.graphMotor3.ScrollMaxY2 = 0D;
            this.graphMotor3.ScrollMinX = 0D;
            this.graphMotor3.ScrollMinY = 0D;
            this.graphMotor3.ScrollMinY2 = 0D;
            this.graphMotor3.Size = new System.Drawing.Size(611, 362);
            this.graphMotor3.TabIndex = 4;
            this.graphMotor3.UseExtendedPrintDialog = true;
            // 
            // graphMotor4
            // 
            this.graphMotor4.Location = new System.Drawing.Point(674, 420);
            this.graphMotor4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphMotor4.Name = "graphMotor4";
            this.graphMotor4.ScrollGrace = 0D;
            this.graphMotor4.ScrollMaxX = 0D;
            this.graphMotor4.ScrollMaxY = 0D;
            this.graphMotor4.ScrollMaxY2 = 0D;
            this.graphMotor4.ScrollMinX = 0D;
            this.graphMotor4.ScrollMinY = 0D;
            this.graphMotor4.ScrollMinY2 = 0D;
            this.graphMotor4.Size = new System.Drawing.Size(611, 362);
            this.graphMotor4.TabIndex = 5;
            this.graphMotor4.UseExtendedPrintDialog = true;
            // 
            // GraphMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 804);
            this.Controls.Add(this.graphMotor4);
            this.Controls.Add(this.graphMotor3);
            this.Controls.Add(this.graphMotor2);
            this.Controls.Add(this.graphMotor1);
            this.Name = "GraphMonitor";
            this.Text = "Graph Monitor";
            this.Load += new System.EventHandler(this.GraphMonitor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl graphMotor1;
        private ZedGraph.ZedGraphControl graphMotor2;
        private ZedGraph.ZedGraphControl graphMotor3;
        private ZedGraph.ZedGraphControl graphMotor4;
    }
}