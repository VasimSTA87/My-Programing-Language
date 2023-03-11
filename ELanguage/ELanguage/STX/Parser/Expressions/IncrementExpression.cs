using ELangugage;

namespace ELanguage.STX.Parser.Expressions
{
    internal class IncrementExpression : Expression
    {
        private string variable;
        private string operation;

        public IncrementExpression(string variable, string operation)
        {
            this.variable = variable;
            this.operation = operation;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            double var = 0;

            switch (operation)
            {
                case "++":
                    var = UserVariables.Get(variable).AsDouble() + 1;
                    break;
                case "--":
                    var = UserVariables.Get(variable).AsDouble() - 1;
                    break;
            }
            

            return new NumberValue(var);
        }
    }
}
