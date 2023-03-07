using ELanguage;

namespace ELangugage
{
    internal class WhileStatement : Statement
    {
        public Expression conditional;
        public Statement statement;

        public WhileStatement(Expression conditional, Statement statement)
        {
            this.conditional = conditional;
            this.statement = statement;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            while (conditional.Eval().AsString() != "False")
            {
                try
                {
                    statement.Execute();
                }
                catch (BreakStatement)
                {
                    break;
                }
                catch (ContinueStatement)
                {
                    // continue
                }
            }
        }
    }
}