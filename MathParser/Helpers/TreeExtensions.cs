using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser.Helpers
{
    public static class TreeExtensions
    {
        public static NodeBase ToBinaryForm(this NodeBase node)
        {
            if (node.Children.Count == 0) return node;

            if(node.Children.Count > 2)
            {
                var newNode = new NodeFunction(node.Operation, node.Children[1], node.Children[2]);
                node.Children.RemoveAt(2);
                node.Children.RemoveAt(1);
                node.Children.Insert(1, newNode);
                ToBinaryForm(node);

                return node;
            }

            foreach (var child in node.Children)
            {
                ToBinaryForm(child);
            }

            return node;
        }

        public static NodeBase ToMultichildTreeFull(this NodeBase node)
        {
            var nodeFunction = node as NodeFunction;

            if (nodeFunction == null) return node;

            foreach(var child in nodeFunction.Children)
            {
                ToMultichildTreeFull(child);
            }

            return ToMultichildTree(nodeFunction);
        }

        public static NodeBase ToMultichildTree(this NodeBase node)
        {
            var nodeFunction = node as NodeFunction;

            if (nodeFunction == null) return node;

            return ToMultichildTree(nodeFunction);
        }

        public static NodeFunction ToMultichildTree(this NodeFunction node)
        {
            var newChildren = new List<NodeBase>();
            BuildMultichildTree(node, node, newChildren, false);
            node.Children = newChildren;

            return node;
        }

        public static List<NodeBase> GetVariables(this NodeBase node, List<NodeBase> variables = null)
        {
            if (variables == null)
            {
                variables = new List<NodeBase>();
            }

            var nodeVariable = node as NodeVariable;

            if (nodeVariable != null && !variables.Any(v => v.StringValue == nodeVariable.StringValue))
            {
                variables.Add(nodeVariable);
            }

            foreach (var child in node.Children)
            {
                GetVariables(child, variables);
            }

            return variables;
        }

        private static void BuildMultichildTree(NodeBase beginNode, NodeBase node, List<NodeBase> newChildren, bool neg)
        {
            foreach (var child in node.Children)
            {
                if (child.Operation == beginNode.Operation)
                {
                    BuildMultichildTree(beginNode, child, newChildren, neg);
                    continue;
                }
                else if (child.Operation == MathOperations.Minus)
                {
                    BuildMultichildTree(beginNode, child, newChildren, !neg);
                    continue;
                }

                if (neg && (beginNode.Operation == MathOperations.Add ||
                    (beginNode.Operation == MathOperations.Multiply && child == node.Children.First())))
                {
                    if (child is NodeNumber nodeNumber)
                        newChildren.Add(new NodeNumber(-nodeNumber.Number));
                    else
                        newChildren.Add(new NodeFunction(MathOperations.Minus, child));
                }
                else
                    newChildren.Add(child);
            }
        }
    }
}
