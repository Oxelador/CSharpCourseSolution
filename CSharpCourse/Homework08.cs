using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse
{
    internal class Homework08
    {
        public static void Method()
        {
            string login = "johnsilver";
            string password = "qwerty";

            int tries = 0;

            while(tries != 3)
            {
                Console.WriteLine("Enter login: ");
                string enteredLogin = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string enteredPassword = Console.ReadLine();

                if(login.Equals(enteredLogin) && password.Equals(enteredPassword))
                {
                    Console.WriteLine("Enter the System");
                    break;
                } else
                {
                    tries++;
                }
            }
            if(tries == 3)
            {
                Console.WriteLine("The number of available tries have been exceeded");
            }


        }
    }
}
