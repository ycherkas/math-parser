using MathParser.Context;

namespace MathParser.Nodes
{
    // Represents a variable (or a constant) in an expression.  eg: "2 * pi"
    public class NodeVariable : NodeBase
    {
        public NodeVariable(string variableName)
        {
            StringValue = variableName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is string)
            {
                if ((string)obj == StringValue)
                    return true;
                else
                    return false;
            }

            var v = obj as NodeVariable;
            if (v != null)
                return v.StringValue == StringValue;
            else
                return false;
        }

        public override double Eval(IContext ctx)
        {
            return ctx.ResolveVariable(StringValue);
        }

        public override string ToString()
        {
            return StringValue;
        }
    }
}
