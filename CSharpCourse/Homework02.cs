using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    static class Homework02
    {
        public static void Method()
        {
            Console.WriteLine("Enter 1st triangle side...");
            double firstSide = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd triangle side...");
            double secondSide = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter 3th triangle side...");
            double thirdSide = double.Parse(Console.ReadLine());
            Console.WriteLine();

            double p = (firstSide + secondSide + thirdSide) / 2;
            Console.WriteLine($"Semiperimeter is {p}");
            double s = Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
            string formattedS = String.Format("{0:0.00}", s);
            Console.WriteLine($"Square of the triangle = {formattedS}");
        }
    }
}
