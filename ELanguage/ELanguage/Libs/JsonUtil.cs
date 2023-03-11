using ELanguage.Parser;
using ELangugage;
using System.Text.Json;

namespace ELanguage.Libs
{
    internal class JsonUtil : ILib
    {
        public void Init()
        {
            Functions.Set("serialize", new Serialize());
            Functions.Set("desToString", new DeSerializeAsString());
            Functions.Set("desToNum", new DeSerializeAsNumber());
        }

        private class Serialize : Function
        {
            public Value Execute(params Value[] args)
            {
                string value = JsonSerializer.Serialize(args[0].AsString());

                return new StringValue(value);
            }
        }
        
        private class DeSerializeAsString : Function
        {
            public Value Execute(params Value[] args)
            {
                string value = JsonSerializer.Deserialize<string>(args[0].AsString());

                return new StringValue(value);
            }
        }

        private class DeSerializeAsNumber : Function
        {
            public Value Execute(params Value[] args)
            {
                int value = JsonSerializer.Deserialize<int>(args[0].AsDouble());

                return new NumberValue(value);
            }
        }
    }
}