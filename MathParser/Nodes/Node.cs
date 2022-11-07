using MathParser.Context;

namespace MathParser.Nodes
{
    public abstract class Node
    {
        public abstract double Eval(IContext context);
    }
}
