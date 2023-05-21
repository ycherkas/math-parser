using MathParser.Context;

namespace MathParser.Nodes
{
    // Represents a variable (or a constant) in an expression.  eg: "2 * pi"
    public class NodeVariable : NodeBase
    {
        string _variableName;

        public NodeVariable(string variableName)
        {
            _variableName = variableName;
        }

        public override string StringValue => Name;

        public override bool IsTerminal => false;

        public string Name => _variableName;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is string)
            {
                if ((string)obj == Name)
                    return true;
                else
                    return false;
            }

            var v = obj as NodeVariable;
            if (v != null)
                return v.Name == Name;
            else
                return false;
        }

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
