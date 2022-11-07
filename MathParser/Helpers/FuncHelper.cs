using MathParser.Enums;

namespace MathParser.Helpers
{
    public static class FuncHelper
    {
        public static Func<double, double, double> GetBinary(OperationBinary operation)
        {
            switch (operation)
            {
                case OperationBinary.Add:
                    return (a, b) => a + b;
                case OperationBinary.Subtract:
                    return (a, b) => a - b;
                case OperationBinary.Multiply:
                    return (a, b) => a * b;
                case OperationBinary.Divide:
                    return (a, b) => a / b;
                case OperationBinary.Power:
                    return (a, b) => Math.Pow(a, b);

                default:
                    throw new ArgumentException($"OperationBinary is not identified: {operation}");
            }
        }

        public static Func<double, double> GetUnary(OperationUnary operation)
        {
            switch (operation)
            {
                case OperationUnary.Minus:
                    return (a) => -a;

                default:
                    throw new ArgumentException($"OperationUnary is not identified: {operation}");
            }
        }
    }
}
