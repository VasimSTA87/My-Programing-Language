using ELanguage.Parser;
using ELangugage;
using System;

namespace ELanguage.Libs
{
    internal class Encoding : ILib
    {
        public void Init()
        {
            Functions.Set("setInputEncoding", new SetInputEncoding());
            Functions.Set("setOutputEncoding", new SetOutputEncoding());
            Functions.Set("getEncodingName", new GetEncoding());
        }

        private class SetInputEncoding : Function
        {
            public Value Execute(params Value[] args)
            {
                switch (args[0].AsString())
                {
                    case "UTF7":
                        Console.InputEncoding = System.Text.Encoding.UTF7;
                        break;
                    case "UTF8":
                        Console.InputEncoding = System.Text.Encoding.UTF8;
                        break;
                    case "UTF32":
                        Console.InputEncoding = System.Text.Encoding.UTF32;
                        break;
                    case "ASCII":
                        Console.InputEncoding = System.Text.Encoding.ASCII;
                        break;
                    case "BigEndianUnicode":
                        Console.InputEncoding = System.Text.Encoding.BigEndianUnicode;
                        break;
                    case "unicode":
                        Console.InputEncoding = System.Text.Encoding.Unicode;
                        break;
                    case "default":
                    default:
                        Console.InputEncoding = System.Text.Encoding.Default;
                        break;
                }
                return new NumberValue(0);
            }
        }
        
        private class SetOutputEncoding : Function
        {
            public Value Execute(params Value[] args)
            {
                switch (args[0].AsString())
                {
                    case "UTF7":
                        Console.OutputEncoding = System.Text.Encoding.UTF7;
                        break;
                    case "UTF8":
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        break;
                    case "UTF32":
                        Console.OutputEncoding = System.Text.Encoding.UTF32;
                        break;
                    case "ASCII":
                        Console.OutputEncoding = System.Text.Encoding.ASCII;
                        break;
                    case "BigEndianUnicode":
                        Console.OutputEncoding = System.Text.Encoding.BigEndianUnicode;
                        break;
                    case "unicode":
                        Console.OutputEncoding = System.Text.Encoding.Unicode;
                        break;
                    case "default":
                    default:
                        Console.OutputEncoding = System.Text.Encoding.Default;
                        break;
                }
                return new NumberValue(0);
            }
        }

        private class GetEncoding : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(Console.OutputEncoding.EncodingName);
            }
        }
    }
}
