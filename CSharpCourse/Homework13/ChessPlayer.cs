using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework13
{
    class ChessPlayer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public int Games { get; set; }
        public int BirthDayYear { get; set; }

        public static ChessPlayer ParseFideCsv(string line)
        {
            string[] array = line.Split(';');
            return new ChessPlayer()
            {
                Id = int.Parse(array[0]),
                FullName = array[1],
                Title = array[2],
                Country = array[3],
                Rating = int.Parse(array[4]),
                Games = int.Parse(array[5]),
                BirthDayYear = int.Parse(array[6]),
            };
        }
               
        public override string ToString()
        {
            return $"{Id}. Full name - {FullName}. Title - {Title}. Country - {Country}. Rating - {Rating}. Games - {Games}. Birthday Year - {BirthDayYear}.";
        }
    }
}
