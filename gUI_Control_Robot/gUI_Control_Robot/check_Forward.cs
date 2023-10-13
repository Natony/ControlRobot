using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gUI_Control_Robot
{
    class check_Forward
    {
        public static char CheckForward(double x, double y, double z, double t1, double t2, double t3, double t4)
        {
            double[,] A1 = {
            { Math.Cos(Math.PI * t1 / 180.0), 0, -Math.Sin(Math.PI * t1 / 180.0), 150 * Math.Cos(Math.PI * t1 / 180.0) },
            { Math.Sin(Math.PI * t1 / 180.0), 0, Math.Cos(Math.PI * t1 / 180.0), 150 * Math.Sin(Math.PI * t1 / 180.0) },
            { 0, -1, 0, 160 },
            { 0, 0, 0, 1 }
        };

            double[,] A2 = {
            { Math.Cos(Math.PI * t2 / 180.0), -Math.Sin(Math.PI * t2 / 180.0), 0, 350 * Math.Cos(Math.PI * t2 / 180.0) },
            { Math.Sin(Math.PI * t2 / 180.0), Math.Cos(Math.PI * t2 / 180.0), 0, 350 * Math.Sin(Math.PI * t2 / 180.0) },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] A3 = {
            { Math.Cos(Math.PI * t3 / 180.0), -Math.Sin(Math.PI * t3 / 180.0), 0, 362.5 * Math.Cos(Math.PI * t3 / 180.0) },
            { Math.Sin(Math.PI * t3 / 180.0), Math.Cos(Math.PI * t3 / 180.0), 0, 362.5 * Math.Sin(Math.PI * t3 / 180.0) },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] A4 = {
            { Math.Cos(Math.PI * t4 / 180.0), -Math.Sin(Math.PI * t4 / 180.0), 0, 230 * Math.Cos(Math.PI * t4 / 180.0) },
            { Math.Sin(Math.PI * t4 / 180.0), Math.Cos(Math.PI * t4 / 180.0), 0, 230 * Math.Sin(Math.PI * t4 / 180.0) },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };

            double[,] T = MatrixMultiply(MatrixMultiply(MatrixMultiply(A1, A2), A3), A4);

            if (Math.Round(x) == Math.Round(T[0, 3]) && Math.Round(y) == Math.Round(T[1, 3]) && Math.Round(z) == Math.Round(T[2, 3]))
            {
                return 'C';
            }
            else
            {
                return 'U';
            }
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
