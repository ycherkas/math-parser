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

            node.Sort();

            return Simplify(node);
        }

        public static NodeBase Simplify(NodeBase node)
        {
            if (node is not NodeFunction && node is not NodeFunctionCall) return node;

            for (var i = 0; i < node.Children.Count; i++)
            {
                node.Children[i] = Simplify(node.Children[i]);
            }

            switch (node.Operation)
            {
                case MathOperations.Add:
                    node = node.ToMultichildTree();
                    node = ReduceSummands(node);
                    break;
                case MathOperations.Multiply:
                    node = node.ToMultichildTree();
                    node = MultiplyNumbers(node);
                    if (node.Children.Count == 1)
                    {
                        node = node.Children[0];
                    }

                    node = AggregatePowers(node);
                    node = ReduceMinus(node);

                    break;
                case MathOperations.Power:
                    node = SimplifyPower(node);
                    break;
            }

            return node;
        }

        private static NodeBase ReduceSummands(NodeBase node)
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

            if (node.Children.Count == 1)
            {
                return node.Children[0];
            }

            return node;
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

            mult1.Sort();
            mult2.Sort();

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

        private static NodeBase MultiplyNumbers(NodeBase node)
        {
            var numbers = node.Children.Where(child => child is NodeNumber).Cast<NodeNumber>().ToList();
            var notNumbers = node.Children.Where(child => child is not NodeNumber).ToList();

            double result = 1;
            foreach (var number in numbers)
            {
                result *= number.Number;
            }

            if (result == 0)
            {
                return new NodeNumber(0);
            }

            if (result == 1)
            {
                if (notNumbers.Count == 0)
                    return new NodeNumber(1);

                if (notNumbers.Count == 1)
                    return notNumbers.First();

                return new NodeFunction(MathOperations.Multiply, notNumbers);
            }

            if (result == -1)
            {
                if (notNumbers.Count == 0)
                    return new NodeNumber(-1);

                if (notNumbers.Count == 1)
                    return new NodeFunction(MathOperations.Minus, notNumbers[0]);

                return new NodeFunction(MathOperations.Minus, new NodeFunction(MathOperations.Multiply, notNumbers));
            }

            if (notNumbers.Count == 0)
            {
                return new NodeNumber(result);
            }

            notNumbers.Add(new NodeNumber(result));

            return new NodeFunction(MathOperations.Multiply, notNumbers);
        }

        private static NodeBase ReduceMinus(NodeBase node)
        {
            var minusCount = node.Children.Count(c => c.Operation == MathOperations.Minus);

            if (minusCount == 0) return node;

            node.Children = node.Children.Select(c => c.Operation == MathOperations.Minus ? c.Children[0] : c).ToList();

            if (minusCount % 2 == 1)
            {
                return new NodeFunction(MathOperations.Minus, node);
            }

            return node;
        }

        private static NodeBase AggregatePowers(NodeBase node)
        {
            if (node is not NodeFunction)
                return node;

            var newChildren = new List<NodeBase>();
            bool[] markedNodes = new bool[node.Children.Count];


            for (int i = 0; i < node.Children.Count; i++)
            {
                var child = node.Children[i];

                var basis = GetPowerBasis(child);
                var nodesWithSameBasis = new List<NodeBase>();
                if (!markedNodes[i])
                    nodesWithSameBasis.Add(child);

                for (int j = i + 1; j < node.Children.Count; j++)
                    if (basis.Equals(GetPowerBasis(node.Children[j])) && !markedNodes[j])
                    {
                        nodesWithSameBasis.Add(node.Children[j]);
                        markedNodes[j] = true;
                    }

                if (nodesWithSameBasis.Count > 1)
                {
                    var newPowerFactor = Simplify(new NodeFunction(MathOperations.Add,
                            nodesWithSameBasis.Select(node => GetPowerFactor(node)).ToList()));

                    newChildren.Add(Simplify(new NodeFunction(MathOperations.Power,
                        basis,
                        newPowerFactor
                    )));
                }
                else if (!markedNodes[i])
                    newChildren.Add(child);
            }

            if (node.Children.Count != newChildren.Count)
            {
                if (newChildren.Count == 1)
                    return newChildren[0];
                else
                    return Simplify(new NodeFunction(MathOperations.Multiply, newChildren));
            }
            else
                return node;
        }

        private static NodeBase GetPowerBasis(NodeBase node)
        {
            return (node is NodeFunction funcNode && funcNode.Operation == MathOperations.Power) ?
                node.Children[0] : node;
        }

        private static NodeBase GetPowerFactor(NodeBase node)
        {
            return (node is NodeFunction funcNode && funcNode.Operation == MathOperations.Power)
                ? node.Children[1] : new NodeNumber(1);
        }

        private static NodeBase SimplifyPower(NodeBase node)
        {
            if (node.Children[1] is NodeNumber powerFactor)
            {
                if (powerFactor.Number == 0)
                {
                    return new NodeNumber(1);
                }
                else if (powerFactor.Number == 1)
                {
                    return node.Children[0];
                }
                else if (powerFactor.Number % 2 == 0 && node.Children[0].Operation == MathOperations.Minus)
                {
                    return new NodeFunction(MathOperations.Power, node.Children[0].Children[0], powerFactor);
                }
            }

            return node;
        }
    }
}
