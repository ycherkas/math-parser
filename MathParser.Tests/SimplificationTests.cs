using MathParser.Contexts;

namespace MathParser.Tests
{
    public class SimplificationTests
    {
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

            Assert.Equal("a*2", simpliefied.ToString());
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

            Assert.Equal("a*10", simpliefied.ToString());
        }

        [Fact]
        public void SameVariableDivisionTest()
        {
            var simplified = Simplifier.Simplify("a/a");

            Assert.Equal("1", simplified.ToString());
        }

        [Fact]
        public void SimpleDivisionTest()
        {
            var simplified = Simplifier.Simplify("a*a/a");

            Assert.Equal("a", simplified.ToString());
        }

        [Fact]
        public void PowerTest()
        {
            var simplified = Simplifier.Simplify("a*(a^-1)");

            Assert.Equal("1", simplified.ToString());
        }

        [Fact]
        public void MultipleVariableTest()
        {
            var simpliefied = Simplifier.Simplify("3*x+2*y+2*x+z-2*y+10");

            Assert.Equal("x*5+10+z", simpliefied.ToString());
        }
    }
}