using ELanguage.Parser;
using ELanguage.Parser.Values;
using ELangugage;
using System;
using System.Collections.Generic;

namespace ELanguage.Libs
{
    internal class UseStd : ILib
    {
        public void Init()
        {
            Functions.functions.Add("printf", new Printf());
            Functions.functions.Add("printfln", new Printfln());
            Functions.functions.Add("newArray", new NewArray());
            Functions.functions.Add("sum", new Sum());
            Functions.functions.Add("endl", new Endl());
            Functions.functions.Add("read", new Read());
            Functions.functions.Add("len", new Len());
            Functions.functions.Add("inc", new Increment());
            Functions.functions.Add("dec", new Decrement());
            Functions.functions.Add("normalize", new Normalize());
            Functions.functions.Add("remove", new Remove());
            Functions.functions.Add("toLow", new ToLower());
            Functions.functions.Add("toUp", new ToUpper());
            Functions.functions.Add("contains", new Contains());
            Functions.functions.Add("get", new Get());
            Functions.functions.Add("toString", new ToString());
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
    
    internal class Len : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 1)
                return new NumberValue(args[0].AsString().Length);
            
            return new NumberValue(0);
        }
    }
    
    internal class Increment : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 1)
                return new NumberValue(args[0].AsDouble()+1);
            
            return new NumberValue(0);
        }
    }
    
    internal class Decrement : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 1)
                return new NumberValue(args[0].AsDouble()-1);
            
            return new NumberValue(0);
        }
    }

    internal class Normalize : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 1)
                return new StringValue(args[0].AsString().Normalize());
            
            return new StringValue("");
        }
    }
    
    internal class Remove : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length == 2)
                return new StringValue(args[0].AsString().Remove((int)args[0].AsDouble(), (int)args[1].AsDouble()));
            
            return new StringValue("");
        }
    }
    
    internal class ToLower : Function
    {
        public Value Execute(params Value[] args)
        {
            return new StringValue(args[0].AsString().ToLower());
        }
    }
    
    internal class ToUpper : Function
    {
        public Value Execute(params Value[] args)
        {
            return new StringValue(args[0].AsString().ToUpper());
        }
    }
    
    internal class Contains : Function
    {
        public Value Execute(params Value[] args)
        {
            return new NumberValue(args[0].AsString().Contains(args[1].AsString()));
        }
    }
    
    internal class Get : Function
    {
        public Value Execute(params Value[] args)
        {
            int index = (int)args[1].AsDouble();
            return new StringValue(args[0].AsString()[index].ToString());
        }
    }
    
    internal class ToString : Function
    {
        public Value Execute(params Value[] args)
        {
            return new StringValue(args[0].AsString());
        }
    }

}