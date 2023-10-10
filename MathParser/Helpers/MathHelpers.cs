namespace MathParser.Helpers
{
    public static class MathHelpers
    {
        public static bool IsInteger(double value)
        {
            return Math.Abs(value % 1) <= (Double.Epsilon * 100);
        }

        public static int Factorial(int input)
        {
            if (input == 0 || input == 1) return 1;

            return input * Factorial(input - 1);
        }
    }
}
