using System.Collections.Generic;
using System;

namespace GradeBook{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get;}
        event GradeAddedDelegate GradeAdded;
        void ShowStats(Statistics results);
    }



    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();
        public abstract void ShowStats(Statistics results);
    }

    public class InMemoryBook : Book
    {
        public List<double> grades;
        public override event GradeAddedDelegate GradeAdded;
        public InMemoryBook(string name) : base(name) 
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter){
            switch(letter){
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    System.Console.WriteLine("lol");
                    break;
            }
        }

        public override void AddGrade(double grade){
            if(grade <= 100 && grade >= 0){
                this.grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }   
        }

        public override Statistics GetStatistics(){
            var result = new Statistics();
            for(var index = 0; index < grades.Count; index++){
                result.Add(grades[index]);
            }
            return result;
        }

        public override void ShowStats(Statistics result){
            System.Console.WriteLine($"For the book named {this.Name}");
            System.Console.WriteLine($"Avarage = {result.Avarage}");
            System.Console.WriteLine($"Low = {result.Low}");
            System.Console.WriteLine($"High = {result.High}");
            System.Console.WriteLine($"The letter grade is = {result.Letter}");
        }
    }
}