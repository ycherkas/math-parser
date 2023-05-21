using MathParser.Context;

namespace MathParser.Nodes
{
    public class NodeFunctionCall : NodeBase
    {
        private string _functionName;
        private NodeBase[] _arguments;

        public NodeFunctionCall(string functionName, NodeBase[] arguments)
        {
            _functionName = functionName;
            Children.AddRange(arguments);
        }

        public override string StringValue => _functionName;

        public override bool IsTerminal => false;

        public override double Eval(IContext context)
        {
            var argVals = new double[_arguments.Length];

            for (int i = 0; i < _arguments.Length; i++)
            {
                argVals[i] = _arguments[i].Eval(context);
            }

            // Call the function
            return context.CallFunction(_functionName, argVals);
        }

        public override string ToString()
        {
            return $"{_functionName}({string.Join(',', Children.Select(a=>a.ToString()))})";
        }
    }
}
