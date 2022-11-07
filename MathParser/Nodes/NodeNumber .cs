using MathParser.Context;

namespace MathParser.Nodes
{
    public class NodeNumber : Node
    {
        public NodeNumber(double number)
        {
            _number = number;
        }

        double _number;

        public override double Eval(IContext context)
        {
            return _number;
        }

        public override string ToString()
        {
            return _number.ToString();
        }
    }
}
