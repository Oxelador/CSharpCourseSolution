using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCourse.Homework12
{

    public class SticksGame
    {
        private readonly Random randomizer;

        public int InitialSticksNumber { get; }

        public Player Turn { get; private set; }

        public int RemainingSticks {  get; private set; }

        public GameStatus GameStatus { get; private set; }

        public event Action<int> MachinePlayed;
        public event EventHandler<int> HumanTurnToMakeMove;
        public event Action<Player> EndOfGame;

        public SticksGame(int initialSticksNumber, Player whoMakesFirstMove)
        {
            if (initialSticksNumber < 7 || initialSticksNumber > 30)
                throw new ArgumentException("Initial number of sticks should be >= 7 and <= 30");

            randomizer = new Random();
            GameStatus = GameStatus.NotStarted;
            InitialSticksNumber = initialSticksNumber;
            RemainingSticks = initialSticksNumber;
            Turn = whoMakesFirstMove;
        }

        public void HumanTakes(int sticks)
        {
            if (sticks < 1 || sticks > 3)
                throw new ArgumentException("You can take from 1 to 3 sticks in a single move");

            if (sticks > RemainingSticks)
                throw new ArgumentException($"You can't take more than remaining. Remains:{RemainingSticks}");

            TakeSticks(sticks);
        }

        public static void Run()
        {
            var game = new SticksGame(10, Player.Human);
            game.MachinePlayed += Game_MachinePlayed;
            game.HumanTurnToMakeMove += Game_HumanTurnToMakeMove;
            game.EndOfGame += Game_EndOfGame;

            game.Start();

        }

        private static void Game_EndOfGame(Player player)
        {
            Console.WriteLine($"Winner:{player}");
        }

        private static void Game_HumanTurnToMakeMove(object? sender, int remainingSticks)
        {
            Console.WriteLine($"Remaining sticks:{remainingSticks}");
            Console.WriteLine("Take some sticks");

            bool takenCorrectly = false;
            while (!takenCorrectly)
            {
                if(int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (SticksGame) sender;

                    try
                    {
                        game.HumanTakes(takenSticks);
                        takenCorrectly = true;
                    } catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void Game_MachinePlayed(int sticksTaken)
        {
            Console.WriteLine($"Machine took:{sticksTaken}");
        }

        public void Start()
        {
            if(GameStatus == GameStatus.GameIsOver)
                RemainingSticks = InitialSticksNumber;

            if(GameStatus == GameStatus.InProgress)
            {
                throw new InvalidOperationException("Can't call Start when game is already in progress.");
            }

            GameStatus = GameStatus.InProgress;
            while (GameStatus == GameStatus.InProgress)
            {
                if(Turn == Player.Computer)
                {
                    CompMakesMove();
                }
                else
                {
                    HumanMakesMove();
                }

                FireEndOfGameIfRequired();

                Turn = Turn == Player.Computer ? Player.Human : Player.Computer;
            }
        }

        private void FireEndOfGameIfRequired()
        {
            if(RemainingSticks == 0)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame != null)
                    EndOfGame(Turn = Turn == Player.Computer ? Player.Human : Player.Computer);
            }
        }

        private void HumanMakesMove()
        {
            if (HumanTurnToMakeMove != null)
                HumanTurnToMakeMove(this, RemainingSticks);
        }

        private void CompMakesMove()
        {
            int maxNumber = RemainingSticks >= 3 ? 3 : RemainingSticks;
            int sticks = randomizer.Next(1, maxNumber);

            TakeSticks(sticks);
            if(MachinePlayed != null)
                MachinePlayed(sticks);
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }
    }
}