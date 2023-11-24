using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gUI_Control_Robot
{
    class forward_Kinematics
    {
        public static void CalculateXYZ(float degree1, int degree2, int degree3, int degree4, out double x, out double y, out double z)
        {
            // Chuyển đổi từ độ sang radian
            double t1 = degree1 * Math.PI / 180.0;
            double t2 = degree2 * Math.PI / 180.0;
            double t3 = degree3 * Math.PI / 180.0;
            double t4 = degree4 * Math.PI / 180.0;
            double l0, l2, l4, l5, l6, l;
            l0 = 63;
            l2 = 120;
            l4 = 125;
            l5 = 125;
            l6 = 80;
            l = 250;

            double[,] A1 = {
            { Math.Cos(t1), -Math.Sin(t1), 0, -l0 },
            { Math.Sin(t1), Math.Cos(t1), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
            double[,] A2 = {
            { Math.Cos(t2 + Math.PI / 2), -Math.Sin(t2 + Math.PI / 2), 0, l2},
            { 0, 0, 1, 0 },
            { Math.Sin(t2 + Math.PI / 2), Math.Cos(t2 + Math.PI / 2), 0, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] Atg = {
            { 1, 0, 0, l },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] A3 = {    
            { Math.Cos(t3), -Math.Sin(t3), 0, l4 },
            { Math.Sin(t3), Math.Cos(t3), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] A4 = {
            { Math.Cos(t4), -Math.Sin(t4), 0, l5 },
            { Math.Sin(t4), Math.Cos(t4), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
            double[,] A5 = {
            { 1, 0, 0, l6 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
            double[,] T = MatrixMultiply(MatrixMultiply(MatrixMultiply(MatrixMultiply(MatrixMultiply(A1, A2), Atg), A3), A4), A5);
             x = T[0, 3];
             y = T[1, 3];
             z = T[2, 3];

        }
        private static double[,] MatrixMultiply(double[,] matrix1, double[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int cols2 = matrix2.GetLength(1);
            double[,] result = new double[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }
    }
}
