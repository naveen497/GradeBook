using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double Lowest;
        public double Highest;
        public double Sum;
        public int Count;

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90:
                        return 'A';
                    case var d when d >= 80:
                        return 'B';
                    case var d when d >= 70:
                        return 'C';
                    default:
                        return 'F';
                }
            }
        }


        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Highest = double.MinValue;
            Lowest = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Lowest = Math.Min(Lowest, number);
            Highest = Math.Max(Highest, number);
        }


    }
}