using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gUI_Control_Robot
{
    class inverse_Kinematics
    {
        public static void Set1(double px, double py, double pz, out double t1, out double t2, out double t3, out double t4, out char check)
        {
            double l1 = 150;
            double l2 = 350;
            double l3 = 362.5;
            double l4 = 230;
            double d1 = 160;
            double t234 = 0;
            t1 = Math.Atan2(py, px) * 180.0 / Math.PI;
            double nx = px * Math.Cos(t1 * Math.PI / 180.0) + py * Math.Sin(t1 * Math.PI / 180.0) - l4 * Math.Cos(t234 * Math.PI / 180.0) - l1;
            double ny = d1 - pz - l4 * Math.Sin(t234 * Math.PI / 180.0);

            double c3 = (nx * nx + ny * ny - l3 * l3 - l2 * l2) / (2 * l3 * l2);
            double s3 = Math.Sqrt(1 - c3 * c3);
            t3 = Math.Atan2(s3, c3) * 180.0 / Math.PI;

            double c2 = (nx * (l3 * c3 + l2) + l3 * s3 * ny) / ((l3 * c3 + l2) * (l3 * c3 + l2) + (l3 * s3) * (l3 * s3));
            double s2 = Math.Sqrt(1 - c2 * c2);
            t2 = Math.Atan2(s2, c2) * 180.0 / Math.PI;

            t4 = t234 - t2 - t3;
            check = check_Forward.CheckForward(px, py, pz, t1, t2, t3, t4);
        }

        public static void Set2(double px, double py, double pz, out double t1, out double t2, out double t3, out double t4, out char check)
        {
            double l1 = 150;
            double l2 = 350;
            double l3 = 362.5;
            double l4 = 230;
            double d1 = 160;
            double t234 = 0;
            t1 = Math.Atan2(py, px) * 180.0 / Math.PI;
            double nx = px * Math.Cos(t1 * Math.PI / 180.0) + py * Math.Sin(t1 * Math.PI / 180.0) - l4 * Math.Cos(t234 * Math.PI / 180.0) - l1;
            double ny = d1 - pz - l4 * Math.Sin(t234 * Math.PI / 180.0);

            double c3 = (nx * nx + ny * ny - l3 * l3 - l2 * l2) / (2 * l3 * l2);
            double s3 = -Math.Sqrt(1 - c3 * c3);
            t3 = Math.Atan2(s3, c3) * 180.0 / Math.PI;

            double c2 = (nx * (l3 * c3 + l2) + l3 * s3 * ny) / ((l3 * c3 + l2) * (l3 * c3 + l2) + (l3 * s3) * (l3 * s3));
            double s2 = Math.Sqrt(1 - c2 * c2);
            t2 = Math.Atan2(s2, c2) * 180.0 / Math.PI;

            t4 = t234 - t2 - t3;
            check = check_Forward.CheckForward(px, py, pz, t1, t2, t3, t4);
        }

        public static void Set3(double px, double py, double pz, out double t1, out double t2, out double t3, out double t4, out char check)
        {
            double l1 = 150;
            double l2 = 350;
            double l3 = 362.5;
            double l4 = 230;
            double d1 = 160;
            double t234 = 0;
            t1 = Math.Atan2(py, px) * 180.0 / Math.PI;
            double nx = px * Math.Cos(t1 * Math.PI / 180.0) + py * Math.Sin(t1 * Math.PI / 180.0) - l4 * Math.Cos(t234 * Math.PI / 180.0) - l1;
            double ny = d1 - pz - l4 * Math.Sin(t234 * Math.PI / 180.0);

            double c3 = (nx * nx + ny * ny - l3 * l3 - l2 * l2) / (2 * l3 * l2);
            double s3 = Math.Sqrt(1 - c3 * c3);
            t3 = Math.Atan2(s3, c3) * 180.0 / Math.PI;

            double c2 = (nx * (l3 * c3 + l2) + l3 * s3 * ny) / ((l3 * c3 + l2) * (l3 * c3 + l2) + (l3 * s3) * (l3 * s3));
            double s2 = -Math.Sqrt(1 - c2 * c2);
            t2 = Math.Atan2(s2, c2) * 180.0 / Math.PI;

            t4 = t234 - t2 - t3;
            check = check_Forward.CheckForward(px, py, pz, t1, t2, t3, t4);
        }

        public static void Set4(double px, double py, double pz, out double t1, out double t2, out double t3, out double t4, out char check)
        {
            double l1 = 150;
            double l2 = 350;
            double l3 = 362.5;
            double l4 = 230;
            double d1 = 160;
            double t234 = 0;
            t1 = Math.Atan2(py, px) * 180.0 / Math.PI;
            double nx = px * Math.Cos(t1 * Math.PI / 180.0) + py * Math.Sin(t1 * Math.PI / 180.0) - l4 * Math.Cos(t234 * Math.PI / 180.0) - l1;
            double ny = d1 - pz - l4 * Math.Sin(t234 * Math.PI / 180.0);

            double c3 = (nx * nx + ny * ny - l3 * l3 - l2 * l2) / (2 * l3 * l2);
            double s3 = -Math.Sqrt(1 - c3 * c3);
            t3 = Math.Atan2(s3, c3) * 180.0 / Math.PI;

            double c2 = (nx * (l3 * c3 + l2) + l3 * s3 * ny) / ((l3 * c3 + l2) * (l3 * c3 + l2) + (l3 * s3) * (l3 * s3));
            double s2 = -Math.Sqrt(1 - c2 * c2);
            t2 = Math.Atan2(s2, c2) * 180.0 / Math.PI;

            t4 = t234 - t2 - t3;
            check = check_Forward.CheckForward(px, py, pz, t1, t2, t3, t4);
        }
    }
}
