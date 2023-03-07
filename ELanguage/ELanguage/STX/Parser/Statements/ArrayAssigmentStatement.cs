using ELanguage.Parser.Values;
using ELangugage;
using System;

namespace ELanguage.Parser.Statements
{
    internal class ArrayAssigmentStatement : Statement
    {
        public string variable;
        public Expression index;
        public Expression expression;

        public ArrayAssigmentStatement(string variable, Expression index, Expression expression)
        {
            this.variable = variable;
            this.index = index;
            this.expression = expression;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            Value var = UserVariables.Get(variable);

            if (var is ArrayValue)
            {
                ArrayValue arrayValue = (ArrayValue) var;
                arrayValue.SetValue((int)index.Eval().AsDouble(), expression.Eval());
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
