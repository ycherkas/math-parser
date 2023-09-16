using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser.Helpers
{
    public static class PolynomExtensions
    {
        public static bool IsNumber(this NodeBase node)
        {
            return node.IsNumber;
        }

        public static bool IsVariable(this NodeBase node)
        {
            return node is NodeVariable;
        }

        public static bool IsExponent(this NodeBase node)
        {
            if(node.Operation != MathOperations.Power) return false;

            if(node.Children.Count != 2) return false;

            if (!node.Children[0].IsVariable()) return false;

            if (!node.Children[1].IsNumber()) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if(powerFactor != null && powerFactor.Number <= 0) return false;

            return true;
        }

        public static bool IsMonomial(this NodeBase node)
        {
            if (node.IsNumber()) return true;

            if (node.IsVariable()) return true;

            if (node.IsExponent()) return true;

            if (node.Operation == MathOperations.Multiply)
            {
                foreach (var child in node.Children)
                {
                    if (!child.IsMonomial()) return false;
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynom(this NodeBase node)
        {
            if (node.IsMonomial()) return true;

            if (node.Operation == MathOperations.Add)
            {
                foreach (var child in node.Children)
                {
                    if(child.Operation == MathOperations.Minus)
                    {
                        if (!child.Children[0].IsMonomial()) return false;
                    }
                    else
                    {
                        if (!child.IsMonomial()) return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
