using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.utils
{
    class Deviation
    {
        private static int Camera_X_Ratio = 1408;
        private static int Camera_Y_Ratio = 1024;
        public double angle;

        //public static double CalculateAngle(double InstallDis)
        //{

        //    return 
        //}

        public static double CalculateInstallDis(double RobotHeight,double MatThickness,double route)
        {
            return RobotHeight - route - 316.5 - MatThickness;
        }


    }
}
