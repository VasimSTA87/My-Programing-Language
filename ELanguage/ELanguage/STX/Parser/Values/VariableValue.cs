using ELanguage;

namespace ELangugage
{
    internal class VariableValue : Expression
    {
        private Value value;

        public VariableValue(string value)
        {
            this.value = new StringValue(value);
        }

        public VariableValue(double value)
        {
            this.value = new NumberValue(value);
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
