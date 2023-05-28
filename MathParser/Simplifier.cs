using MathParser.Enums;
using MathParser.Helpers;
using MathParser.Nodes;

namespace MathParser
{
    public class Simplifier
    {
        public static NodeBase Simplify(string input)
        {
            var node = ParserManager.Parse(input);

            return Simplify(node);
        }

        public static NodeBase Simplify(NodeBase node)
        {
            if (node is not NodeFunction && node is not NodeFunctionCall) return node;

            foreach (NodeBase child in node.Children)
            {
                Simplify(child);
            }

            switch (node.Operation)
            {
                case MathOperations.Add:
                    node = node.ToMultichildTree();
                    ReduceSummands(node);
                    break;
                case MathOperations.Multiply:
                    node = node.ToMultichildTree();
                    node = ReduceMultipleZero(node);
                    if (node.Children.Count == 1)
                    {
                        node = node.Children[0];
                    }
                    break;
            }

            return node;
        }

        private static void ReduceSummands(NodeBase node)
        {
            int i = 0;
            while (i < node.Children.Count)
            {
                int j = i + 1;
                while (j < node.Children.Count)
                {
                    var newNode = ReduceAddition(node.Children[i], node.Children[j]);
                    if (newNode != null)
                    {
                        node.Children[i] = newNode;
                        node.Children.RemoveAt(j);
                    }
                    else
                        j++;
                }
                i++;
            }
        }

        private static NodeBase ReduceAddition(NodeBase node1, NodeBase node2)
        {
            var node1neg = node1.Operation == MathOperations.Minus;
            var node2neg = node2.Operation == MathOperations.Minus;
            var node11 = node1neg ? node1.Children[0] : node1;
            var node21 = node2neg ? node2.Children[0] : node2;

            NodeBase valueNode1 = null;
            if (node11.Operation == MathOperations.Multiply)
                valueNode1 = node11.Children.Where(child => child.IsNumber).FirstOrDefault();
            if (valueNode1 == null)
                valueNode1 = node11.IsNumber ? node11 : new NodeNumber(1);
            var value1 = ((NodeNumber)valueNode1).Number;
            if (node1neg)
                value1 *= -1;

            NodeBase valueNode2 = null;
            if (node21.Operation == MathOperations.Multiply)
                valueNode2 = node21.Children.Where(child => child.IsNumber).FirstOrDefault();
            if (valueNode2 == null)
                valueNode2 = node21.IsNumber ? node21 : new NodeNumber(1);
            var value2 = ((NodeNumber)valueNode2).Number;
            if (node2neg)
                value2 *= -1;

            var notValueNodes1 = node11.Operation == MathOperations.Multiply ?
                node11.Children.Where(child => !child.IsNumber).ToList() :
                node11.IsNumber ?
                new List<NodeBase>() { } :
                new List<NodeBase>() { node11 };
            var notValueNodes2 = node21.Operation == MathOperations.Multiply ?
                node21.Children.Where(child => !child.IsNumber).ToList() :
                node21.IsNumber ?
                new List<NodeBase>() { } :
                new List<NodeBase>() { node21 };

            var mult1 = new NodeFunction(MathOperations.Multiply, notValueNodes1.ToList());
            var mult2 = new NodeFunction(MathOperations.Multiply, notValueNodes2.ToList());

            //mult1.Sort();
            //mult2.Sort();

            if (mult1.Equals(mult2))
            {
                var resultNodes = new List<NodeBase>();
                resultNodes.Add(new NodeNumber(value1 + value2));
                resultNodes.AddRange(notValueNodes1);
                return Simplify(new NodeFunction(MathOperations.Multiply, resultNodes));
            }
            else
                return null;
        }

        private static NodeBase ReduceMultipleZero(NodeBase node)
        {
            foreach (var child in node.Children)
            {
                var childNumberNode = child as NodeNumber;
                if (childNumberNode != null && childNumberNode.Number == 0)
                {
                    return new NodeNumber(0);
                }
            }

            return node;
        }
    }
}
