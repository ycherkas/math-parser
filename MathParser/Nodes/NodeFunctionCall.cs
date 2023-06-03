using MathParser.Context;

namespace MathParser.Nodes
{
    public class NodeFunctionCall : NodeBase
    {
        public NodeFunctionCall(string functionName, NodeBase[] arguments)
        {
            StringValue = functionName;
            Children.AddRange(arguments);
        }

        public override double Eval(IContext context)
        {
            var argVals = new double[Children.Count];

            for (int i = 0; i < Children.Count; i++)
            {
                argVals[i] = Children[i].Eval(context);
            }

            return context.CallFunction(StringValue, argVals);
        }

        public override string ToString()
        {
            return $"{StringValue}({string.Join(',', Children.Select(a=>a.ToString()))})";
        }
    }
}
