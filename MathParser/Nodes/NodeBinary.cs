using MathParser.Context;
using MathParser.Enums;
using MathParser.Helpers;

namespace MathParser.Nodes
{
    // NodeBinary for binary operations such as Add, Subtract etc...
    public class NodeBinary : Node
    {
        private Node _leftNode;
        private Node _rightNode;
        private OperationBinary _operation;

        public NodeBinary(Node leftNode, Node rightNode, OperationBinary operation)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
            _operation = operation;
        }

        public override double Eval(IContext context)
        {
            var leftVal = _leftNode.Eval(context);
            var rightVal = _rightNode.Eval(context);

            var function = FuncHelper.GetBinary(_operation);

            var result = function(leftVal, rightVal);

            return result;
        }

        public override string ToString()
        {
            return $"{_leftNode.ToString()}{_operation.Value()}{_rightNode.ToString()}";
        }
    }
}
