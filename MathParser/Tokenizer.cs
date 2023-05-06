using System.Globalization;
using System.Text;
using MathParser.Enums;

namespace MathParser
{
    public class Tokenizer
    {
        private TextReader _reader;
        private char _currentChar;
        private Token _currentToken;
        private double _number;
        private string? _identifier;

        public Tokenizer(string input)
        {
            _reader = new StringReader(input);
            NextChar();
            NextToken();
        }

        public Token Token => _currentToken;
        public double Number => _number;
        public string Identifier => _identifier;


        public void NextToken()
        {
            // Skip whitespace
            while (char.IsWhiteSpace(_currentChar))
            {
                NextChar();
            }

            // Special characters
            switch (_currentChar)
            {
                case '\0':
                    _currentToken = Token.EOF;
                    return;

                case '+':
                    NextChar();
                    _currentToken = Token.Add;
                    return;

                case '-':
                    NextChar();
                    _currentToken = Token.Subtract;
                    return;

                case '*':
                    NextChar();
                    _currentToken = Token.Multiply;
                    return;

                case '/':
                    NextChar();
                    _currentToken = Token.Divide;
                    return;

                case '^':
                    NextChar();
                    _currentToken = Token.Power;
                    return;

                case '(':
                    NextChar();
                    _currentToken = Token.OpenParens;
                    return;

                case ')':
                    NextChar();
                    _currentToken = Token.CloseParens;
                    return;

                case ',':
                    NextChar();
                    _currentToken = Token.Comma;
                    return;
            }

            if (char.IsDigit(_currentChar) || _currentChar == '.')
            {
                // Capture digits/decimal point
                var sb = new StringBuilder();
                bool haveDecimalPoint = false;
                while (char.IsDigit(_currentChar) || (!haveDecimalPoint && _currentChar == '.'))
                {
                    sb.Append(_currentChar);
                    haveDecimalPoint = _currentChar == '.';
                    NextChar();
                }

                _number = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                _currentToken = Token.Number;
                return;
            }

            // Identifier - starts with letter
            if (char.IsLetter(_currentChar))
            {
                var sb = new StringBuilder();

                // Accept letter or digit
                while (char.IsLetterOrDigit(_currentChar))
                {
                    sb.Append(_currentChar);
                    NextChar();
                }

                // Setup token
                _identifier = sb.ToString();
                _currentToken = Token.Identifier;
                return;
            }
        }

        // Read the next character from the input strem
        // and store it in _currentChar, or load '\0' if EOF
        private void NextChar()
        {
            int ch = _reader.Read();
            _currentChar = ch < 0 ? '\0' : (char)ch;
        }
    }
}