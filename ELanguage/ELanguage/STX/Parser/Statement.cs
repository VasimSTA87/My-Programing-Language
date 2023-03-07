using ELanguage.Parser;

namespace ELangugage
{
    internal interface Statement : Node
    {
        void Execute();
    }
}
