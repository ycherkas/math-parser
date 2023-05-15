using MathParser.Context;
using MathParser.Enums;
using MathParser.Helpers;
using System.Xml.Linq;

namespace MathParser.Nodes
{
    // NodeBinary for binary operations such as Add, Subtract etc...
    public class NodeFunction : Node
    {
        public NodeFunction(Node leftNode, Node rightNode, MathOperations operation)
        {
            Children.Add(leftNode);
            Children.Add(rightNode);
            Operation = operation;
        }

        public NodeFunction(MathOperations operation, Node node)
        {
            Operation = operation;
            Children.Add(node);
        }

        public NodeFunction(MathOperations operation, IEnumerable<Node> args)
        {
            Operation = operation;
            Children.AddRange(args);
        }

        public override bool IsTerminal => false;

        private Node _leftNode => Children[0];

        private Node _rightNode => Children[1];

        public override double Eval(IContext context)
        {
            if (Children.Count == 1)
            {
                if (_leftNode is NodeNumber)
                {
                    var nodeNumber = (NodeNumber)_leftNode;
                    return Operation == MathOperations.Minus ? -1 * nodeNumber.Number : nodeNumber.Number;
                }
                else if (_leftNode is NodeVariable)
                {
                    return Operation == MathOperations.Minus ? -1 * _leftNode.Eval(context) : _leftNode.Eval(context);
                }
            }

            var leftVal = _leftNode.Eval(context);
            var rightVal = _rightNode.Eval(context);

            var function = FuncHelper.GetBinary(Operation);

            var result = function(leftVal, rightVal);

            return result;
        }

        public override string ToString()
        {
            if (Operation == MathOperations.Minus)
                return $"-{_leftNode.ToString()}";

            if (Children.Count == 1)
                return _leftNode.ToString();

            return $"{_leftNode.ToString()}{Operation.Value()}{_rightNode.ToString()}";
        }
    }
}
