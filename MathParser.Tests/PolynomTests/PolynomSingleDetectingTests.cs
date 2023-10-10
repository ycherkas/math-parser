using MathParser.Helpers;

namespace MathParser.Tests.PolynomTests
{
    public class PolynomSingleDetectingTests
    {
        [Fact]
        public void SingleVariable1()
        {
            var expression = Simplifier.Simplify("x^2-x+2");

            Assert.True(expression.IsPolynomSingle());
        }

        [Fact]
        public void SingleVariable2()
        {
            var expression = Simplifier.Simplify("3*x^6+2*x^4-5/2");

            Assert.True(expression.IsPolynomSingle());
        }
    }
}