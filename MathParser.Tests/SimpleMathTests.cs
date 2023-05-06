using MathParser.Contexts;

namespace MathParser.Tests
{
    public class SimpleMathTests
    {
        [Fact]
        public void SerializationTest()
        {
            var test = "1+1";
            var rootTreeNode = Parser.Parse(test);

            Assert.Equal(rootTreeNode.ToString(), test);
        }

        [Fact]
        public void SerializationTest2()
        {
            var test = "a+b/c-e*sin(2*gamma)-f^2";
            var rootTreeNode = Parser.Parse(test);

            Assert.Equal(rootTreeNode.ToString(), test);
        }

        [Fact]
        public void AddTest()
        {
            var context = new SimpleContext();
            Assert.Equal(2, Parser.Parse("1 + 1").Eval(context));
        }

        [Fact]
        public void SubstractTest()
        {
            var context = new SimpleContext();
            Assert.Equal(1, Parser.Parse("2 - 1").Eval(context));
        }

        [Fact]
        public void EvalFormulaTest()
        {
            var variables = new Dictionary<string, double>()
            {
                { "x", 1 },
                { "y", 2 },
                { "z", 3 }
            };
            var context = new SimpleContext(variables);
            var formula = "2*x+y^2-z";
            var expression = Parser.Parse(formula);
            var result = expression.Eval(context);
            Assert.Equal(3, result);
        }
    }
}