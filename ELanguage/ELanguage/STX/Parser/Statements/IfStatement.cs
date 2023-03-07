using ELanguage;

namespace ELangugage
{
    internal class IfStatement : Statement
    {
        public Expression condition;
        public Statement ifStatement;
        public Statement elseStatement;

        public IfStatement(Expression expression, Statement ifStatement, Statement elseStatement)
        {
            this.condition = expression;
            this.ifStatement = ifStatement;
            this.elseStatement = elseStatement;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            string result = condition.Eval().AsString();

            if (result != "False")
                ifStatement.Execute();
            else if (elseStatement != null)
                elseStatement.Execute();

        }
    }
}
