using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        private int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate logDelegate;
            logDelegate = ReturnMessage;
            logDelegate+=IncrementCounter;
            // logDelegate = new WriteLogDelegate(ReturnMessage);
            var result = logDelegate("Hello");
            Assert.Equal(2,count);
        }

        string IncrementCounter(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        [Fact]
        public void Test1()
        {
            //arrange
            var book = new Book("old Name");
            var x = 22;

            // act
            // var result = book.GetStatistics();
            SetTheValue(x);
            SetTheName(book, "new Name");

            //assert

            // Assert.Equal(1.3,result.Lowest,1);
            // Assert.Equal(3.234,result.Highest,1);
            // Assert.Equal(2.3,result.Average,1);
            Assert.Equal(22, x);
            Assert.Equal("new Name", book.GetName());
        }

        private void SetTheName(Book book, string v)
        {
            book.Name = v;
        }

        private void SetTheValue(int x)
        {
            x = 25;

        }
    }
}
