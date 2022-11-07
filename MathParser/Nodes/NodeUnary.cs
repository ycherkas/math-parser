using MathParser.Context;
using MathParser.Enums;
using MathParser.Helpers;

namespace MathParser.Nodes
{
    // NodeUnary for unary operations such as Negate
    public class NodeUnary : Node
    {
        private Node _node;
        private OperationUnary _operation;

        public NodeUnary(Node node, OperationUnary operation)
        {
            _node = node;
            _operation = operation;
        }

        public override double Eval(IContext context)
        {
            var rhsVal = _node.Eval(context);

            var function = FuncHelper.GetUnary(_operation);

            var result = function(rhsVal);

            return result;
        }

        public override string ToString()
        {
            return $"{_operation.Value()}{_node.ToString()}";
        }
    }
}
