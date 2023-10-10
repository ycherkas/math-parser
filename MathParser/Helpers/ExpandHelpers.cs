using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser.Helpers
{
    public static class ExpandHelpers
    {
        public static NodeBase ExpandAlgebraic(NodeBase node)
        {
            if (node.Operation == MathOperations.Add)
            {
                var newLeft = ExpandAlgebraic(node.Children[0]);
                var newRight = ExpandAlgebraic(node.Children[1]);
                return new NodeFunction(MathOperations.Add, newLeft, newRight);
            }

            if (node.Operation == MathOperations.Multiply)
            {
                return ExpandProduct(node.Children[0], node.Children[1]);
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

            return node;
        }

        public static NodeBase ExpandProduct(NodeBase left, NodeBase right)
        {
            if (left.Operation == MathOperations.Add)
            {
                var newLeft = ExpandProduct(left.Children[0], right);
                var newRight = ExpandProduct(left.Children[1], right);
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
            if (basis.Operation == MathOperations.Add)
            {
                var additions = new List<NodeBase>();

                for (var k = 0; k <= power; k++)
                {
                    var c = MathHelpers.Factorial(power) / (MathHelpers.Factorial(k) * MathHelpers.Factorial(power - k));
                    var addition = ExpandProduct(
                        new NodeFunction(MathOperations.Multiply,
                        new NodeNumber(c),
                        new NodeFunction(MathOperations.Power, basis.Children[0], new NodeNumber(power - k))),
                        ExpandPower(basis.Children[1], k));
                    additions.Add(addition);
                }

                return new NodeFunction(MathOperations.Add, additions);
            }

            return new NodeFunction(MathOperations.Power, basis, new NodeNumber(power));
        }
    }
}
