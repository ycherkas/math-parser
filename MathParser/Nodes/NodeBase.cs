using MathParser.Context;
using MathParser.Enums;

namespace MathParser.Nodes
{
    public abstract class NodeBase : IComparable<NodeBase>
    {
        public List<NodeBase> Children = new List<NodeBase>();

        internal MathOperations Operation;

        public string StringValue { get; set; }

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

        public void Sort()
        {
            if (this is NodeFunction funcNode)
            {
                foreach (var child in Children)
                    child.Sort();

                if (funcNode.Operation == MathOperations.Add)
                {
                    Children.Sort(CompareForAdd);
                }
                else if(funcNode.Operation == MathOperations.Multiply)
                {
                    Children.Sort(CompareForMultiply);
                }
            }
        }

        public int CompareTo(NodeBase other)
        {
            int result = 0;
            switch (this)
            {
                case NodeFunction nodeFunction:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                            if (StringValue != other.StringValue)
                            {
                                result = StringValue.CompareTo(other.StringValue);
                            }
                            else if (Children.Count != other.Children.Count)
                            {
                                result = -Children.Count.CompareTo(other.Children.Count);
                            }
                            else
                            {
                                for (int i = 0; i < Children.Count; i++)
                                {
                                    result = Children[i].CompareTo(other.Children[i]);
                                    if (result != 0)
                                        break;
                                }
                            }
                            break;
                        case NodeNumber:
                            return 1;
                        default:
                            result = -1;
                            break;
                    }
                    break;
                case NodeVariable nodeVariable:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                            result = 1;
                            break;
                        case NodeVariable otherNodeVariable:
                            result = StringValue.CompareTo(other.StringValue);
                            break;
                        case NodeNumber othereNodeNumber:
                            return 1;
                        default:
                            result = -1;
                            break;
                    }
                    break;
                case NodeNumber nodeNumber:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                        case NodeVariable otherNodeVariable:
                            result = 1;
                            break;
                        case NodeNumber otherValueNode:
                            result = nodeNumber.Number.CompareTo(otherValueNode.Number);
                            break;
                    }
                    break;
            }
            return result;
        }

        private static int CompareForAdd(NodeBase left, NodeBase other)
        {
            int result = 0;
            switch (left)
            {
                case NodeFunction nodeFunction:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                            if (left.StringValue != other.StringValue)
                            {
                                result = left.StringValue.CompareTo(other.StringValue);
                            }
                            else if (left.Children.Count != other.Children.Count)
                            {
                                result = -left.Children.Count.CompareTo(other.Children.Count);
                            }
                            else
                            {
                                for (int i = 0; i < left.Children.Count; i++)
                                {
                                    result = left.Children[i].CompareTo(other.Children[i]);
                                    if (result != 0)
                                        break;
                                }
                            }
                            break;
                        case NodeNumber:
                            return 1;
                        default:
                            result = -1;
                            break;
                    }
                    break;
                case NodeVariable nodeVariable:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                            result = 1;
                            break;
                        case NodeVariable otherNodeVariable:
                            result = left.StringValue.CompareTo(other.StringValue);
                            break;
                        default:
                            result = -1;
                            break;
                    }
                    break;
                case NodeNumber nodeNumber:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                        case NodeVariable otherNodeVariable:
                            result = 1;
                            break;
                        case NodeNumber otherValueNode:
                            result = nodeNumber.Number.CompareTo(otherValueNode.Number);
                            break;
                    }
                    break;
            }
            return result;
        }

        private static int CompareForMultiply(NodeBase left, NodeBase other)
        {
            int result = 0;
            switch (left)
            {
                case NodeFunction nodeFunction:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                            if(nodeFunction.Operation == MathOperations.Power && nodeFunction.Children[1].IsNumber && otherNodeFunction.Operation == MathOperations.Power && otherNodeFunction.Children[1].IsNumber)
                            {
                                result = ((NodeNumber)(nodeFunction.Children[1])).Number.CompareTo(((NodeNumber)(otherNodeFunction.Children[1])).Number);
                            }
                            else if (left.StringValue != other.StringValue)
                            {
                                result = left.StringValue.CompareTo(other.StringValue);
                            }
                            else if (left.Children.Count != other.Children.Count)
                            {
                                result = -left.Children.Count.CompareTo(other.Children.Count);
                            }
                            else
                            {
                                for (int i = 0; i < left.Children.Count; i++)
                                {
                                    result = left.Children[i].CompareTo(other.Children[i]);
                                    if (result != 0)
                                        break;
                                }
                            }
                            break;
                        case NodeNumber:
                            return 1;
                        case NodeVariable:
                            return 1;
                        default:
                            result = -1;
                            break;
                    }
                    break;
                case NodeVariable nodeVariable:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                            result = -1;
                            break;
                        case NodeVariable otherNodeVariable:
                            result = left.StringValue.CompareTo(other.StringValue);
                            break;
                        case NodeNumber othereNodeNumber:
                            return 1;
                        default:
                            result = -1;
                            break;
                    }
                    break;
                case NodeNumber nodeNumber:
                    switch (other)
                    {
                        case NodeFunction otherNodeFunction:
                        case NodeVariable otherNodeVariable:
                            result = -1;
                            break;
                        case NodeNumber otherValueNode:
                            result = nodeNumber.Number.CompareTo(otherValueNode.Number);
                            break;
                    }
                    break;
            }
            return result;
        }
    }
}
