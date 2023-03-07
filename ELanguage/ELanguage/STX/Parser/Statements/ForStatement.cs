using ELanguage;

namespace ELangugage
{
    internal class ForStatement : Statement
    {
        public Statement initialization;
        public Expression termination;
        public Statement increment;
        public Statement statement;

        public ForStatement(Statement initialization, Expression termination, Statement increment, Statement block)
        {
            this.initialization = initialization;
            this.termination = termination;
            this.increment = increment;
            this.statement = block;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            for (initialization.Execute(); termination.Eval().AsString() != "False"; increment.Execute())
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
