using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WolfLib
{
    public class Maths
    {

        /**
         *  Developed by NaolShow (Loan.J)
         *  Sources and DLL on github.com
         *  https://github.com/NaolShow/WolfLib
         *  
         **/

        public static double pythagoras(double ab, double bc)
        {
            return Math.Sqrt(ab * ab + bc * bc);
        }

#region area

        public static double squareArea(double side)
        {
            return side * side;
        }

        public static double circleArea(double radius)
        {
            double r = radius * radius;
            return r * Math.PI;
        }

        public static double triangleArea(double baseof, double height)
        {
            return baseof * height / 2;
        }

        public static double parallelogramArea(double baseof, double height)
        {
            return baseof * height;
        }

        public static double trapezeArea(double largeBase, double smallBase, double height)
        {
            return (largeBase + smallBase) * height / 2;
        }

        public static double diamondArea(double largeDiagonal, double smallDiagonal)
        {
            return largeDiagonal * smallDiagonal / 2;
        }

#endregion

        // MORE AFTER /!\

    }
}
