using ELangugage;

namespace ELanguage.Parser
{
    internal interface Function
    {
        Value Execute(params Value[] args);
    }
}