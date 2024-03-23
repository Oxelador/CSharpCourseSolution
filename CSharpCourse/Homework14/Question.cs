using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework14
{
    class Question
    {
        public string Quest { get; set; }
        public string Answer { get; set; }
        public string Explain { get; set; }

        public static Question ParseCsvWithQuestions(string file)
        {
            string[] array = file.Split(';');
            return new Question
            {
                Quest = array[0],
                Answer = array[1],
                Explain = array[2]
            };
        }
    }
}
