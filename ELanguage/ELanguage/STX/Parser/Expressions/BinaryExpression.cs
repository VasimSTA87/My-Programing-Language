using ELanguage;
using ELanguage.Parser.Values;
using System;

namespace ELangugage
{
    internal class BinaryExpression : Expression
    {
        public Expression expression1;
        public Expression expression2;
        public string operation;

        public BinaryExpression(Expression expression1, Expression expression2, string operation)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
            this.operation = operation;
        }

        public void Accept(Visitor visitor) => visitor.Visit(this);
        
        public Value Eval()
        {
            Value value1 = expression1.Eval();
            Value value2 = expression2.Eval();

            if (value1 is StringValue && value2 is NumberValue && operation == "*")
            {
                string str = value1.AsString();
                int number = (int)value2.AsDouble();

                string result = str;

                for (int i = 0; i < number; i++)
                    result += str;
                
                return new StringValue(result);
            } 
            if ((value1 is StringValue || value2 is StringValue) || (value1 is ArrayValue || value2 is ArrayValue) )
            {
                string str1 = value1.AsString();
                string str2 = value2.AsString();

                switch (operation)
                {
                    case "+": 
                        return new StringValue(str1 + str2);
                    default:
                        throw new Exception();
                }
            }

            double number1 = value1.AsDouble();
            double number2 = value2.AsDouble();
            
            switch (operation)
            {
                case "**":
                    double value = number1;

                    for (int i = 1; i < number2; i++)
                        value = number1 * value;
                    
                    return new NumberValue(value);
                case "-": return new NumberValue(number1 - number2);
                case "*": return new NumberValue(number1 * number2);
                case "/": return new NumberValue(number1 / number2);
                case "+":
                default:  return new NumberValue(number1 + number2);
            }
        }
    }
}