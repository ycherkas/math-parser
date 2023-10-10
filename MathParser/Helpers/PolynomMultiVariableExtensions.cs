using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser.Helpers
{
    public static class PolynomMultiVariableExtensions
    {
        public static bool IsVariableMulti(this NodeBase node, List<NodeVariable> variables)
        {
            var nodeVariable = node as NodeVariable;

            if (nodeVariable == null) return false;

            return variables.Any(v => v.StringValue == nodeVariable.StringValue);
        }

        public static bool IsExponentBaseMulti(this NodeBase node, List<NodeVariable> variables)
        {
            if(node.Operation != MathOperations.Power) return false;

            if(node.Children.Count != 2) return false;

            if (!node.Children[0].IsVariableMulti(variables)) return false;

            if (!node.Children[1].IsNumber()) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if(powerFactor == null) return false;

            return true;
        }

        public static bool IsExponentMulti(this NodeBase node, List<NodeVariable> variables)
        {
            if (!node.IsExponentBaseMulti(variables)) return false;

            var powerFactor = node.Children[1] as NodeNumber;

            if (powerFactor != null && powerFactor.Number <= 0) return false;

            return true;
        }


        public static bool IsMonomialMulti(this NodeBase node, List<NodeVariable> variables)
        {
            if (node.IsNumber()) return true;

            if(node.IsNumberFraction()) return true;

            if (node.IsVariableMulti(variables)) return true;

            if (node.IsExponentMulti(variables)) return true;

            if (node.Operation == MathOperations.Multiply)
            {
                foreach (var child in node.Children)
                {
                    if (!child.IsMonomialMulti(variables)) return false;
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynomMulti(this NodeBase node, List<NodeVariable> variables)
        {
            if (node.IsMonomialMulti(variables)) return true;

            if (node.Operation == MathOperations.Add)
            {
                foreach (var child in node.Children)
                {
                    if(child.Operation == MathOperations.Minus)
                    {
                        if (!child.Children[0].IsMonomialMulti(variables)) return false;
                    }
                    else
                    {
                        if (!child.IsMonomialMulti(variables)) return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynomMulti(this NodeBase node)
        {
            var variables = node.GetVariables();

            var nodeVariables = variables.Select(v => (NodeVariable)v).ToList();

            return IsPolynomMulti(node, nodeVariables);
        }
    }
}
