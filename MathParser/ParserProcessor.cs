using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser
{
    public class ParserProcessor
    {
        Tokenizer _tokenizer;

        public ParserProcessor(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public Node ParseExpression()
        {
            var expression = ParseAddSubtract();

            if (_tokenizer.Token != Token.EOF)
                throw new ArgumentException($"Unexpected characters at the end of expression");

            return expression;
        }

        // Parse an sequence of add/subtract operators
        private Node ParseAddSubtract()
        {
            var leftNode = ParseMultiplyDivide();

            while (true)
            {
                var operation = OperationBinary.Undefined;

                if (_tokenizer.Token == Token.Add)
                {
                    operation = OperationBinary.Add;
                }
                else if (_tokenizer.Token == Token.Subtract)
                {
                    operation = OperationBinary.Subtract;
                }

                if (operation == OperationBinary.Undefined)
                    return leftNode;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rightNode = ParseMultiplyDivide();

                // Create a binary node and use it as the left-hand side from now on
                leftNode = new NodeBinary(leftNode, rightNode, operation);
            }
        }

        // Parse an sequence of add/subtract operators
        private Node ParseMultiplyDivide()
        {
            // Parse the left hand side
            var leftNode = ParsePower();

            while (true)
            {
                var operation = OperationBinary.Undefined;
                if (_tokenizer.Token == Token.Multiply)
                {
                    operation = OperationBinary.Multiply;
                }
                else if (_tokenizer.Token == Token.Divide)
                {
                    operation = OperationBinary.Divide;
                }

                if (operation == OperationBinary.Undefined)
                    return leftNode;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rightNode = ParsePower();

                // Create a binary node and use it as the left-hand side from now on
                leftNode = new NodeBinary(leftNode, rightNode, operation);
            }
        }

        // Parse an sequence of power operators
        private Node ParsePower()
        {
            // Parse the left hand side
            var leftNode = ParseUnary();

            while (true)
            {
                var operation = OperationBinary.Undefined;
                if (_tokenizer.Token == Token.Power)
                {
                    operation = OperationBinary.Power;
                }

                if (operation == OperationBinary.Undefined)
                    return leftNode;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rightNode = ParseUnary();

                // Create a binary node and use it as the left-hand side from now on
                leftNode = new NodeBinary(leftNode, rightNode, operation);
            }
        }

        // Parse a unary operator (eg: negative/positive)
        private Node ParseUnary()
        {
            while (true)
            {
                if (_tokenizer.Token == Token.Add)
                {
                    _tokenizer.NextToken();
                    continue;
                }

                if (_tokenizer.Token == Token.Subtract)
                {
                    _tokenizer.NextToken();

                    // Note this recurses to self to support negative of a negative
                    var node = ParseUnary();

                    // Create unary node
                    return new NodeUnary(node, OperationUnary.Minus);
                }

                return ParseLeaf();
            }
        }

        private Node ParseLeaf()
        {
            if (_tokenizer.Token == Token.Number)
            {
                var node = new NodeNumber(_tokenizer.Number);
                _tokenizer.NextToken();
                return node;
            }

            // Parenthesis?
            if (_tokenizer.Token == Token.OpenParens)
            {
                // Skip '('
                _tokenizer.NextToken();

                // Parse a top-level expression
                var node = ParseAddSubtract();

                // Check and skip ')'
                if (_tokenizer.Token != Token.CloseParens)
                    throw new ArgumentException("Missing close parenthesis");

                _tokenizer.NextToken();

                // Return
                return node;
            }

            // Variable
            if (_tokenizer.Token == Token.Identifier)
            {
                // Capture the name and skip it
                var name = _tokenizer.Identifier;
                _tokenizer.NextToken();

                // Parens indicate a function call, otherwise just a variable
                if (_tokenizer.Token != Token.OpenParens)
                {
                    // Variable
                    return new NodeVariable(name);
                }
                else
                {
                    // Function call

                    // Skip parens
                    _tokenizer.NextToken();

                    // Parse arguments
                    var arguments = new List<Node>();
                    while (true)
                    {
                        // Parse argument and add to list
                        arguments.Add(ParseAddSubtract());

                        // Is there another argument?
                        if (_tokenizer.Token == Token.Comma)
                        {
                            _tokenizer.NextToken();
                            continue;
                        }

                        // Get out
                        break;
                    }

                    // Check and skip ')'
                    if (_tokenizer.Token != Token.CloseParens)
                        throw new ArgumentException("Missing close parenthesis");
                    _tokenizer.NextToken();

                    // Create the function call node
                    return new NodeFunctionCall(name, arguments.ToArray());
                }
            }

            throw new ArgumentException($"Unexpect token: {_tokenizer.Token}");
        }
    }
}
