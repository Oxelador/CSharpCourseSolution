using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework14
{
    partial class BelieveDontBelieveGame
    {

        private static int tries = 0;
        private static int winCount = 0;
        private static string pathToQuestionList = "Homework14\\Questions.csv";
        private static List<Question> questions;
        private static GameStatus currentGameStatus = GameStatus.NotStarted;

        public static void start()
        {
            Console.WriteLine("Welcome to console game \"Believe or don't believe\"!\n" +
                                  "Enter \"start\" to start the game...");

            while (currentGameStatus == GameStatus.NotStarted)
            {
                string start = Console.ReadLine();
                if (start == "start")
                {
                    currentGameStatus = GameStatus.InProgress;
                    CsvToEntity(pathToQuestionList);
                }
                else
                {
                    Console.WriteLine("Wrong input, try again!");
                }  
            }
            while (currentGameStatus != GameStatus.GameIsOver)
            {
                string answer;

                Console.WriteLine("Answer the questions: Yes or No. \n" +
                                      "You have 2 attempts, if you enter an incorrect answer your attempt will be taken away, be careful! ");

                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Question number {i+1}: {questions[i].Quest}");
                    answer = Console.ReadLine();
                    if(answer == questions[i].Answer)
                    {
                        Console.WriteLine($"Right! {questions[i].Explain}");
                        winCount++;
                    }
                    else
                    {
                        tries++;
                        Console.WriteLine($"Wrong! Current attempt is {tries}.");
                    }
                    if (tries == 2)
                    {
                        Console.WriteLine("You lose :( ");
                        currentGameStatus = GameStatus.GameIsOver;
                        break;
                    }
                    if (winCount == questions.Count)
                    {
                        Console.WriteLine("You win!");
                        currentGameStatus = GameStatus.GameIsOver;
                    }
                }
            }

        }

        private static void CsvToEntity(String line)
        {
            questions = File.ReadAllLines(line)
                            .Select(Question.ParseCsvWithQuestions)
                            .ToList();
        }
    }
}
