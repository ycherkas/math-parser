using MathParser.Context;

namespace MathParser.Nodes
{
    public class NodeFunctionCall : Node
    {
        private string _functionName;
        private Node[] _arguments;

        public NodeFunctionCall(string functionName, Node[] arguments)
        {
            _functionName = functionName;
            _arguments = arguments;
        }

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
            return $"{_functionName}({string.Join(',', _arguments.Select(a=>a.ToString()))})";
        }
    }
}
