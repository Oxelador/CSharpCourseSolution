using CSharpCourse.Homework13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Test
{
    class LinqHomework1
    {
        private static string file = "Homework13\\Top100ChessPlayers.csv";
        private static List<ChessPlayer> result;

        public static void RussiansChessPlayers()
        {
            result = File.ReadAllLines(file)
                         .Skip(1)
                         .Select(ChessPlayer.ParseFideCsv)
                         .Where(player => player.Country == "RUS")
                         .OrderBy(player => player.BirthDayYear)
                         .ToList();

        }

        public static List<ChessPlayer> GetChessPlayers()
        {
            RussiansChessPlayers();
            return result;
        }
        
    }
}
