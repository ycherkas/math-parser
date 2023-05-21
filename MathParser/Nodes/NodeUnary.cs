using MathParser.Context;
using MathParser.Enums;
using MathParser.Helpers;

namespace MathParser.Nodes
{
    // NodeUnary for unary operations such as Negate
    public class NodeUnary : NodeBase
    {
        public NodeUnary(NodeBase node, MathOperations operation)
        {
            Children.Add(node);
            Operation = operation;
        }

        public override string StringValue => Operation.Value() ?? "???";

        public override bool IsTerminal => false;

        private NodeBase _node => Children[0];

        public override double Eval(IContext context)
        {
            var rhsVal = _node.Eval(context);

            var function = FuncHelper.GetUnary(Operation);

            var result = function(rhsVal);

            return result;
        }

        public override string ToString()
        {
            return $"{Operation.Value()}{_node.ToString()}";
        }
    }
}
