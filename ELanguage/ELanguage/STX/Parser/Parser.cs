using ELanguage;
using ELanguage.Parser;
using ELanguage.Parser.Expressions;
using ELanguage.Parser.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ELangugage
{
    internal class Parser
    {
        private static Token eof = new Token(TokenType.EOF);
        private List<Token> tokens;
        private int pos;
        private int size;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            size = tokens.Count;
        }

        public Statement Parse()
        {
            BlockStatement result = new BlockStatement();

            while (!Match(TokenType.EOF))
                result.Add(Statement());
            
            return result;
        }

        private Statement Block()
        {
            BlockStatement block = new BlockStatement();
            Consume(TokenType.Lbrace);

            while (!Match(TokenType.Rbrace))
                block.Add(Statement());
            
            return block;
        }

        private Statement StatementOrBlock()
        {
            if (Get(0).getType() == TokenType.Lbrace) 
                return Block();

            return Statement();
        }

        private Statement Statement()
        {
            if (Match(TokenType.Print))
                return new PrintStatement(Expression());

            if (Match(TokenType.Println))
                return new PrintlnStatement(Expression());

            if (Match(TokenType.If))
                return IfElse();

            if (Match(TokenType.While))
                return WhileStatement();

            if (Match(TokenType.For))
                return ForStatement();

            if (Match(TokenType.Do))
                return DoWhileStatement();

            if (Match(TokenType.Break))
                return new BreakStatement();

            if (Match(TokenType.Continue))
                return new ContinueStatement();
            
            if (Match(TokenType.Func))
                return FunctionsDefine();
            
            if (Match(TokenType.Return))
                return new ReturnStatement(Expression());
            
            if (Match(TokenType.Use))
                return new UseStatement(Expression().Eval().AsString());
            
            if (Match(TokenType.Import))
                return ImportStatement();
            
            if (Get(0).getType() == TokenType.Word && Get(1).getType() == TokenType.LParen)
                return new FunctionStatement(Function());

            return AssigmentStatement();
        }
        
        private Statement AssigmentStatement()
        {
            if(Get(0).getType() == TokenType.Word && Get(1).getType() == TokenType.Equals)
            {
                string variable = Consume(TokenType.Word).getValue();
                Consume(TokenType.Equals);
                return new AssigmentStatement(variable, Expression());
            }
            if(Get(0).getType() == TokenType.Word && Get(1).getType() == TokenType.Lbracket)
            {
                string variable = Consume(TokenType.Word).getValue();
                Consume(TokenType.Lbracket);
                Expression index = Expression();
                Consume(TokenType.Rbracket);
                Consume(TokenType.Equals);
                return new ArrayAssigmentStatement(variable, index, Expression());
            }

            throw new Exception("invalid syntax on " + Get(0).getType() + ": " + Get(0).getValue());
        }
        
        private Statement IfElse()
        {
            Expression conditional = Expression();
            Statement ifStatement = StatementOrBlock();
            Statement elseStatement;

            if (Match(TokenType.Else))
                elseStatement = StatementOrBlock();
            else
                elseStatement = null;

            return new IfStatement(conditional, ifStatement, elseStatement);
        }

        private Statement WhileStatement()
        {
            Expression conditional = Expression();
            Statement statement = StatementOrBlock();

            return new WhileStatement(conditional, statement);
        }
        
        private Statement DoWhileStatement()
        {
            Statement statement = StatementOrBlock();
            Consume(TokenType.While);
            Expression conditional = Expression();

            return new DoWhileStatement(conditional, statement);
        }

        private Statement ForStatement()
        {
            Statement initialization = Statement();
            Expression termination = Expression();
            Statement increment = Statement();
            Statement statement = StatementOrBlock();

            return new ForStatement(initialization, termination, increment, statement);
        }

        private Statement ImportStatement()
        {

            string path = Expression().Eval().AsString();

            List<Token> tokens = new Lexer(File.ReadAllText(path)).Tokenize();
            Statement file = new Parser(tokens).Parse();

            return file;
        }

        private Expression Expression()
        {
            return LogicalOr();
        }

        private FunctionDefineStatement FunctionsDefine()
        {
            string name = Consume(TokenType.Word).getValue();
            Consume(TokenType.LParen);

            List<string> argsNames = new List<string>();

            while (!Match(TokenType.RParen))
            {
                argsNames.Add(Consume(TokenType.Word).getValue());
                
                Match(TokenType.Comma);
            }

            Statement body = StatementOrBlock();

            return new FunctionDefineStatement(name, argsNames,body);
        }
        
        private FunctionalExpression Function()
        {
            string name = Consume(TokenType.Word).getValue();
            Consume(TokenType.LParen);
            FunctionalExpression expression = new FunctionalExpression(name);

            while (!Match(TokenType.RParen))
            {
                expression.AddArgument(Expression());
                Match(TokenType.Comma);
            }

            return expression;
        }

        private Expression Element()
        {
            string variable = Consume(TokenType.Word).getValue();
            Consume(TokenType.Lbracket);
            Expression index = Expression();
            Consume(TokenType.Rbracket);

            return new ArrayAccessExpression(variable, index);
        }

        private Expression LogicalOr()
        {
            Expression result = LogicalAnd();

            if (Match(TokenType.BarBar))
                return new ConditionalExpression(result, LogicalAnd(), ConditionalExpression.Operator.Or);

            return result;
        }

        private Expression LogicalAnd()
        {
            Expression result = Equality();

            if (Match(TokenType.AmpAmp))
                return new ConditionalExpression(result, Equality(), ConditionalExpression.Operator.And);

            return result;
        }

        private Expression Equality()
        {
            Expression result = Conditional();

            if (Match(TokenType.EqualsEquals))
                return new ConditionalExpression(result, Conditional(), ConditionalExpression.Operator.Equals);
            
            if (Match(TokenType.ExclEquals))
                return new ConditionalExpression(result, Conditional(), ConditionalExpression.Operator.NotEquals);
            
            return result;
        }

        private Expression Conditional()
        {
            Expression result = Additive();

            while (true)
            {
                if (Match(TokenType.EqualsEquals))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.Equals);
                    continue;
                }
                if (Match(TokenType.ExclEquals))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.NotEquals);
                    continue;
                }
                if (Match(TokenType.LT))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.LT);
                    continue;
                }
                if (Match(TokenType.LTEquals))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.LTEquals);
                    continue;
                }
                if (Match(TokenType.GT))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.GT);
                    continue;
                }
                if (Match(TokenType.GTEquals))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.GTEquals);
                    continue;
                }
                if (Match(TokenType.Amp))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.BitAnd);
                    continue;
                }
                if (Match(TokenType.Bar))
                {
                    result = new ConditionalExpression(result, Additive(), ConditionalExpression.Operator.BitOr);
                    continue;
                }
                break;
            }
            return result;
        }

        private Expression Additive()
        {
            Expression result = Multiplicative();

            if (Match(TokenType.Plus))
                result = new BinaryExpression(result, Multiplicative(), '+');
            if (Match(TokenType.Minus))
                result = new BinaryExpression(result, Multiplicative(), '-');
            
            return result;
        }
        
        private Expression Multiplicative()
        {
            Expression result = Unary();

            if (Match(TokenType.Star))
                result = new BinaryExpression(result, Unary(), '*');
            if (Match(TokenType.Slash))
                result = new BinaryExpression(result, Unary(), '/');
            
            return result;
        }
        
        private Expression Unary()
        {
            if (Match(TokenType.Minus))
                return new UnaryExpression(Primary(), '-');
            if (Match(TokenType.Plus))
                return Primary();

            return Primary();
        }
        
        private Expression Primary()
        {
            Token current = Get(0);

            if (Match(TokenType.Number))
                return new ValueExpression(Double.Parse(current.getValue()));
            if (Get(0).getType() == TokenType.Word && Get(1).getType() == TokenType.LParen)
                return Function();
            if (Get(0).getType() == TokenType.Word && Get(1).getType() == TokenType.Lbracket)
                return Element();
            if (Match(TokenType.Word))
                return new VariableExpression(current.getValue());
            if (Match(TokenType.String))
                return new ValueExpression(current.getValue());

            if (Match(TokenType.LParen))
            {
                Expression result = Expression();
                Match(TokenType.RParen);
                return result;
            }

            throw new Exception("Stoped in: " + current.getType().ToString());
        }

        private Token Consume(TokenType type)
        {
            Token current = Get(0);

            if (type != current.getType())
                throw new Exception($"Token {current.getType()} doesn't match {type}");

            pos++;
            return current;
        }

        private bool Match(TokenType type)
        {
            Token current = Get(0);

            if (type != current.getType()) 
                return false;

            pos++;
            return true;
        }

        private Token Get(int relativePosition)
        {
            int position = pos + relativePosition;

            if (position >= size)
                return eof;

            return tokens[position];
        }
    }
}