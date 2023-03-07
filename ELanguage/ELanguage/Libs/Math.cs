using ELanguage.Parser;
using ELangugage;
using System;
using System.Collections.Generic;

namespace ELanguage.Libs
{
    internal class UseMath
    {
        public static void AddLib(Dictionary<string, Function> functions)
        {
            functions.Add("sin", new Sin());
            functions.Add("cos", new Cos());
            functions.Add("atan", new Atan());
            functions.Add("abs", new Abs());
            functions.Add("acos", new Acos());
            functions.Add("asin", new Asin());
            functions.Add("ceiling", new Ceiling());
            functions.Add("cosh", new Cosh());
            functions.Add("exp", new Exp());
            functions.Add("floor", new Floor());
            functions.Add("IEEERemainder", new IEEERemainder());
            functions.Add("log", new Log());
            functions.Add("log10", new Log10());
            functions.Add("max", new Max());
            functions.Add("min", new Min());
            functions.Add("pow", new Pow());
            functions.Add("round", new Round());
            functions.Add("sign", new Sign());
            functions.Add("sinh", new Sinh());
            functions.Add("sqrt", new Sqrt());
            functions.Add("tan", new Tan());
            functions.Add("tanh", new Tanh());
            functions.Add("truncate", new Truncate());
            functions.Add("random", new Random());
        }
    }

    internal class Sin : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Sin(args[0].AsDouble()));
        }
    }

    internal class Cos : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Cos(args[0].AsDouble()));
        }
    }

    internal class Atan : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Atan(args[0].AsDouble()));
        }
    }

    internal class Abs : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Abs(args[0].AsDouble()));
        }
    }

    internal class Acos : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Acos(args[0].AsDouble()));
        }
    }

    internal class Asin : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Asin(args[0].AsDouble()));
        }
    }

    internal class Ceiling : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Ceiling(args[0].AsDouble()));
        }
    }

    internal class Cosh : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Cosh(args[0].AsDouble()));
        }
    }

    internal class Exp : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Exp(args[0].AsDouble()));
        }
    }

    internal class Floor : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Floor(args[0].AsDouble()));
        }
    }

    internal class IEEERemainder : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 2)
                throw new Exception();

            return new NumberValue(System.Math.IEEERemainder(args[0].AsDouble(), args[1].AsDouble()));
        }
    }

    internal class Log : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Log(args[0].AsDouble()));
        }
    }

    internal class Log10 : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Log10(args[0].AsDouble()));
        }
    }

    internal class Max : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Max(args[0].AsDouble(), args[1].AsDouble()));
        }
    }

    internal class Min : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Min(args[0].AsDouble(), args[1].AsDouble()));
        }
    }

    internal class Pow : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Pow(args[0].AsDouble(), args[1].AsDouble()));
        }
    }

    internal class Round : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Round(args[0].AsDouble()));
        }
    }

    internal class Sign : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Sign(args[0].AsDouble()));
        }
    }

    internal class Sinh : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Sinh(args[0].AsDouble()));
        }
    }

    internal class Sqrt : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Sqrt(args[0].AsDouble()));
        }
    }

    internal class Tan : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Tan(args[0].AsDouble()));
        }
    }

    internal class Tanh : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Tanh(args[0].AsDouble()));
        }
    }

    internal class Truncate : Function
    {
        public Value Execute(params Value[] args)
        {
            if (args.Length != 1)
                throw new Exception();

            return new NumberValue(System.Math.Truncate(args[0].AsDouble()));
        }
    }

    internal class Random : Function
    {
        public Value Execute(params Value[] args)
        {
            int result;

            if(args.Length == 1)
                result = new System.Random().Next((int)args[0].AsDouble());
            else if (args.Length == 2)
                result = new System.Random().Next((int)args[0].AsDouble(), (int)args[1].AsDouble());
            else
                result = new System.Random().Next();

            return new NumberValue(result);
        }
    }
}
