using MathParser.Context;
using MathParser.Helpers;

namespace MathParser.Nodes
{
    public class NodeNumber : NodeBase
    {
        public override string StringValue => Number.ToString();

        public override bool IsTerminal => true;


        public NodeNumber(double number)
        {
            Number = number;
        }

        public double Number { get; set; }

        public override double Eval(IContext context)
        {
            return Number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is string)
            {
                if ((string)obj == Number.ToString())
                    return true;
                else
                    return false;
            }

            //if (obj is double || obj is decimal)
            //{
            //    Rational<long> r;
            //    if (Rational<long>.FromDecimal((decimal)obj, out r) && r == Value)
            //        return true;
            //    else
            //        return false;
            //}

            if (obj is int)
            {
                if ((int)obj == Number)
                    return true;
                else
                    return false;
            }

            var v = obj as NodeNumber;
            if (v != null)
                return v.Number == Number;
            else
                return false;
        }

        //public override bool Equals(string s)
        //{
        //    if (s != null && double.TryParse(s, out var number))
        //        return number == Number;
        //    else
        //        return false;
        //}

        public bool Equals(NodeNumber v)
        {
            if (v != null)
                return v.Number == Number;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
