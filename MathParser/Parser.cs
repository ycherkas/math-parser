﻿using MathParser.Enums;
using MathParser.Nodes;

namespace MathParser
{
    public class Parser
    {
        Tokenizer _tokenizer;

        public Parser(Tokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }

        public NodeBase ParseExpression()
        {
            var expression = ParseAddSubtract();

            if (_tokenizer.Token != Token.EOF)
                throw new ArgumentException($"Unexpected characters at the end of expression");

            return expression;
        }

        // Parse an sequence of add/subtract operators
        private NodeBase ParseAddSubtract()
        {
            var leftNode = ParseMultiplyDivide();

            while (true)
            {
                var operation = MathOperations.Undefined;

                if (_tokenizer.Token == Token.Add)
                {
                    operation = MathOperations.Add;
                }
                else if (_tokenizer.Token == Token.Subtract)
                {
                    operation = MathOperations.Subtract;
                }

                if (operation == MathOperations.Undefined)
                    return leftNode;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rightNode = ParseMultiplyDivide();

                if (operation == MathOperations.Subtract)
                {
                    var minusRightNode = new NodeFunction(MathOperations.Minus, rightNode);
                    leftNode = new NodeFunction(MathOperations.Add, leftNode, minusRightNode);
                }
                else
                {
                    // Create a binary node and use it as the left-hand side from now on
                    leftNode = new NodeFunction(operation, leftNode, rightNode);
                }
            }
        }

        // Parse an sequence of multiply/divide operators
        private NodeBase ParseMultiplyDivide()
        {
            // Parse the left hand side
            var leftNode = ParsePower();

            while (true)
            {
                var operation = MathOperations.Undefined;
                if (_tokenizer.Token == Token.Multiply)
                {
                    operation = MathOperations.Multiply;
                }
                else if (_tokenizer.Token == Token.Divide)
                {
                    operation = MathOperations.Divide;
                }

                if (operation == MathOperations.Undefined)
                    return leftNode;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rightNode = ParsePower();

                if(operation == MathOperations.Divide)
                {
                    var minusOneNode = new NodeNumber(-1);
                    var powerRightNode = new NodeFunction(MathOperations.Power, rightNode, minusOneNode);
                    leftNode = new NodeFunction(MathOperations.Multiply, leftNode, powerRightNode);
                }
                else
                {
                    // Create a binary node and use it as the left-hand side from now on
                    leftNode = new NodeFunction(operation, leftNode, rightNode);
                }
            }
        }

        // Parse an sequence of power operators
        private NodeBase ParsePower()
        {
            // Parse the left hand side
            var leftNode = ParseUnary();

            while (true)
            {
                var operation = MathOperations.Undefined;
                if (_tokenizer.Token == Token.Power)
                {
                    operation = MathOperations.Power;
                }

                if (operation == MathOperations.Undefined)
                    return leftNode;

                // Skip the operator
                _tokenizer.NextToken();

                // Parse the right hand side of the expression
                var rightNode = ParseUnary();

                // Create a binary node and use it as the left-hand side from now on
                leftNode = new NodeFunction(operation, leftNode, rightNode);
            }
        }

        // Parse a unary operator (eg: negative/positive)
        private NodeBase ParseUnary()
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
                    return new NodeFunction(MathOperations.Minus, node);
                }

                return ParseLeaf();
            }
        }

        private NodeBase ParseLeaf()
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
                    var arguments = new List<NodeBase>();
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
