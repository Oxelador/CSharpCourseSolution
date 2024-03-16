using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    public class Homework10
    {
        public static double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        public static double CalcTriangleSquare(double ab, double ac, int alpha)
        {
            return 0.5 * ab * ac * Math.Sin(alpha);
        }
    }
}
