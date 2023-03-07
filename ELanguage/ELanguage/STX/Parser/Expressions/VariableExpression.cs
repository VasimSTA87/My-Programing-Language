using ELanguage;

namespace ELangugage
{
    internal class VariableExpression : Expression
    {
        private string name;

        public VariableExpression(string name)
        {
            this.name = name;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            return UserVariables.Get(name);
        }
    }
}
