using MathParser.Helpers;

namespace MathParser.Tests.PolynomTests
{
    public class ExpandTests
    {
        [Fact]
        public void ExpandPower1()
        {
            var expression = ExpandHelpers.ExpandAlgebraic("(a+b)^2");

            Assert.Equal("a^2+a*b*2+b^2", expression.ToString());
        }

        [Fact]
        public void ExpandPower2()
        {
            var expression = ExpandHelpers.ExpandAlgebraic("(a+b+c)^2");

            Assert.Equal("a^2+b*a*2+c*a*2+b^2+b*c*2+c^2", expression.ToString());
        }

        [Fact]
        public void ExpandMult1()
        {
            var expression = ExpandHelpers.ExpandAlgebraic("(a+b)*(a+b+c)");

            Assert.Equal("a^2+b*a*2+b^2+a*c+b*c", expression.ToString());
        }
    }
}