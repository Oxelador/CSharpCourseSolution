
using CSharpCourse.Homework12;
using CSharpCourse.Homework13;
using CSharpCourse.Test;
using System.ComponentModel;

using System.Runtime.CompilerServices;

namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ChessPlayer> result = LinqHomework1.GetChessPlayers();
            foreach(ChessPlayer player in result)
            {
                Console.WriteLine(player);
            }
        }
    }
}