using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
    public class NamedObject
    {
        public NamedObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public delegate void GradeAddedDelegate(object sender, EventArgs e);
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    public class InMemoryBook : Book
    {
        List<double> grades;

        // private string name;


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
        public InMemoryBook(string name) : base(name)
        {
            // this.Name = name;
            grades = new List<double>();
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
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