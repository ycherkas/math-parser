namespace MathParser.Attributes
{
    public class StringValue : Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value => _value;
    }
}
