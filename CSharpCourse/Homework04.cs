using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    static class Homework04
    {
        public static void Method()
        {
            Console.WriteLine("Enter 1st integer...");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd integer...");
            int y = int.Parse(Console.ReadLine());

            if(x > y)
                Console.WriteLine(x);
            else
                Console.WriteLine(y);
        }
    }
}
