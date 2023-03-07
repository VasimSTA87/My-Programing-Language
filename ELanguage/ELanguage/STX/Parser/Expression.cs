using ELanguage.Parser;

namespace ELangugage
{
    internal interface Expression : Node
    {
        Value Eval();
    }
}
