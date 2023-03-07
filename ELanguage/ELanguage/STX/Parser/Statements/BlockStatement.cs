using ELanguage;
using System.Collections.Generic;

namespace ELangugage
{
    internal class BlockStatement : Statement
    {
        public List<Statement> statements;

        public BlockStatement()
        {
            statements = new List<Statement>();
        }

        public void Add(Statement statement)
        {
            statements.Add(statement);
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            foreach(Statement statement in statements)
            {
                statement.Execute();
            }
        }
    }
}
