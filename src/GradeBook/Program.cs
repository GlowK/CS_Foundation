using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Kamilek's Grades Book");
            book.GradeAdded += OneGradeAdded;

            EnterGrades(book);
            var stats = book.GetStatistics();
            book.ShowStats(stats);

        }

        private static void EnterGrades(IBook book)
        {
            var done = false;

            while (!done)
            {
                System.Console.WriteLine("Please enter grade or pres q to quite");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    done = true;
                    continue;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("**");
                }
            }
        }

        static void OneGradeAdded(object sender, EventArgs e){
            System.Console.WriteLine("A grade has been aded");
        }
    }
}
