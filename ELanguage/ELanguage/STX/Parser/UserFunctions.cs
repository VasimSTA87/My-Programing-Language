using ELanguage.Parser.Statements;
using ELangugage;
using System.Collections.Generic;

namespace ELanguage.Parser
{
    internal class UserFunctions : Function
    {
        private List<string> arguments;
        private Statement body;

        public UserFunctions(List<string> arguments, Statement body)
        {
            this.arguments = arguments;
            this.body = body;
        }

        public int GetArgumentsCount()
        {
            return arguments.Count;
        }

        public string GetArgumentName(int index)
        {
            if (index < 0 || index >= arguments.Count) return "";
            return arguments[index];
        }

        public Value Execute(params Value[] args)
        {
            try
            {
                body.Execute();
            }
            catch (ReturnStatement rt)
            {
                return rt.GetValue();
            }


            return new NumberValue(0);
        }
    }
}
