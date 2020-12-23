using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics{
        public double Avarage
        {
            get
            {
                return Sum/Count;
            }
        }

        public double Low;
        public double High;
        public char Letter
        {
            get
            {
                switch(this.Avarage){
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public double Sum;
        public int Count;

        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number){
            Sum += number; 
            Count += 1;
            High = System.Math.Max(number, this.High);
            Low = System.Math.Min(number, this.Low);
        }

        public void PrintStats(){
            System.Console.WriteLine($"Avarage = {Avarage}");
            System.Console.WriteLine($"Low = {Low}");
            System.Console.WriteLine($"High = {High}");
            System.Console.WriteLine($"The letter grade is = {Letter}");
        }

    }
}