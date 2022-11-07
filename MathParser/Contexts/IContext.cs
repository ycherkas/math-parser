﻿namespace MathParser.Context
{
    public interface IContext
    {
        double ResolveVariable(string name);
        double CallFunction(string name, double[] arguments);
    }
}
