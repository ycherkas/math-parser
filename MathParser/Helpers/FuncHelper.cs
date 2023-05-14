using MathParser.Enums;

namespace MathParser.Helpers
{
    public static class FuncHelper
    {
        public static Func<double, double, double> GetBinary(MathOperations operation)
        {
            switch (operation)
            {
                case MathOperations.Add:
                    return (a, b) => a + b;
                case MathOperations.Subtract:
                    return (a, b) => a - b;
                case MathOperations.Multiply:
                    return (a, b) => a * b;
                case MathOperations.Divide:
                    return (a, b) => a / b;
                case MathOperations.Power:
                    return (a, b) => Math.Pow(a, b);

                default:
                    throw new ArgumentException($"OperationBinary is not identified: {operation}");
            }
        }

        public static Func<double, double> GetUnary(MathOperations operation)
        {
            switch (operation)
            {
                case MathOperations.Minus:
                    return (a) => -a;

                default:
                    throw new ArgumentException($"OperationUnary is not identified: {operation}");
            }
        }
    }
}
