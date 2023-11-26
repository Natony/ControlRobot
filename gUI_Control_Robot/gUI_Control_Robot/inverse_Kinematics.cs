using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gUI_Control_Robot
{
    class inverse_Kinematics
    {
        MainWindows mainForm;
        public static double[,] CalculateInverseKinematics(double x, double y, double z, double l0, double l2, double l4, double l5, double l6, double l, double theta234)
        {
            double c1_1, c1_2, s1_1, s1_2, theta1_1, theta1_2;
            double nx_1, ny_1, nx_2, ny_2;
            double c3_1, s3_1_1, s3_1_2, theta3_1_1, theta3_1_2;
            double c3_2, s3_2_1, s3_2_2, theta3_2_1, theta3_2_2;
            double c2_1, s2_1, theta2_1, c2_2, s2_2, theta2_2, c2_3, s2_3, theta2_3, c2_4, s2_4, theta2_4;
            double theta4_1, theta4_2, theta4_3, theta4_4;
            double[,] theta = new double[4, 4];

            x = 351.133;
            y = -414.133;
            z = 295.58;

            theta234 = 0;

            // Tính theta1
            c1_1 = (x + l0) / Math.Sqrt(y * y - (x + l0) * (x + l0));
            c1_2 = -(x + l0) / Math.Sqrt(y * y - (x + l0) * (x + l0));
            s1_1 = (y * c1_1) / (x + l0);
            s1_2 = (y * c1_2) / (x + l0);
            theta1_1 = Math.Atan2(s1_1, c1_1) * (180 / Math.PI);
            theta1_2 = Math.Atan2(s1_2, c1_2) * (180 / Math.PI);

            // Tính nx ny
            // Theta1_1
            nx_1 = l2 - Math.Cos(theta1_1 * (Math.PI / 180)) * (x + l0) - Math.Sin(theta1_1 * (Math.PI / 180)) * y;
            ny_1 = z - l6;
            // Theta1_2
            nx_2 = l2 - Math.Cos(theta1_2 * (Math.PI / 180)) * (x + l0) - Math.Sin(theta1_2 * (Math.PI / 180)) * y;
            ny_2 = z - l6;

            // Tính theta3
            // Theta1_1
            c3_1 = (nx_1 * nx_1 + ny_1 * ny_1 - (l + l4) * (l + l4) - l5 * l5) / (2 * (l + l4) * l5);
            s3_1_1 = Math.Sqrt(1 - c3_1 * c3_1);
            s3_1_2 = -Math.Sqrt(1 - c3_1 * c3_1);
            theta3_1_1 = Math.Atan2(s3_1_1, c3_1) * (180 / Math.PI);
            theta3_1_2 = Math.Atan2(s3_1_2, c3_1) * (180 / Math.PI);
            // Theta1_2
            c3_2 = (nx_2 * nx_2 + ny_2 * ny_2 - (l + l4) * (l + l4) - l5 * l5) / (2 * (l + l4) * l5);

            c3_1 = Math.Max(-1, Math.Min(c3_1, 1));
            c3_2 = Math.Max(-1, Math.Min(c3_2, 1));

            s3_2_1 = Math.Sqrt(1 - c3_2 * c3_2);
            s3_2_2 = -Math.Sqrt(1 - c3_2 * c3_2);
            theta3_2_1 = Math.Atan2(s3_2_1, c3_2) * (180 / Math.PI);
            theta3_2_2 = Math.Atan2(s3_2_2, c3_2) * (180 / Math.PI);
            //----------------------------------------------------------------------------------------------------------------------------------------
            // Tính theta2
            // theta1_1 theta3_1_1
            c2_1 = (ny_1 * (l5 * Math.Cos(theta3_1_1 * (Math.PI / 180)) + (l + l4)) + nx_1 * l5 * Math.Sin(theta3_1_1 * (Math.PI / 180))) / ((l5 * Math.Cos(theta3_1_1 * (Math.PI / 180)) + (l + l4)) * (l5 * Math.Cos(theta3_1_1 * (Math.PI / 180)) + (l + l4)) + (l5 * Math.Sin(theta3_1_1 * (Math.PI / 180))) * (l5 * Math.Sin(theta3_1_1 * (Math.PI / 180))));
            s2_1 = (nx_1 - l5 * c2_1 * Math.Sin(theta3_1_1 * (Math.PI / 180))) / (l5 * Math.Cos(theta3_1_1 * (Math.PI / 180)) + (l + l4));
            theta2_1 = Math.Atan2(s2_1, c2_1) * (180 / Math.PI);
            c2_2 = (ny_1 * (l5 * Math.Cos(theta3_1_2 * (Math.PI / 180)) + (l + l4)) + nx_1 * l5 * Math.Sin(theta3_1_2 * (Math.PI / 180))) / ((l5 * Math.Cos(theta3_1_2 * (Math.PI / 180)) + (l + l4)) * (l5 * Math.Cos(theta3_1_2 * (Math.PI / 180)) + (l + l4)) + (l5 * Math.Sin(theta3_1_2 * (Math.PI / 180))) * (l5 * Math.Sin(theta3_1_2 * (Math.PI / 180))));
            s2_2 = (nx_1 - l5 * c2_2 * Math.Sin(theta3_1_2 * (Math.PI / 180))) / (l5 * Math.Cos(theta3_1_2 * (Math.PI / 180)) + (l + l4));
            theta2_2 = Math.Atan2(s2_2, c2_2) * (180 / Math.PI);
            // theta1_1 theta3_1_2
            c2_3 = (ny_2 * (l5 * Math.Cos(theta3_2_1 * (Math.PI / 180)) + (l + l4)) + nx_2 * l5 * Math.Sin(theta3_2_1 * (Math.PI / 180))) / ((l5 * Math.Cos(theta3_2_1 * (Math.PI / 180)) + (l + l4)) * (l5 * Math.Cos(theta3_2_1 * (Math.PI / 180)) + (l + l4)) + (l5 * Math.Sin(theta3_2_1 * (Math.PI / 180))) * (l5 * Math.Sin(theta3_2_1 * (Math.PI / 180))));
            s2_3 = (nx_2 - l5 * c2_3 * Math.Sin(theta3_2_1 * (Math.PI / 180))) / (l5 * Math.Cos(theta3_2_1 * (Math.PI / 180)) + (l + l4));
            theta2_3 = Math.Atan2(s2_3, c2_3) * (180 / Math.PI);
            c2_4 = (ny_2 * (l5 * Math.Cos(theta3_2_2 * (Math.PI / 180)) + (l + l4)) + nx_2 * l5 * Math.Sin(theta3_2_2 * (Math.PI / 180))) / ((l5 * Math.Cos(theta3_2_2 * (Math.PI / 180)) + (l + l4)) * (l5 * Math.Cos(theta3_2_2 * (Math.PI / 180)) + (l + l4)) + (l5 * Math.Sin(theta3_2_2 * (Math.PI / 180))) * (l5 * Math.Sin(theta3_2_2 * (Math.PI / 180))));
            s2_4 = (nx_2 - l5 * c2_4 * Math.Sin(theta3_2_2 * (Math.PI / 180))) / (l5 * Math.Cos(theta3_2_2 * (Math.PI / 180)) + (l + l4));
            theta2_4 = Math.Atan2(s2_4, c2_4) * (180 / Math.PI);

            // Tính theta4
            theta4_1 = theta234 - theta2_1 - theta3_1_1;
            theta4_2 = theta234 - theta2_2 - theta3_1_2;
            theta4_3 = theta234 - theta2_3 - theta3_2_1;
            theta4_4 = theta234 - theta2_4 - theta3_2_2;

            // Góc theta
            theta[0, 0] = theta1_1;
            theta[0, 1] = theta2_1;
            theta[0, 2] = theta3_1_1;
            theta[0, 3] = theta4_1;
            theta[1, 0] = theta1_1;
            theta[1, 1] = theta2_2;
            theta[1, 2] = theta3_1_2;
            theta[1, 3] = theta4_2;
            theta[2, 0] = theta1_2;
            theta[2, 1] = theta2_3;
            theta[2, 2] = theta3_2_1;
            theta[2, 3] = theta4_3;
            theta[3, 0] = theta1_2;
            theta[3, 1] = theta2_4;
            theta[3, 2] = theta3_2_2;
            theta[3, 3] = theta4_4;

            return theta;
        }
    }

}
