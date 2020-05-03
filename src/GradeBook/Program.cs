﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("");
            book.GradeAdded+=onGradeAdded;
            book.GradeAdded+=onGradeAdded;
            book.GradeAdded-=onGradeAdded;
            book.GradeAdded+=onGradeAdded;

            //    book.AddGrade(22.6);
            //    book.AddGrade(22);
            //    book.AddGrade(32.5);
            //    book.AddGrade(38.2);

            while (true)
            {
                Console.WriteLine("Please Enter a grade or 'q' to quit:");
                String grade = Console.ReadLine();
                if (grade.Length == 0 || grade.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                try
                {
                    double gd = double.Parse(grade);
                    book.AddGrade(gd);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                    // the block of code that needs to be executed regardless what happens in the try-catch blocks
                    // usually things like closing the file or the DB connection are placed here
                    Console.WriteLine("**");
                }
            }


            var result = book.GetStatistics();
            Console.WriteLine($"Grades for {book.Name}");
            Console.WriteLine($"average: {result.Average:N2}");
            Console.WriteLine($"lowest: {result.Lowest}");
            Console.WriteLine($"highest: {result.Highest}");
            Console.WriteLine($"highest: {result.Highest}");



        }

        static void onGradeAdded(object sender, EventArgs eventArgs){
            Console.WriteLine("Grade added");
        }
    }
}
