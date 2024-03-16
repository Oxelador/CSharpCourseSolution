using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    internal class Homework07
    {
        public static void Method()
        {
            int number = int.Parse(Console.ReadLine());
            
            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result*= i;
            }
            Console.WriteLine(result);
        }
    }
}
