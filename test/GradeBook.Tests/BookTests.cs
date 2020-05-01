using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(1.3);
            book.AddGrade(2.5);
            book.AddGrade(3.234);

            // act
            var result = book.GetStatistics();

            //assert
            
            Assert.Equal(1.3,result.Lowest,1);
            Assert.Equal(3.234,result.Highest,1);
            Assert.Equal(2.3,result.Average,1);
        }
    }
}
