// See https://aka.ms/new-console-template for more information
using MathParser;


var rootNode1 = Parser.Parse("10 + 20 - 30.123");
Console.WriteLine(rootNode1.ToString());

var rootNode2 = Parser.Parse("a+b/c-e*sin(2*gamma)-f^2");
Console.WriteLine(rootNode2.ToString());
