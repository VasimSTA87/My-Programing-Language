using ELangugage;

namespace ELanguage
{
    internal class UseStatement : Statement
    {
        public string path;

        public UseStatement(string path)
        {
            this.path = path;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
        
        public void Execute()
        {
            switch (path)
            {
                case "std":
                    Functions.AddStdFunctions();
                    break;
                case "math":
                    Functions.AddMathFunctions();
                    break;
                case "io":
                    Functions.AddIOFunctions();
                    break;
            }
        }
    }
}
