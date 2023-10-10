using MathParser.Helpers;

namespace MathParser.Tests.PolynomTests
{
    public class PolynomMultiDetectingTests
    {
        [Fact]
        public void MultiVariable1()
        {
            var expression = Simplifier.Simplify("x^2*y+x*y^2+2");

            Assert.True(expression.IsPolynomMulti());
        }

        [Fact]
        public void MultiVariable2()
        {
            var expression = Simplifier.Simplify("p+1/2*ρ*v^2+ρ*g*y");

            Assert.True(expression.IsPolynomMulti());
        }

        [Fact]
        public void MultiVariable3()
        {
            var expression = Simplifier.Simplify("a*x^2+2*b*x+3*c");

            Assert.True(expression.IsPolynomMulti());
        }

        [Fact]
        public void MultiVariable4()
        {
            var expression = Simplifier.Simplify("x^2-y^2");

            Assert.True(expression.IsPolynomMulti());
        }

        [Fact]
        public void MultiVariable5()
        {
            var expression = Simplifier.Simplify("m*c^2");

            Assert.True(expression.IsPolynomMulti());
        }
    }
}