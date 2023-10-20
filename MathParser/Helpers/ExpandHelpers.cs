using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser.Helpers
{
    public static class ExpandHelpers
    {
        public static NodeBase ExpandAlgebraic(string input)
        {
            var expression = Simplifier.Simplify(input);
            var expressionExpanded = ExpandAlgebraic(expression);

            return Simplifier.Simplify(expressionExpanded);
        }

        public static NodeBase ExpandAlgebraic(NodeBase node)
        {
            node = node.ToBinaryForm();

            if (node.Operation == MathOperations.Add)
            {
                var newLeft = ExpandAlgebraic(node.Children[0]);
                var newRight = ExpandAlgebraic(node.Children[1]);
                return new NodeFunction(MathOperations.Add, newLeft, newRight);
            }

            if (node.Operation == MathOperations.Multiply)
            {
                var newLeft = ExpandAlgebraic(node.Children[0]);
                var newRight = ExpandAlgebraic(node.Children[1]);
                return ExpandProduct(newLeft, newRight);
            }

            if (node.Operation == MathOperations.Power && node.Children[1].IsNumber)
            {
                var nodePower = node.Children[1] as NodeNumber;
                if (nodePower != null && MathHelpers.IsInteger(nodePower.Number))
                {
                    var power = (int)nodePower.Number;
                    if (power >= 2)
                    {
                        return ExpandPower(node.Children[0], power);
                    }
                }
            }

            if(node.Operation == MathOperations.Minus)
            {
                node.Children[0] = ExpandAlgebraic(node.Children[0]);
            }

            return node;
        }

        public static NodeBase ExpandProduct(NodeBase left, NodeBase right)
        {
            if (left.Operation == MathOperations.Add)
            {
                var newLeft = ExpandProduct(left.Children[0], right);
                NodeBase newRight;
                if (left.Children.Count > 2)
                {
                    var subLeft = new NodeFunction(MathOperations.Add, left.Children.Skip(1));
                    newRight = ExpandProduct(subLeft, right);
                }
                else
                {
                    newRight = ExpandProduct(left.Children[1], right);
                }
                return new NodeFunction(MathOperations.Add, newLeft, newRight);
            }

            if (right.Operation == MathOperations.Add)
            {
                return ExpandProduct(right, left);
            }

            return new NodeFunction(MathOperations.Multiply, left, right);
        }

        public static NodeBase ExpandPower(NodeBase basis, int power)
        {
            if (power == 0)
            {
                return new NodeNumber(1);
            }
            if(power == 1)
            {
                return basis;
            }

            if (basis.Operation == MathOperations.Add)
            {
                var additions = new List<NodeBase>();

                for (var k = 0; k <= power; k++)
                {
                    var c = MathHelpers.Factorial(power) / (MathHelpers.Factorial(k) * MathHelpers.Factorial(power - k));
                    var coefNode = new NodeNumber(c);
                    var leftNode = new NodeFunction(MathOperations.Power, basis.Children[0], new NodeNumber(power - k));
                    if (c > 1)
                    {
                        leftNode = new NodeFunction(MathOperations.Multiply, coefNode, leftNode);
                    }

                    NodeBase rightNode;
                    if (basis.Children.Count > 2)
                    {
                        rightNode = new NodeFunction(MathOperations.Add, basis.Children.Skip(1));
                    }
                    else
                    {
                        rightNode = basis.Children[1];
                    }
                    rightNode = ExpandPower(rightNode, k);

                    var addition = ExpandProduct(leftNode, rightNode);
                    additions.Add(addition);
                }

                return new NodeFunction(MathOperations.Add, additions);
            }

            return new NodeFunction(MathOperations.Power, basis, new NodeNumber(power));
        }
    }
}
