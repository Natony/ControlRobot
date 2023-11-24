using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace gUI_Control_Robot
{
    public partial class GraphMonitor : Form
    {
        private MainWindows mainForm;
        private RollingPointPairList points1;
        private RollingPointPairList points2;
        private RollingPointPairList points3;
        private RollingPointPairList points4;

        public GraphMonitor(MainWindows mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            // Initialize ZedGraph controls
            InitializeGraph(graphMotor1, "Motor 1", 1);
            InitializeGraph(graphMotor2, "Motor 2", 2);
            InitializeGraph(graphMotor3, "Motor 3", 3);
            InitializeGraph(graphMotor4, "Motor 4", 4);
        }

        private void InitializeGraph(ZedGraphControl graphControl, string title, int motorIndex)
        {
            // Initialize the ZedGraphControl
            GraphPane pane = graphControl.GraphPane;
            pane.Title.Text = title;
            pane.XAxis.Title.Text = "Time (s)";
            pane.YAxis.Title.Text = "Angle";

            // Initialize the data points and curve
            RollingPointPairList points = new RollingPointPairList(1000);
            LineItem curve = pane.AddCurve(title, points, Color.Blue, SymbolType.None);

            // Initialize the specific points field based on the title
            if (title == "Motor 1")
            {
                points1 = points;
            }
            else if (title == "Motor 2")
            {
                points2 = points;
            }
            else if (title == "Motor 3")
            {
                points3 = points;
            }
            else if (title == "Motor 4")
            {
                points4 = points;
            }

            // Setup the graph
            pane.XAxis.Type = AxisType.Linear; // Use Linear type for elapsed time in seconds
            pane.XAxis.Scale.MajorStepAuto = true;
            pane.XAxis.Scale.MinorStepAuto = true;

            // Enable the timer to update the graph
            Timer updateTimer = new Timer();
            updateTimer.Interval = 100; // Set the interval as needed
            updateTimer.Tick += (sender, e) => { UpdateGraph(graphControl, points, curve, motorIndex); };
            updateTimer.Start();
        }


        private void UpdateGraph(ZedGraphControl graphControl, RollingPointPairList points, LineItem curve, int motorIndex)
        {
            if (graphControl.IsDisposed)
                return;

            double time = points.Count * 0.1; 

            switch (motorIndex)
            {
                case 1:
                    points.Add(time, mainForm.T1);
                    break;
                case 2:
                    points.Add(time, mainForm.T2);
                    break;
                case 3:
                    points.Add(time, mainForm.T3);
                    break;
                case 4:
                    points.Add(time, mainForm.T4);
                    break;
                default:
                    // Handle invalid motor index
                    break;
            }

            // Update the graph
            graphControl.AxisChange();
            graphControl.Invalidate();
        }

        private void GraphMonitor_Load(object sender, EventArgs e)
        {
            // Additional initialization code for the GraphMonitor form
        }
    }
}
