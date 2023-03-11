using ELanguage.Parser;
using ELanguage.Parser.Values;
using ELangugage;
using System.IO;
using System.Text;

namespace ELanguage.Libs
{
    internal class Sysio : ILib
    {
        public void Init()
        {
            Functions.functions.Add("readText", new ReadAllText());
            Functions.functions.Add("readBytes", new ReadAllBytes());
            Functions.functions.Add("readLines", new ReadAllLines());
            Functions.functions.Add("write", new Write());
            Functions.functions.Add("delete", new Delete());
            Functions.functions.Add("exists", new Exists());
            Functions.functions.Add("move", new Move());
            Functions.functions.Add("copy", new Copy());
            Functions.functions.Add("replace", new Replace());
            Functions.functions.Add("clear", new Clear());
        }

        private class ReadAllText : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(File.ReadAllText("C:\\Users\\User\\source\\repos\\ELanguage\\ELanguage\\Example\\file2.cfm"));
            }
        }
        
        private class ReadAllBytes : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(File.ReadAllBytes(args[0].AsString()).ToString());
            }
        }
        
        private class ReadAllLines : Function
        {
            public Value Execute(params Value[] args)
            {
                return new ArrayValue(File.ReadAllLines(args[0].AsString()));
            }
        }
        
        private class Write : Function
        {
            public Value Execute(params Value[] args)
            {
                var file = File.OpenWrite(args[0].AsString());

                byte[] info = new UTF8Encoding(true).GetBytes(args[1].AsString());
                file.Write(info, 0, info.Length);

                return new NumberValue(0);
            }
        }
        
        private class Delete : Function
        {
            public Value Execute(params Value[] args)
            {
                File.Delete(args[0].AsString());

                return new NumberValue(0);
            }
        }
        
        private class Exists : Function
        {
            public Value Execute(params Value[] args)
            {
                return new NumberValue(File.Exists(args[0].AsString()));
            }
        }
        
        private class Move : Function
        {
            public Value Execute(params Value[] args)
            {
                File.Move(args[0].AsString(), args[1].AsString());
                return new NumberValue(0);
            }
        }
        
        private class Copy : Function
        {
            public Value Execute(params Value[] args)
            {
                File.Copy(args[0].AsString(), args[1].AsString());
                return new NumberValue(0);
            }
        }
        
        private class Replace : Function
        {
            public Value Execute(params Value[] args)
            {
                File.Replace(args[0].AsString(), args[1].AsString(), args[2].AsString());
                return new NumberValue(0);
            }
        }
        
        private class Clear : Function
        {
            public Value Execute(params Value[] args)
            {
                File.WriteAllText(args[0].AsString(), "");
                return new NumberValue(0);
            }
        }
        
    }
}
