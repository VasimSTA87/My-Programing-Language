using ELanguage;
using System;

namespace ELangugage
{
    internal class ContinueStatement : Exception, Statement
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            throw this;
        }
    }
}
