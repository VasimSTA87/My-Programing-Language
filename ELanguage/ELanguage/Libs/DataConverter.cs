using ELanguage.Parser;
using ELanguage.Parser.Values;
using ELangugage;

namespace ELanguage.Libs
{
    internal class DataConverter : ILib
    {
        public void Init()
        {
            Functions.Set("toArray", new ToArray());
            Functions.Set("toNumber", new ToNumber());
            Functions.Set("toText", new ToText());
            Functions.Set("toBoolean", new ToBoolean());
        }

        private class ToArray : Function
        {
            public Value Execute(params Value[] args)
            {
                return new ArrayValue(args);
            }
        }
        
        private class ToNumber : Function
        {
            public Value Execute(params Value[] args)
            {
                return new NumberValue(args[0].AsDouble());
            }
        }
        
        private class ToText : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(args[0].AsString());
            }
        }
        
        private class ToBoolean : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(args[0].AsBoolean().ToString());
            }
        }

    }
}