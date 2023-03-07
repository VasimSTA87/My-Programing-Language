using ELangugage;
using System;

namespace ELanguage.Parser.Statements
{
    internal class ReturnStatement : Exception, Statement
    {
        public Expression expression;
        public Value result;

        public ReturnStatement(Expression expression)
        {
            this.expression = expression;
        }

        public Value GetValue()
        {
            return result;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            result = expression.Eval();
            throw this;
        }
    }
}
