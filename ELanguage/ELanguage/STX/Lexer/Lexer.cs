using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELangugage
{
    internal class Lexer
    {
        private string input;
        private List<Token> tokens;
        private int pos;
        private int length;

        private static string operatorChars = "+-*/()<>={}!&|,[]";

        private List<Operator> operators = new List<Operator>()
        {
            new Operator('+', TokenType.Plus),
            new Operator("++", TokenType.Increment),
            new Operator('-', TokenType.Minus),
            new Operator("--", TokenType.Decrement),
            new Operator('*', TokenType.Star),
            new Operator('/', TokenType.Slash),

            new Operator('(', TokenType.LParen),
            new Operator(')', TokenType.RParen),

            new Operator('<', TokenType.LT),
            new Operator("<=", TokenType.LTEquals),
            new Operator('>', TokenType.GT),
            new Operator(">=", TokenType.GTEquals),

            new Operator('=', TokenType.Equals),
            new Operator("==", TokenType.EqualsEquals),
            new Operator("!=", TokenType.ExclEquals),

            new Operator('{', TokenType.Lbrace),
            new Operator('}', TokenType.Rbrace),

            new Operator('!', TokenType.Excl),
            new Operator('&', TokenType.Amp),
            new Operator('|', TokenType.Bar),

            new Operator("&&", TokenType.AmpAmp),
            new Operator("||", TokenType.BarBar),

            new Operator(';', TokenType.Semicolon),
            new Operator(',', TokenType.Comma),

            new Operator("[", TokenType.Lbracket),
            new Operator("]", TokenType.Rbracket),
        };
        
        public Lexer(string input)
        {
            this.input = input;
            length = input.Length;

            tokens = new List<Token>();
        }

        public List<Token> Tokenize()
        {
            while(pos < length)
            {
                char current = Peek(0);

                if (IsNumber(current))
                    TokenizeNumber();
                else if (operatorChars.Contains(current))
                    TokenizeOperator();
                else if (IsLetter(current))
                    TokenizeWord();
                else if (current == '"')
                    TokenizeString();
                else
                    Next();
            }
            return tokens;
        }

        private void TokenizeNumber()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);

            while (IsNumber(current))
            {
                buffer.Append(current);
                current = Next();
            }
            AddToken(TokenType.Number, buffer.ToString());
        }
        
        private void TokenizeOperator()
        {
            char current = Peek(0);

            if(current == '/')
            {
                if(Peek(1) == '/')
                {
                    Next();
                    Next();
                    TokenizeComment();
                    return;
                } 
                else if (Peek(1) == '*')
                {
                    Next();
                    Next();
                    TokenizeMultilineComment();
                    return;
                }
            }

            StringBuilder buffer = new StringBuilder();
            
            while (true)
            {
                string text = buffer.ToString();

                if (!Match(text + current) && text != "")
                {

                    AddToken(GetOperatorToken(text));
                    return;
                }
                buffer.Append(current);
                current = Next();
            }
        }
  
        private void TokenizeComment()
        {
            char current = Peek(0);

            while("\r\n\0".IndexOf(current) == -1)
                current = Next();
        }
  
        private void TokenizeMultilineComment()
        {
            char current = Peek(0);

            while (true)
            {
                if (current == '\0') 
                    throw new Exception("TYPE:004");
                if (current == '*' && Peek(1) == '/') 
                    break;
                current = Next();
            }

            Next();
            Next();
        }
  
        private void TokenizeWord()
        {
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);

            while (IsLetterOrNumber(current))
            {
                if (current == '&' || current == '$' || current == '!')
                    break;
                buffer.Append(current);
                current = Next();
            }

            switch (buffer.ToString())
            {
                case "println":
                    AddToken(TokenType.Println); break;
                case "print":
                    AddToken(TokenType.Print); break;
                case "if":
                    AddToken(TokenType.If); break;
                case "else":
                    AddToken(TokenType.Else); break;
                case "while":
                    AddToken(TokenType.While); break;
                case "for":
                    AddToken(TokenType.For); break;
                case "do":
                    AddToken(TokenType.Do); break;
                case "break":
                    AddToken(TokenType.Break); break;
                case "continue":
                    AddToken(TokenType.Continue); break;
                case "func":
                    AddToken(TokenType.Func); break;
                case "return":
                    AddToken(TokenType.Return); break;
                case "use":
                    AddToken(TokenType.Use); break;
                case "import":
                    AddToken(TokenType.Import); break;
                case "and":
                    AddToken(TokenType.AmpAmp); break;
                case "or":
                    AddToken(TokenType.BarBar); break;
                case "not":
                    AddToken(TokenType.ExclEquals); break;
                default:
                    AddToken(TokenType.Word, buffer.ToString()); break;
            }
        }

        private void TokenizeString()
        {
            Next(); // Skip "
            StringBuilder buffer = new StringBuilder();
            char current = Peek(0);

            while (true)
            {
                if (current == '\\')
                {
                    current = Next();
                    switch (current)
                    {
                        case '"':
                            current = Next();
                            buffer.Append('"');
                            break;
                        case 'n':
                            current = Next();
                            buffer.Append("\n");
                            break;
                        case 't':
                            current = Next();
                            buffer.Append('\t');
                            break;
                        case '\\':
                            current = Next();
                            buffer.Append('\\');
                            break;
                    }
                    continue;
                }
                if (current == '"') 
                    break;
                buffer.Append(current);
                current = Next();
            }
            Next();
            AddToken(TokenType.String, buffer.ToString());
        }

        private char Next()
        {
            pos++;
            return Peek(0);
        }

        private char Peek(int relativePosition)
        {
            int position = pos + relativePosition;

            if (position >= length) 
                return '\0';

            return input[position];
        }

        private void AddToken(TokenType type, string value = "")
        {
            tokens.Add(new Token(type, value));
        }
        
        private bool IsNumber(char symbol)
        {
            foreach (char number in "1234567890")
            {
                if (symbol == number) 
                    return true;
            }

            return false;
        }
        
        private bool IsLetter(char symbol)
        {
            foreach (char letter in ":.qwertyuiopasdfghjklzxcvbnmQAZWSXEDCRFVTGBYHNUJMIKOLP1234567890")
            {
                if (symbol == letter)
                    return true;
            }

            return false;
        }
        
        private bool IsLetterOrNumber(char symbol)
        {
            if (IsLetter(symbol) || IsNumber(symbol)) 
                return true;

            return false;
        }
        
        private bool Match(string name)
        {
            foreach(Operator op in operators)
            {
                if (op.operatorSymbol == name) 
                    return true;
            }

            return false;
        }

        private TokenType GetOperatorToken(string name)
        {
            foreach (Operator op in operators)
            {
                if (op.operatorSymbol == name) 
                    return op.type;
            }

            throw new Exception("TYPE:005 Uncorrect operator!");
        }

        private class Operator
        {
            public string operatorSymbol;
            public TokenType type;

            public Operator(char operatorSymbol, TokenType type)
            {
                this.operatorSymbol = operatorSymbol.ToString();
                this.type = type;
            }

            public Operator(string operatorSymbol, TokenType type)
            {
                this.operatorSymbol = operatorSymbol;
                this.type = type;
            }

            public string GetChar()
            {
                return operatorSymbol;
            }

            public new TokenType GetType()
            {
                return type;
            }
        }
    }
}