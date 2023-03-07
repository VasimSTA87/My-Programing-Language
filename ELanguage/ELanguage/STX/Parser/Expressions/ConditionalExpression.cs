using ELanguage;
using System;

namespace ELangugage
{
    internal class ConditionalExpression : Expression
    {
        public enum Operator
        {
            Plus,
            Minus,
            Multiply,
            Divide,

            Equals,
            NotEquals,

            LT,
            LTEquals,
            GT,
            GTEquals,

            And,
            Or,

            Excl,
            BitAnd,
            BitOr
        }

        public Expression expression1;
        public Expression expression2;
        private Operator operation;

        public ConditionalExpression(Expression expression1, Expression expression2, Operator operation)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
            this.operation = operation;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            Value value1 = expression1.Eval();
            Value value2 = expression2.Eval();

            double number1;
            double number2;

            if(value1 is StringValue)
            {
                number1 = value1.AsString().CompareTo(value2.AsString());
                number2 = 0;
            }
            else
            {
                number1 = value1.AsDouble();
                number2 = value2.AsDouble();
            }

            bool result = false;

            switch (operation)
            {
                case Operator.Equals:
                    result = number1 == number2;
                    break;
                case Operator.NotEquals:
                    result = number1 != number2;
                    break;
                case Operator.LT: 
                    result = number1 < number2;
                    break;
                case Operator.LTEquals:
                    result = number1 <= number2;
                    break;
                case Operator.GT:
                    result = number1 > number2;
                    break;
                case Operator.GTEquals:
                    result = number1 >= number2;
                    break;
                case Operator.And:
                    result = (number1 != 0) && (number2 != 0);
                    break;
                case Operator.Or:
                    result = (number1 != 0) || (number2 != 0);
                    break;
                case Operator.BitAnd:
                    result = (number1 != 0) & (number2 != 0);
                    break;
                case Operator.BitOr:
                    result = (number1 != 0) | (number2 != 0);
                    break;
                default:
                    throw new Exception();
            }

            return new StringValue(result ? "True" : "False");
        }
    }
}