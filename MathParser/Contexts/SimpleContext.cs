using MathParser.Context;

namespace MathParser.Contexts
{
    public class SimpleContext : IContext
    {
        private readonly Dictionary<string, double> _variables;

        public SimpleContext() { }

        public SimpleContext(Dictionary<string, double> variables)
        {
            _variables = variables;
        }

        public double CallFunction(string name, double[] arguments)
        {
            throw new NotImplementedException();
        }

        public double ResolveVariable(string name)
        {
            if (_variables?.ContainsKey(name) ?? false)
            {
                return _variables[name];
            }

            throw new NotImplementedException();
        }
    }
}
