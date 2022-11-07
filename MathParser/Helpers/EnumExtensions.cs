using MathParser.Attributes;

namespace MathParser.Helpers
{
    public static class EnumExtensions
    {
        public static string Value(this Enum value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            var attribs = fieldInfo.GetCustomAttributes(typeof(StringValue), false) as StringValue[];

            return attribs != null && attribs.Length > 0 ? attribs[0].Value : null;
        }
    }
}
