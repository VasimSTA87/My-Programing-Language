using ELanguage;

namespace ELangugage
{
    internal class DoWhileStatement : Statement
    {
        public Expression conditional;
        public Statement statement;

        public DoWhileStatement(Expression conditional, Statement statement)
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
            do
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

            } while (conditional.Eval().AsString() != "False");
        }
    }
}