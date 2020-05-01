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

        public Statistics GetStatistics()
        {
            var result  = new Statistics();
            result.Average = 0.0;
            result.Highest = double.MinValue;
            result.Lowest = double.MaxValue;
            foreach(var grade in grades){
                result.Lowest = Math.Min(result.Lowest,grade);
                result.Highest = Math.Max(result.Highest,grade);
                result.Average += grade;
            }
            result.Average /=grades.Count;
            return result;
        }

        public string getName(){
            return this.name;
        }
        public void AddGrade(double grade)
        {
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