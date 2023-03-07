using ELanguage.Parser.Values;
using ELangugage;
using System;

namespace ELanguage.Parser.Statements
{
    internal class ArrayAccessExpression : Expression
    {
        public string variable;
        public Expression index;

        public ArrayAccessExpression(string variable, Expression index)
        {
            this.variable = variable;
            this.index = index;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            Value var = UserVariables.Get(variable);

            if (var is ArrayValue)
            {
                ArrayValue arrayValue = (ArrayValue)var;
                return arrayValue.GetValue((int)index.Eval().AsDouble());
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
