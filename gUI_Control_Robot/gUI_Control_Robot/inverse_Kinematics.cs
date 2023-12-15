using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace gUI_Control_Robot
{
    class inverse_Kinematics
    {
        public static double[,] CalculateInverseKinematics(double x, double y, double z)
        {
            double l0 = 55;
            double l2 = 91;
            double l4 = 125;
            double l5 = 125;
            double l6 = 100;
            double l = 235;

            double[] P = { 81.1159, 11.9086, 540.85 };

            //double x = P[0];
            //double y = P[1];
            //double z = P[2];

            double theta234 = 0;

            // Tính theta1
            double theta1 = Math.Atan2(y, x + l0) * 180 / Math.PI;
            if (theta1 < -90 || theta1 > 90)
                theta1 = Math.Atan2(-y, -x - l0) * 180 / Math.PI;

            // Tính nx ny
            double nx = Math.Cos(theta1 * Math.PI / 180) * (x + l0) + Math.Sin(theta1 * Math.PI / 180) * y - l2 + l6 * Math.Sin(theta234 * Math.PI / 180);
            double ny = z - l6 * Math.Cos(theta234 * Math.PI / 180) - l;

            // Tính theta3
            double c3 = (nx * nx + ny * ny - l4 * l4 - l5 * l5) / (2 * l4 * l5);
            if (Math.Abs(c3 - 1) < 0.0001)
                c3 = 1;
            double s3_1 = Math.Sqrt(1 - c3 * c3);
            double s3_2 = -Math.Sqrt(1 - c3 * c3);
            double theta3_1 = Math.Atan2(s3_1, c3) * 180 / Math.PI;
            double theta3_2 = Math.Atan2(s3_2, c3) * 180 / Math.PI;

            // Tính theta2
            double c2_1 = (ny * (l5 * Math.Cos(theta3_1 * Math.PI / 180) + l4) - nx * l5 * Math.Sin(theta3_1 * Math.PI / 180)) /
                          ((l5 * Math.Cos(theta3_1 * Math.PI / 180) + l4) * (l5 * Math.Cos(theta3_1 * Math.PI / 180) + l4) +
                           (l5 * Math.Sin(theta3_1 * Math.PI / 180)) * (l5 * Math.Sin(theta3_1 * Math.PI / 180)));
            double s2_1 = (nx + l5 * c2_1 * Math.Sin(theta3_1 * Math.PI / 180)) / (l5 * Math.Cos(theta3_1 * Math.PI / 180) + l4);
            double theta2_1 = Math.Atan2(s2_1, c2_1) * 180 / Math.PI;

            double c2_2 = (ny * (l5 * Math.Cos(theta3_2 * Math.PI / 180) + l4) - nx * l5 * Math.Sin(theta3_2 * Math.PI / 180)) /
                          ((l5 * Math.Cos(theta3_2 * Math.PI / 180) + l4) * (l5 * Math.Cos(theta3_2 * Math.PI / 180) + l4) +
                           (l5 * Math.Sin(theta3_2 * Math.PI / 180)) * (l5 * Math.Sin(theta3_2 * Math.PI / 180)));
            double s2_2 = (nx + l5 * c2_2 * Math.Sin(theta3_2 * Math.PI / 180)) / (l5 * Math.Cos(theta3_2 * Math.PI / 180) + l4);
            double theta2_2 = Math.Atan2(s2_2, c2_2) * 180 / Math.PI;

            // Tính theta4
            double theta4_1 = theta234 + theta2_1 - theta3_1;
            double theta4_2 = theta234 + theta2_2 - theta3_2;

            // Góc theta
            double[,] thetaArray = {
            {theta1, theta2_1, theta3_1, theta4_1},
            {theta1, theta2_2, theta3_2, theta4_2}
        };

            return thetaArray;
        }
    }

}
