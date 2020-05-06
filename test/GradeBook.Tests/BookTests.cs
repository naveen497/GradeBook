using System;
using Xunit;

namespace GradeBook.Tests
{

    public class BookTests
    {


        [Fact]
        public void BookCanComputeStatistics()
        {
            //arrange
            var book = new InMemoryBook("New name");
            book.AddGrade(80.3);
            book.AddGrade(82.5);
            book.AddGrade(90.234);

            // act
            var result = book.GetStatistics();

            //assert

            Assert.Equal(80.3, result.Lowest, 1);
            Assert.Equal(90.234, result.Highest, 1);
            Assert.Equal(84.34, result.Average, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void TestingTheInputValidation()
        {
            //arrange
            var book = new InMemoryBook("l;j");
            
            //act and assert
            Assert.Throws<ArgumentException>(()=>book.AddGrade(-2.3));

        }
    }
}
