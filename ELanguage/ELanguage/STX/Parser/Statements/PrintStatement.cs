using ELanguage;
using System;

namespace ELangugage
{
    internal class PrintStatement : Statement
    {
        public Expression expression;

        public PrintStatement(Expression expression)
        {
            this.expression = expression;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            System.Console.Write(expression.Eval().AsString());
        }
    }
}