using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        List<double> grades;
        double highestGrade ;
        double lowestGrade;
        double average;
        string name; 
        public Book(string name)
        {
            highestGrade = double.MinValue;
            lowestGrade = double.MaxValue;
            average = 0.0; 
            this.name = name;
            grades = new List<double>();
        }

        public void ShowStatistics()
        {
         Console.WriteLine($"{this.name}");
         Console.WriteLine($"The average grade is {this.getAverageGrade()}");
         Console.WriteLine($"The lowest grade is {this.getLowestGrade()}");
         Console.WriteLine($"The highest grade is {this.getHighestGrade()}");
        }

        public string getName(){
            return this.name;
        }
        public void AddGrade(double grade)
        {
            if (grade < lowestGrade)
            {
                lowestGrade = grade;
            }
            if (grade > highestGrade)
            {
                highestGrade = grade;
            }
            double prevSum = average * grades.Count;
            average = (prevSum + grade) / (grades.Count + 1);
            grades.Add(grade);
        }

        public double getAverageGrade()
        {
            return average;
        }

        public double getLowestGrade()
        {
            return lowestGrade;
        }
        public double getHighestGrade()
        {
            return highestGrade;
        }
    }
}