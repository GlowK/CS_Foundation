using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book{
        public List<double> grades;
        public override event GradeAddedDelegate GradeAdded;
        string path = "/home/goldrush/Project_C#/gradebook/src/GradeBook/Grades.txt";
        
        public DiskBook(string name) : base(name) 
        {
            grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade)
        {
            
            
            if(grade <= 100 && grade >= 0){
                using (var writer  = File.AppendText(path)){
                    writer.WriteLine(grade);
                }
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }   
        }
        

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText(path))
            {
                var line = reader.ReadLine();
                while (line != null){
                    result.Add(Double.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return result;
        }

        public override void ShowStats(Statistics results)
        {
            System.Console.WriteLine($"For the book named {this.Name}");
            System.Console.WriteLine($"Avarage = {results.Avarage}");
            System.Console.WriteLine($"Low = {results.Low}");
            System.Console.WriteLine($"High = {results.High}");
            System.Console.WriteLine($"The letter grade is = {results.Letter}");

        }
    }
}