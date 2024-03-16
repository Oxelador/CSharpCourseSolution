using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    static class Homework01
    {
        public static void Method()
        {
            Console.WriteLine("Hello, please enter your name...");
            string name = Console.ReadLine();
            Console.WriteLine($"Your name is {name}.");
            Console.WriteLine();

            Console.WriteLine("Enter first integer...");
            int firstInt = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second integer...");
            int secondInt = int.Parse(Console.ReadLine());
            Console.WriteLine($"First int - {firstInt}, second int - {secondInt}.");
            Console.WriteLine();

            int tempInt = firstInt;
            firstInt = secondInt;
            secondInt = tempInt;

            Console.WriteLine(firstInt);
            Console.WriteLine(secondInt);

            Console.WriteLine();
            Console.WriteLine("Enter some integer...");
            string x = Console.ReadLine();
            char[] array = x.ToCharArray();
            Console.WriteLine(array.Length);
        }
    }
}
