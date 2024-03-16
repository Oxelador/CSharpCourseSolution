using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework11.XOgame
{
    public class XOgame
    {
        private readonly State[] board = new State[9];
        public int MovesCounter { get; private set; }

        public XOgame()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = State.Unset;
            }
        }

        //can use in Main
        public static XOgame g = new XOgame();
        public static void start()
        {
            Console.WriteLine(GetPrintableState());

            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result: {g.GetWinner()}");
        }

        public static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |     |")
                    .AppendLine(
                    $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  |")
                    .AppendLine("_____|_____|_____|");
            }
            return sb.ToString();
        }

        static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if (state == State.Unset)
                return index.ToString();
            return state == State.Cross ? "X" : "O";
        }

        public void MakeMove(int index)
        {
            board[index - 1] = MovesCounter % 2 == 0 ? State.Cross : State.Zero;

            MovesCounter++;
        }

        public State GetState(int index)
        {
            return board[index - 1];
        }

        public Winner GetWinner()
        {
            return GetWinner(1, 4, 7, 2, 5, 8, 3, 6, 9,
                             1, 2, 3, 4, 5, 6, 7, 8, 9,
                             1, 5, 9, 3, 5, 7);
        }

        private Winner GetWinner(params int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i += 3)
            {
                bool same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);
                if (same)
                {
                    State state = GetState(indexes[i]);
                    if (state != State.Unset)
                    {
                        return state == State.Cross ? Winner.Crosses : Winner.Zeroes;
                    }
                }
            }
            if (MovesCounter < 9)
            {
                return Winner.GameIsUnfinished;
            }
            return Winner.Draw;
        }
        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }
    }
}
