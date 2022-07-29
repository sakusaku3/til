using System;
using Xunit;
using Calculator.Models;

namespace CalculatorTest
{
    public class AdderTest
    {
        [Fact]
        public void Test1()
        {
            var target = new Adder();
            target.AddNewTerm();
            target.AddNewTerm();

            target.Terms[0].Value = 1;
            target.Terms[1].Value = 2;

            target.AddExecute();

            target.Result.Is(3);
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(-3, -1, -2)]
        public void Test2(int expected, int x, int y)
        {
            var target = new Adder();
            target.AddNewTerm();
            target.AddNewTerm();

            target.Terms[0].Value = x;
            target.Terms[1].Value = y;

            target.AddExecute();

            target.Result.Is(expected);
        }
    }
}
