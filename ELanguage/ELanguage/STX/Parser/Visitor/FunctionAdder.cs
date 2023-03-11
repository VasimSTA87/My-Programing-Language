using ELanguage.Parser.Expressions;
using ELanguage.Parser.Statements;
using ELanguage.STX.Parser.Expressions;
using ELangugage;

namespace ELanguage
{
    internal class FunctionAdder : Visitor
    {

        public void Visit(UseStatement st)
        {

        }

        public void Visit(ArrayAccessExpression st)
        {
            st.index.Accept(this);
        }

        public void Visit(ArrayAssigmentStatement st)
        {
            st.index.Accept(this);
            st.expression.Accept(this);
        }

        public void Visit(AssigmentStatement st)
        {
            st.expression.Accept(this);
        }

        public void Visit(BlockStatement st)
        {
            foreach(Statement statement in st.statements)
            {
                statement.Accept(this);
            }
        }

        public void Visit(BreakStatement st)
        {
            st.Accept(this);
        }

        public void Visit(ContinueStatement st)
        {
            st.Accept(this);
        }

        public void Visit(DoWhileStatement st)
        {
            st.conditional.Accept(this);
            st.statement.Accept(this);
        }

        public void Visit(ForStatement st)
        {
            st.initialization.Accept(this);
            st.termination.Accept(this);
            st.increment.Accept(this);
            st.statement.Accept(this);
        }

        public void Visit(FunctionDefineStatement st)
        {
            st.body.Accept(this);
            st.Execute();
        }

        public void Visit(FunctionStatement st)
        {
            st.function.Accept(this);
        }

        public void Visit(IfStatement st)
        {
            st.condition.Accept(this);
            st.ifStatement.Accept(this);
            st.elseStatement?.Accept(this);
        }

        public void Visit(PrintlnStatement st)
        {
            st.expression.Accept(this);
        }

        public void Visit(PrintStatement st)
        {
            st.expression.Accept(this);
        }

        public void Visit(ReturnStatement st)
        {

        }

        public void Visit(WhileStatement st)
        {
            st.statement.Accept(this);
            st.conditional.Accept(this);
        }

        public void Visit(BinaryExpression st)
        {
            st.expression1.Accept(this);
            st.expression2.Accept(this);
        }

        public void Visit(ConditionalExpression st)
        {
            st.expression1.Accept(this);
            st.expression2.Accept(this);
        }

        public void Visit(FunctionalExpression st)
        {
            foreach(Expression expression in st.arguments)
            {
                expression.Accept(this);
            }
        }

        public void Visit(ValueExpression st)
        {
            
        }

        public void Visit(UnaryExpression st)
        {
            st.expression.Accept(this);
        }

        public void Visit(VariableExpression st)
        {
            
        }

        public void Visit(VariableValue st)
        {
            
        }

        public void Visit(IncrementExpression st)
        {
            
        }
    }
}
