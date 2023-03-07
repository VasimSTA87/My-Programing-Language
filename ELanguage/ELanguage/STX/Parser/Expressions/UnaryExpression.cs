using ELanguage;

namespace ELangugage
{
    internal class UnaryExpression : Expression
    {
        public Expression expression;
        private char operation;

        public UnaryExpression(Expression expression, char operation)
        {
            this.expression = expression;
            this.operation = operation;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            switch (operation)
            {
                case '-':
                    return new NumberValue(-expression.Eval().AsDouble());
                case '+':
                default:
                    return expression.Eval();
            }
        }
    }
}
