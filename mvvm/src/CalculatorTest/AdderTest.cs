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

            var term1 = new Term();
            term1.Value = 1;

            var term2 = new Term();
            term2.Value = 2;

            target.Terms.Add(term1);
            target.Terms.Add(term2);

            target.AddExecute();

            target.Result.Is(3);
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(-3, -1, -2)]
        public void Test2(int expected, int x, int y)
        {
            var target = new Adder();

            var term1 = new Term();
            term1.Value = x;

            var term2 = new Term();
            term2.Value = y;

            target.Terms.Add(term1);
            target.Terms.Add(term2);

            target.AddExecute();

            target.Result.Is(expected);
        }
    }
}
