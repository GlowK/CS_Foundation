using System.Collections.Generic;
using System;

namespace GradeBook{
    public class Book{
        public List<double> grades;
        public string Name;

        public Book(string name){
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade){
            if(grade <= 100 && grade >= 0){
                this.grades.Add(grade);
            }else{
                System.Console.WriteLine("Invalid value");
            }   
        }

        public Statistics GetStats(){
            var result = new Statistics();
            result.Avarage = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in this.grades){
                result.High = System.Math.Max(grade, result.High);
                result.Low = System.Math.Min(grade, result.Low);
                result.Avarage += grade;
            }

            result.Avarage = result.Avarage/grades.Count;
            return result;
        }

        public void ShowStats(Statistics result){
            System.Console.WriteLine($"Avarage = {result.Avarage}");
            System.Console.WriteLine($"Najnizsza = {result.Low}");
            System.Console.WriteLine($"Najwyzsza = {result.High}");
        }
    }
}