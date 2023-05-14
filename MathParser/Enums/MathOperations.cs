using MathParser.Attributes;

namespace MathParser.Enums
{
    public enum MathOperations
    {
        [StringValue("")]
        Undefined,
        [StringValue("+")]
        Add,
        [StringValue("-")]
        Subtract,
        [StringValue("*")]
        Multiply,
        [StringValue("/")]
        Divide,
        [StringValue("^")]
        Power,
        [StringValue("-")]
        Minus
    }
}
