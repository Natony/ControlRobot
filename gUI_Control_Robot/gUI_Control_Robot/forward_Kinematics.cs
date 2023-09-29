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

            // Các ma trận biến đổi A1, A2, A3, A4
            double[,] A1 = {
            { Math.Cos(t1), 0, -Math.Sin(t1), 150 * Math.Cos(t1) },
            { Math.Sin(t1), 0, Math.Cos(t1), 150 * Math.Sin(t1) },
            { 0, -1, 0, 160 },
            { 0, 0, 0, 1 }
        };

            double[,] A2 = {
            { Math.Cos(t2), -Math.Sin(t2), 0, 350 * Math.Cos(t2) },
            { Math.Sin(t2), Math.Cos(t2), 0, 350 * Math.Sin(t2) },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] A3 = {
            { Math.Cos(t3), -Math.Sin(t3), 0, 362.5 * Math.Cos(t3) },
            { Math.Sin(t3), Math.Cos(t3), 0, 362.5 * Math.Sin(t3) },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] A4 = {
            { Math.Cos(t4), -Math.Sin(t4), 0, 230 * Math.Cos(t4) },
            { Math.Sin(t4), Math.Cos(t4), 0, 230 * Math.Sin(t4) },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            // Tích các ma trận biến đổi
            double[,] T = MatrixMultiply(MatrixMultiply(MatrixMultiply(A1, A2), A3), A4);

            // Lấy giá trị x, y, z từ ma trận T
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
