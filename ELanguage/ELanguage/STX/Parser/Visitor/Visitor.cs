using ELanguage.Parser.Expressions;
using ELanguage.Parser.Statements;
using ELangugage;
using System.Reflection;

namespace ELanguage
{
    internal interface Visitor
    {
        void Visit(ArrayAccessExpression st);
        void Visit(ArrayAssigmentStatement st);
        void Visit(AssigmentStatement st);
        void Visit(BlockStatement st);
        void Visit(BreakStatement st);
        void Visit(ContinueStatement st);
        void Visit(DoWhileStatement st);
        void Visit(ForStatement st);
        void Visit(FunctionDefineStatement st);
        void Visit(FunctionStatement st);
        void Visit(IfStatement st);
        void Visit(PrintlnStatement st);
        void Visit(PrintStatement st);
        void Visit(ReturnStatement st);
        void Visit(WhileStatement st);

        void Visit(BinaryExpression st);
        void Visit(ConditionalExpression st);
        void Visit(FunctionalExpression st);
        void Visit(ValueExpression st);
        void Visit(UnaryExpression st);
        void Visit(VariableExpression st);
        void Visit(VariableValue st);
        void Visit(UseStatement st);
    }
}
