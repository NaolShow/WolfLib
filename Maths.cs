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

        // Pythagoras
        public static double pythagoras(double ab, double bc)
        {
            double sqh = ab * ab + bc * bc;
            return Math.Sqrt(sqh);
        }

#region area

        // Square area
        public static double squareArea(double side)
        {
            return side * side;
        }

        // Circle area
        public static double circleArea(double radius)
        {
            double r = radius * radius;
            return r * Math.PI;
        }

        // Triangle area
        public static double triangleArea(double baseof, double height)
        {
            return baseof * height / 2;
        }

        // Parallelogram area
        public static double parallelogramArea(double baseof, double height)
        {
            return baseof * height;
        }

        // Trapeze area
        public static double trapezeArea(double largeBase, double smallBase, double height)
        {
            return (largeBase + smallBase) * height / 2;
        }

        // Diamond area
        public static double diamondArea(double largeDiagonal, double smallDiagonal)
        {
            return largeDiagonal * smallDiagonal / 2;
        }

#endregion

        // MORE AFTER /!\

    }
}
