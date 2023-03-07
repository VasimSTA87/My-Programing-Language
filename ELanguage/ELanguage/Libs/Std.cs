using ELanguage.Parser;
using ELanguage.Parser.Values;
using ELangugage;
using System;
using System.Collections.Generic;

namespace ELanguage.Libs
{
    internal class UseStd
    {
        public static void AddLib(Dictionary<string, Function> functions)
        {
            functions.Add("printf", new Printf());
            functions.Add("printfln", new Printfln());
            functions.Add("newArray", new NewArray());
            functions.Add("sum", new Sum());
            functions.Add("endl", new Endl());
            functions.Add("read", new Read());
            //functions.Add("cloneFrom", new CloneFrom());
        }
    }

    internal class Printf : Function
    {
        public Value Execute(params Value[] args)
        {
            foreach (Value arg in args)
            {
                System.Console.Write(arg.AsString());
            }

            return new NumberValue(0);
        }
    }

    internal class Printfln : Function
    {
        public Value Execute(params Value[] args)
        {
            foreach (Value arg in args)
            {
                Console.WriteLine(arg.AsString());
            }

            return new NumberValue(0);
        }
    }

    internal class NewArray : Function
    {
        public Value Execute(params Value[] args)
        {
            return new ArrayValue(args);
        }
    }

    internal class Sum : Function
    {
        public Value Execute(params Value[] args)
        {
            double result = 0;

            foreach (Value arg in args)
            {
                result += arg.AsDouble();
            }

            return new NumberValue(result);
        }
    }

    internal class Endl : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 0)
                Console.WriteLine(5);

            return new NumberValue(0);
        }
    }

    internal class Read : Function
    {
        public Value Execute(params Value[] args)
        {
            if(args.Length == 0)
                return new StringValue(Console.ReadLine());

            throw new Exception();
        }
    }
    /*
    internal class CloneFrom : Function
    {
        public Value Execute(params Value[] args)
        {
            if (Modules.IsExists(args[0].AsString()))
            {
                Modules.Get(args[0].AsString());
            }
        }
    }*/

}
