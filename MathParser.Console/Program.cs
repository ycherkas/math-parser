// See https://aka.ms/new-console-template for more information
using MathParser;
using MathParser.Contexts;

var context = new SimpleContext();
var rootNode1 = Parser.Parse("10 + 20 - 30.123").Eval(context);
Console.WriteLine(rootNode1.ToString());

var rootNode2 = Parser.Parse("a+b/c-e*sin(2*gamma)-f^2");
Console.WriteLine(rootNode2.ToString());
