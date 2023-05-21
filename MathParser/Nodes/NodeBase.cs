using MathParser.Context;
using MathParser.Enums;

namespace MathParser.Nodes
{
    public abstract class NodeBase
    {
        public List<NodeBase> Children = new List<NodeBase>();

        internal MathOperations Operation;

        public abstract bool IsTerminal { get; }

        public abstract string StringValue { get; }

        public bool IsNumber => this is NodeNumber;

        public abstract double Eval(IContext context);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var funcNode = obj as NodeBase;

            if (funcNode != null)
            {
                if (Operation != funcNode.Operation || Children.Count != funcNode.Children.Count)
                    return false;

                bool allChildrenAreEqual = true;
                for (int i = 0; i < funcNode.Children.Count; i++)
                    if (Children[i] is NodeVariable && funcNode.Children[i] is NodeVariable)
                    {
                        if (!((NodeVariable)Children[i]).Equals((NodeVariable)funcNode.Children[i]))
                        {
                            allChildrenAreEqual = false;
                            break;
                        }
                    }
                    else if (!Children[i].Equals(funcNode.Children[i]))
                    {
                        allChildrenAreEqual = false;
                        break;
                    }
                if (!allChildrenAreEqual)
                    return false;

                return true;
            }

            return false;
        }
    }
}
