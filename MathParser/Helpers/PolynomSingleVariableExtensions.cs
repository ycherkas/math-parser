using MathParser.Enums;
using MathParser.Nodes;
using System.Linq.Expressions;

namespace MathParser.Helpers
{
    public static class PolynomSingleVariableExtensions
    {
        public static bool IsNumber(this NodeBase node)
        {
            return node.IsNumber || node.IsExponentNumberPositive();
        }

        public static bool IsNumberFraction(this NodeBase node)
        {
            if (node.IsExponentNumberNegative()) return true;

            if (node.Operation != MathOperations.Multiply) return false;

            if (node.Children.Count != 2) return false;

            if (!node.Children[0].IsNumber) return false;

            if (!node.Children[1].IsExponentNumberNegative()) return false;

            return true;
        }

        public static bool IsVariable(this NodeBase node, NodeVariable variable)
        {
            var nodeVariable = node as NodeVariable;

            if (nodeVariable == null) return false;

            return nodeVariable.StringValue == variable.StringValue;
        }

        public static bool IsExponentBase(this NodeBase node, NodeVariable variable)
        {
            if (node.Operation != MathOperations.Power) return false;

            if (node.Children.Count != 2) return false;

            if (!node.Children[0].IsVariable(variable)) return false;

            if (!node.Children[1].IsNumber()) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor == null) return false;

            return true;
        }

        public static bool IsExponentNumberBase(this NodeBase node)
        {
            if (node.Operation != MathOperations.Power) return false;

            if (node.Children.Count != 2) return false;

            if (!node.Children[0].IsNumber) return false;

            if (!node.Children[1].IsNumber()) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor == null) return false;

            return true;
        }

        public static bool IsExponent(this NodeBase node, NodeVariable variable)
        {
            if (!node.IsExponentBase(variable)) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor == null || powerFactor.Number <= 0) return false;

            return true;
        }

        public static bool IsExponentNegative(this NodeBase node, NodeVariable variable)
        {
            if (!node.IsExponentBase(variable)) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor == null || powerFactor.Number >= 0) return false;

            return true;
        }

        public static bool IsExponentNumberPositive(this NodeBase node)
        {
            if (!node.IsExponentNumberBase()) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor == null || powerFactor.Number < 0) return false;

            return true;
        }

        public static bool IsExponentNumberNegative(this NodeBase node)
        {
            if (!node.IsExponentNumberBase()) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor == null || powerFactor.Number >= 0) return false;

            return true;
        }

        public static bool IsMonomialSingle(this NodeBase node, NodeVariable variable)
        {
            if (node.IsNumber()) return true;

            if (node.IsNumberFraction()) return true;

            if (node.IsVariable(variable)) return true;

            if (node.IsExponent(variable)) return true;

            if (node.Operation == MathOperations.Multiply)
            {
                foreach (var child in node.Children)
                {
                    if (!child.IsMonomialSingle(variable)) return false;
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynomSingle(this NodeBase node, NodeVariable variable)
        {
            if (node.IsMonomialSingle(variable)) return true;

            if (node.Operation == MathOperations.Add)
            {
                foreach (var child in node.Children)
                {
                    if (child.Operation == MathOperations.Minus)
                    {
                        if (!child.Children[0].IsMonomialSingle(variable)) return false;
                    }
                    else
                    {
                        if (!child.IsMonomialSingle(variable)) return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynomSingle(this NodeBase node)
        {
            var variables = node.GetVariables();

            if (variables.Count() > 1) return false;

            var nodeVariable = variables.FirstOrDefault() as NodeVariable;

            return IsPolynomSingle(node, nodeVariable);
        }
    }
}
