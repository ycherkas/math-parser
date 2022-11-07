using MathParser.Attributes;

namespace MathParser.Enums
{
    public enum OperationBinary
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
        Power
    }
}
