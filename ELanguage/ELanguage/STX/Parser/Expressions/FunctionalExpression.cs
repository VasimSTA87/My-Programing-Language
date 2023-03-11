using ELangugage;
using System;
using System.Collections.Generic;

namespace ELanguage.Parser.Expressions
{
    internal class FunctionalExpression : Expression
    {
        private string name;
        public List<Expression> arguments;

        public FunctionalExpression(string name, List<Expression> arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }

        public FunctionalExpression(string name)
        {
            this.name = name;
            arguments= new List<Expression>();
        }

        public void AddArgument(Expression argument)
        {
            arguments.Add(argument);
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Value Eval()
        {
            int size = arguments.Count;
            Value[] values = new Value[size];

            for (int i = 0; i < size; i++)
            {
                values[i] = arguments[i].Eval();    
            }

            Function function = Functions.Get(name);

            if(function is UserFunctions)
            {
                UserFunctions userFunctions = (UserFunctions)function;

                if (size != userFunctions.GetArgumentsCount()) 
                    throw new Exception();

                UserVariables.Push();

                for (int i = 0; i < size; i++)
                {
                    UserVariables.Set(userFunctions.GetArgumentName(i), values[i]);
                }

                Value result = userFunctions.Execute(values);
                UserVariables.Pop();
                return result;
            }

            return function?.Execute(values);
        }
    }
}
