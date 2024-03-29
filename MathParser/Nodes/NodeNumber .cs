﻿using MathParser.Context;

namespace MathParser.Nodes
{
    public class NodeNumber : NodeBase
    {
        public NodeNumber(double number)
        {
            Number = number;
            StringValue = Number.ToString();
        }

        public double Number { get; set; }

        public override double Eval(IContext context) => Number;

        public override string ToString() => Number.ToString();

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
    }
}
