using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs e);
    public class Book
    {
        List<double> grades;

        // private string name;

        public string Name{
            get;
            set;
        }
        // public string Name{
        //     get{
        //         return name;
        //     }
        //     set{
        //         if(!String.IsNullOrEmpty(value)){
        //             name = value;
        //         }
        //         else{
        //             throw new InvalidDataException($"Invalid {nameof(value)} entered for book name");
        //         }
        //     }
        // }
        public Book(string name)
        {
            this.Name = name;
            grades = new List<double>();
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var resutl = new Statistics();
            result.Average = 0.0;
            result.Highest = double.MinValue;
            result.Lowest = double.MaxValue;
            foreach (var grade in grades)
            {
                result.Lowest = Math.Min(result.Lowest, grade);
                result.Highest = Math.Max(result.Highest, grade);
                result.Average += grade;
            }
            result.Average /= grades.Count;
            switch (result.Average)
            {
                case var d when d >= 90:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70:
                    result.Letter = 'C';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;
        }

        public GradeAddedDelegate GradeAdded;

        public string GetName()
        {
            return this.Name;
        }
        public void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                grades.Add(grade);
                if(GradeAdded != null){
                GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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
                case 'D':
                    AddGrade(90);
                    break;
                default:
                    break;
            }
        }
    }
}