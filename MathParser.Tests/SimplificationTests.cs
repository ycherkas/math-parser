using MathParser.Contexts;

namespace MathParser.Tests
{
    public class SimplificationTests
    {
        [Fact]
        public void AddTest()
        {
            var simpliefied = Simplifier.Simplify("1 + 1");

            Assert.Equal("2", simpliefied.ToString());
        }

        [Fact]
        public void SubstractTest()
        {
            var simpliefied = Simplifier.Simplify("1 - 1");

            Assert.Equal("0", simpliefied.ToString());
        }

        [Fact]
        public void AddSubstractTest()
        {
            var simpliefied = Simplifier.Simplify("5 + 3 - 12");

            Assert.Equal("-4", simpliefied.ToString());
        }

        [Fact]
        public void AddVariableTest()
        {
            var simpliefied = Simplifier.Simplify("a + a");

            Assert.Equal("2*a", simpliefied.ToString());
        }

        [Fact]
        public void SubstractVariableTest()
        {
            var simpliefied = Simplifier.Simplify("a - a");

            Assert.Equal("0", simpliefied.ToString());
        }

        [Fact]
        public void AddSubstractVariableTest()
        {
            var simpliefied = Simplifier.Simplify("10*a + 2*a - 5*a + 3*a");

            Assert.Equal("10*a", simpliefied.ToString());
        }
    }
}