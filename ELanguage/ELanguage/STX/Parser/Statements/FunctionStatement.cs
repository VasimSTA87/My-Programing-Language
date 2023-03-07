using ELanguage.Parser.Expressions;
using ELangugage;

namespace ELanguage.Parser.Statements
{
    internal class FunctionStatement : Statement
    {
        public FunctionalExpression function;

        public FunctionStatement(FunctionalExpression function)
        {
            this.function = function;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void Execute()
        {
            function.Eval();
        }
    }
}
