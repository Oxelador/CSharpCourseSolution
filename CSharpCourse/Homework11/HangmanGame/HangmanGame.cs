using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework11.HangmanGame
{
    public class HangmanGame
    {
        private readonly int allowedMisses;
        private bool[] openIndexes;
        private int triesCounter = 0;
        private string triedLetters;

        public GameStatus GameStatus { get; private set; } = GameStatus.NotStarted;

        public string Word { get; private set; }

        public string TriedLetters
        {
            get
            {
                var chars = triedLetters.ToCharArray();
                Array.Sort(chars);
                return new string(chars);
            }
        }

        public int RemainingTries 
        {
            get
            {
                return allowedMisses - triesCounter;
            }
        }

        public HangmanGame(int allowedMisses = 6)
        {
            if (allowedMisses < 5 || allowedMisses > 8)
            {
                throw new ArgumentException("Number of allowed misses shoud be between 5 and 8");
            }

            this.allowedMisses = allowedMisses;
        }

        public string GenerateWord()
        {
            string[] words = File.ReadAllLines("Homework11\\HangmanGame\\WordsStockRus.txt");
            Random r = new Random(DateTime.Now.Millisecond);
            int randomIndex = r.Next(words.Length - 1);

            Word = words[randomIndex];

            openIndexes = new bool[Word.Length];

            GameStatus = GameStatus.InProgress;
            
            return Word;
        }

        public string GuessLetter(char letter)
        {
            if(triesCounter == allowedMisses)
            {
                throw new InvalidOperationException($"Exceeded the max misses number: {allowedMisses}");
            }
            if(GameStatus != GameStatus.InProgress)
            {
                throw new InvalidOperationException($"Inaproppriate status of the game: {GameStatus}");
            }

            bool openAny = false;

            string result = string.Empty;
            for( int i = 0; i < Word.Length; i++ )
            {
                if (Word[i] == letter)
                {
                    openIndexes[i] = true;
                    openAny = true;
                }

                if (openIndexes[i])
                {
                    result += Word[i];
                }
                else
                {
                    result += "-";
                }
            }

            if(!openAny)
                triesCounter++;

            triedLetters += letter;

            if (IsWin())
            {
                GameStatus = GameStatus.Won;
            }
            else if (triesCounter == allowedMisses)
                GameStatus = GameStatus.Lost;

            return result;
        }

        private bool IsWin()
        {
            foreach(var cur in openIndexes)
            {
                if(cur == false)
                {
                    return false;
                }
            }
            return true;
        }
        public static void start()
        {

            HangmanGame game = new HangmanGame();

            string word = game.GenerateWord();

            Console.WriteLine($"The word consists of {word.Length} letters.");
            Console.WriteLine("Try to guess the word.");

            while(game.GameStatus == GameStatus.InProgress)
            {
                Console.WriteLine("Pick a letter");
                char c = (char)Console.ReadLine().ToCharArray()[0];

                string curState = game.GuessLetter(c);
                Console.WriteLine(curState);

                Console.WriteLine($"Remaining tries = {game.RemainingTries}");
                Console.WriteLine($"Tried letters:{game.TriedLetters}");
            }

            if(game.GameStatus == GameStatus.Lost)
            {
                Console.WriteLine("You're hanged.");
                Console.WriteLine($"The word was: {game.Word}");
            }
            else if (game.GameStatus == GameStatus.Won)
            {
                Console.WriteLine("You won!");
            }
            Console.ReadLine();
        }
    }
}
