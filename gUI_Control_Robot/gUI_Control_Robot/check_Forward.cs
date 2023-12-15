using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gUI_Control_Robot
{
    class check_Forward
    {
        public static char checkTheta(double minTheta, double maxTheta, double theta)
        {
            if(theta > minTheta && theta < maxTheta)
            {
                return 'C';   
            }
            else
            {
                return 'U';
            }
        }
        public static char CheckForward(double t1, double t2, double t3, double t4)
        {
            char checkT1 = checkTheta(-90, 90, t1);
            char checkT2 = checkTheta(-45, 180, t2);
            char checkT3 = checkTheta(-180, 120, t3);
            char checkT4 = checkTheta(-135, 120, t4);

            if(checkT1 == 'C' && checkT2 == 'C' && checkT3 == 'C' && checkT4 == 'C')
            {
                return 'C';
            }
            else
            {
                return 'U';
            }
        }
    }
}
