using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
           var book = new Book("Allen's Gradebook");
           book.AddGrade(22.6);
           book.AddGrade(22);
           book.AddGrade(32.5);
           book.AddGrade(38.2);
           book.ShowStatistics();

         

        }
    }
}
