using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser.Helpers
{
    public static class PolynomGeneralExtensions
    {
        public static bool FreeOf(this NodeBase expression, List<NodeBase> variables)
        {
            foreach (var variable in variables)
            {
                if (!expression.FreeOf(variable)) return false;
            }

            return true;
        }

        public static bool FreeOf(this NodeBase expression, NodeBase variable)
        {
            if (expression.Equals(variable)) return false;

            if (expression.IsNumber() || expression is NodeVariable) return true;

            foreach (var child in expression.Children)
            {
                if (!child.FreeOf(variable)) return false;
            }

            return true;
        }

        public static bool IsVariable(this NodeBase expression, List<NodeBase> variables)
        {
            foreach (var variable in variables)
            {
                if(expression.Equals(variable)) return true;
            }

            return false;
        }

        public static bool IsExponent(this NodeBase expression, List<NodeBase> variables)
        {
            if(expression.Operation != MathOperations.Power) return false;

            if(expression.Children.Count != 2) return false;

            if (!variables.Any(v => v.Equals(expression.Children[0]))) return false;

            if (!expression.Children[1].IsNumber()) return false;

            var powerFactor = expression.Children[1] as NodeNumber;

            if(powerFactor != null && powerFactor.Number <= 0) return false;

            return true;
        }

        public static bool IsMonomial(this NodeBase expression, List<NodeBase> variables)
        {
            if(expression.Operation == MathOperations.Minus)
            {
                return expression.Children[0].IsMonomial(variables);
            }

            if (expression.FreeOf(variables)) return true;

            if (expression.IsVariable(variables)) return true;

            if (expression.IsExponent(variables)) return true;

            if (expression.Operation == MathOperations.Multiply)
            {
                foreach (var child in expression.Children)
                {
                    if (!child.IsMonomial(variables)) return false;
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynom(this NodeBase expression, List<NodeBase> variables)
        {
            if (expression.IsMonomial(variables)) return true;

            if (expression.Operation == MathOperations.Add)
            {
                foreach (var child in expression.Children)
                {
                    if (!child.IsMonomial(variables)) return false;
                }

                return true;
            }

            return false;
        }

        public static bool IsPolynom(this NodeBase node)
        {
            var variables = node.GetVariables();

            return IsPolynom(node, variables);
        }
    }
}
