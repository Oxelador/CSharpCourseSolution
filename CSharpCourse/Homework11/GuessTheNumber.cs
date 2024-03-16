using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework11
{
    internal class GuessTheNumber
    {
        public void start()
        {
            Console.WriteLine("Нажмите:");
            Console.WriteLine("1 - задать число");
            Console.WriteLine("2 - отгадать число");

            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    HumanGuesses();
                    break;
                case 2:
                    MachineGuesses();
                    break;
                default:
                    Console.WriteLine("Неверное число!");
                    break;
            }
        }

        //done
        public void HumanGuesses() 
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            
            int tries = 5;
            Console.WriteLine("Отгадайте число от 0 до 100, у вас есть 5 попыток.");
            while (!(tries < 1)) 
            {
                int number = int.Parse(Console.ReadLine());
                if(number == randomNumber) 
                {
                    Console.WriteLine("Вы победили!");
                    break;
                } else if(number > randomNumber)
                {
                    tries--;
                    Console.WriteLine("Введеное число больше загаданного");
                } else if(number < randomNumber)
                {
                    tries--;
                    Console.WriteLine("Введеное число меньше загаданного");
                } else if(tries == 0)
                {
                    Console.WriteLine("Попытки закончились, вы проиграли!");
                }
            }
        }

        //done
        public void MachineGuesses()
        {
            Console.WriteLine("Задайте число от 0 до 100");
            int number = int.Parse(Console.ReadLine());

            int lastGuess = -1;
            int min = 0;
            int max = 100;
            int tries = 0;

            while (lastGuess != number && tries < 5)
            {
                lastGuess = (max + min) / 2;
                Console.WriteLine($"Вы загадали это число {lastGuess}");
                Console.WriteLine("Если да введите - Да, если число больше введите - 1, если число меньше введите - 2...");

                string answer = Console.ReadLine();
                if(answer == "Да")
                {
                    Console.WriteLine("Ура, я угадал!");
                    break ;
                } else if(answer == "1")
                {
                    min = lastGuess;
                    
                } else
                {
                    max = lastGuess;
                    
                }

                if(lastGuess == number)
                {
                    Console.WriteLine("Обманывать нехорошо!");
                }
                tries++;
                if(tries == 5)
                {
                    Console.WriteLine("Больше не осталось попыток ;[ Я Проиграл ");
                }
            }

        }
    }
}
