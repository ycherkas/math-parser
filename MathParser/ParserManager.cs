using MathParser.Nodes;

namespace MathParser
{
    public class ParserManager
    {
        public static NodeBase Parse(string input)
        {
            var tokenizer = new Tokenizer(input);
            var parser = new Parser(tokenizer);

            return parser.ParseExpression();
        }
    }
}
