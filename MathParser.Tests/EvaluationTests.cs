using MathParser.Contexts;

namespace MathParser.Tests
{
    public class EvaluationTests
    {
        [Fact]
        public void AddTest()
        {
            var context = new SimpleContext();
            Assert.Equal(2, ParserManager.Parse("1 + 1").Eval(context));
        }

        [Fact]
        public void SubstractTest()
        {
            var context = new SimpleContext();
            Assert.Equal(1, ParserManager.Parse("2 - 1").Eval(context));
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
            var expression = ParserManager.Parse(formula);
            var result = expression.Eval(context);
            Assert.Equal(3, result);
        }
    }
}