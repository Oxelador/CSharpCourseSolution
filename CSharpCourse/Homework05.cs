using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    internal class Homework05
    {
        public static void Method()
        {
            Console.WriteLine("enter the desired number of Fibonacci numbers");
            int desiredNumbers = int.Parse(Console.ReadLine());
            int[] result = new int[desiredNumbers];

            int a0 = 0;
            int a1 = 1;

            result[0] = a0;
            result[1] = a1;

            for (int i = 2;  i < desiredNumbers; i++)
            {
                int a = a0 + a1;
                result[i] = a;

                a0 = a1;
                a1 = a;
            }

            foreach (int cur in result)
            {
                Console.WriteLine(cur);
            }
        }
    }
}
