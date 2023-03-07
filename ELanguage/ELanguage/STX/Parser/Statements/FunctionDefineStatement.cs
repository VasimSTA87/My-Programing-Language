using ELangugage;
using System.Collections.Generic;

namespace ELanguage.Parser.Statements
{
    internal class FunctionDefineStatement : Statement
    {
        public string name;
        public List<string> arguments;
        public Statement body;

        public FunctionDefineStatement(string name, List<string> arguments, Statement body)
        {
            this.name = name;
            this.arguments = arguments;
            this.body = body;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            Functions.Set(name, new UserFunctions(arguments, body));
        }
    }
}
