using ELanguage;

namespace ELangugage
{
    internal class AssigmentStatement : Statement
    {
        public string variable;
        public Expression expression;

        public AssigmentStatement(string variable, Expression expression)
        {
            this.variable = variable;
            this.expression = expression;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            Value result = expression.Eval();
            UserVariables.Set(variable, result);
        }
    }
}
