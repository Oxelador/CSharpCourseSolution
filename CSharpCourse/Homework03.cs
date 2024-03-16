using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    static class Homework03
    {
        public static void Method()
        {
            Console.WriteLine("Let's create your profile!");
            Console.WriteLine("Enter your Surname...");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter your Name...");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Age...");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Weight in kg...");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Height in meters...");
            double height = double.Parse(Console.ReadLine());

            double bmi = weight / (height * height);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Your profile:")
              .AppendLine($"Full Name: {surname}, {name}")
              .AppendLine($"Age: {age}")
              .AppendLine($"Weight: {weight}")
              .AppendLine($"Height: {height}")
              .AppendLine($"Body Mass Index: {bmi}");
            Console.WriteLine(sb);
        }
    }
}
