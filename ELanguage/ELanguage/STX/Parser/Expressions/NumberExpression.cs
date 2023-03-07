using ELanguage;

namespace ELangugage
{
    internal class ValueExpression : Expression
    {
        public Value value;

        public ValueExpression(double value)
        {
            this.value = new NumberValue(value);
        }
        
        public ValueExpression(string value)
        {
            this.value = new StringValue(value);
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            return value;
        }
    }
}
