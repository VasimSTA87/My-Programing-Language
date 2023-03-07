namespace ELanguage.Parser
{
    internal interface Node
    {
        void Accept(Visitor visitor);
    }
}
