using MathParser.Context;
using MathParser.Enums;
using MathParser.Helpers;

namespace MathParser.Nodes
{
    // NodeBinary for binary operations such as Add, Subtract etc...
    public class NodeFunction : NodeBase
    {
        public NodeFunction() { }

        public NodeFunction(MathOperations operation, NodeBase leftNode, NodeBase rightNode)
        {
            Children.Add(leftNode);
            Children.Add(rightNode);
            Operation = operation;
        }

        public NodeFunction(MathOperations operation, NodeBase node)
        {
            Operation = operation;
            Children.Add(node);
        }

        public NodeFunction(MathOperations operation, IEnumerable<NodeBase> args)
        {
            Operation = operation;
            Children.AddRange(args);
        }

        public override string StringValue => Operation.Value() ?? "???";

        public override bool IsTerminal => false;

        private NodeBase _leftNode => Children[0];

        private NodeBase _rightNode => Children[1];

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
                return $"-{ToStringWithParentheses(Children[0])}";

            if (Children.Count == 1)
                return Children[0].ToString();

            var result = string.Empty;

            for (var i = 0; i < Children.Count; i++)
            {
                if(i == Children.Count - 1)
                {
                    result += ToStringWithParentheses(Children[i]);
                } else
                {
                    result += ToStringWithParentheses(Children[i]) + Operation.Value();
                }
            }

            return result;
        }

        private string ToStringWithParentheses(NodeBase node)
        {
            if(Operation == MathOperations.Add || Operation == MathOperations.Subtract)
            {
                return node.ToString();
            }

            if (node.Children.Count > 1)
            {
                return $"({node.ToString()})";
            }

            return node.ToString();
        }
    }
}
