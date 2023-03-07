using ELanguage;
using System;
using System.Windows.Forms;

namespace ELangugage
{
    internal class PrintlnStatement : Statement
    {
        public Expression expression;

        public PrintlnStatement(Expression expression)
        {
            this.expression = expression;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            System.Console.WriteLine(expression.Eval().AsString());
        }
    }
}