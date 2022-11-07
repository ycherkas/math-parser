namespace MathParser.Tests
{
    public class SimpleMathTests
    {
        [Fact]
        public void SerializationTest()
        {
            var test = "1+1";
            var rootTreeNode = Parser.Parse(test);

            Assert.Equal(rootTreeNode.ToString(), test);
        }

        [Fact]
        public void SerializationTest2()
        {
            var test = "a+b/c-e*sin(2*gamma)-f^2";
            var rootTreeNode = Parser.Parse(test);

            Assert.Equal(rootTreeNode.ToString(), test);
        }

        //[Fact]
        //public void AddTest()
        //{
        //    Assert.Equal(2, Parser.Parse("1 + 1").Eval());
        //}

        //[Fact]
        //public void SubstractTest()
        //{
        //    Assert.Equal(1, Parser.Parse("2 - 1").Eval());
        //}
    }
}