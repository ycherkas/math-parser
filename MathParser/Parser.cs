using MathParser.Nodes;

namespace MathParser
{
    public class Parser
    {
        public static NodeBase Parse(string input)
        {
            var tokenizer = new Tokenizer(input);
            var parser = new ParserProcessor(tokenizer);

            return parser.ParseExpression();
        }
    }
}
