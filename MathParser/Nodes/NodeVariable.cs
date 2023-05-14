using MathParser.Context;

namespace MathParser.Nodes
{
    // Represents a variable (or a constant) in an expression.  eg: "2 * pi"
    public class NodeVariable : Node
    {
        string _variableName;

        public NodeVariable(string variableName)
        {
            _variableName = variableName;
        }

        public override bool IsTerminal => false;

        public override double Eval(IContext ctx)
        {
            return ctx.ResolveVariable(_variableName);
        }

        public override string ToString()
        {
            return _variableName;
        }
    }
}
