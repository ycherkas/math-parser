namespace MathParser.Tests
{
    public class ParsingTests
    {
        [Fact]
        public void SerializationTest()
        {
            var test = "a+a";
            var rootTreeNode = ParserManager.Parse(test);

            Assert.Equal(rootTreeNode.ToString(), test);
        }

        [Fact]
        public void SerializationTest2()
        {
            var test = "a+b/c-e*sin(2*gamma)-f^2";
            var rootTreeNode = ParserManager.Parse(test);

            Assert.Equal("a+b*(c^-1)+(-e*sin(2*gamma))+(-(f^2))", rootTreeNode.ToString());
        }
    }
}