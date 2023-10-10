using MathParser.Helpers;
using MathParser.Nodes;

namespace MathParser.Tests.PolynomTests
{
    public class PolynomGeneralDetectingTests
    {
        [Fact]
        public void GeneralVariable1()
        {
            var expression = Simplifier.Simplify("a/(a+1)*x^2+b*x+1/a");

            Assert.False(expression.IsPolynom());
        }

        [Fact]
        public void GeneralVariable2()
        {
            var expression = Simplifier.Simplify("a/(a+1)*x^2+b*x+1/a");
            var variable = ParserManager.Parse("x");

            Assert.True(expression.IsPolynom(new List<NodeBase> { variable }));
        }

        [Fact]
        public void GeneralVariable3()
        {
            var expression = Simplifier.Simplify("sin(x)^3+2*sin(x)^2+3");
            var variable = ParserManager.Parse("sin(x)");

            Assert.True(expression.IsPolynom(new List<NodeBase> { variable }));
        }

        [Fact]
        public void GeneralVariable4()
        {
            var expression = Simplifier.Simplify("(x+1)^3+2*(x+1)^2+3");
            var variable = ParserManager.Parse("x+1");

            Assert.True(expression.IsPolynom(new List<NodeBase> { variable }));
        }
    }
}