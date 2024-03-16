using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    internal class Homework06
    {
        public static void Method()
        {
            int[] array = new int[10];
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number == 0)
                {
                    break;
                }
                else
                {
                    array[i] = number;
                    j++;
                }
            }

            int summ = 0;

            for(int i = 0; i < array.Length;i++)
            {
                summ = summ + array[i];
            }
            Console.WriteLine(summ);

            double result = (double) summ / j;

            Console.WriteLine(result);
        }
    }
}
