using ELanguage.Parser;
using ELangugage;
using System;

namespace ELanguage.Libs
{
    internal class UseMath : ILib
    {
        public void Init()
        {
            Functions.Set("sin", new Sin());
            Functions.Set("cos", new Cos());
            Functions.Set("atan", new Atan());
            Functions.Set("abs", new Abs());
            Functions.Set("acos", new Acos());
            Functions.Set("asin", new Asin());
            Functions.Set("ceiling", new Ceiling());
            Functions.Set("cosh", new Cosh());
            Functions.Set("exp", new Exp());
            Functions.Set("floor", new Floor());
            Functions.Set("IEEERemainder", new IEEERemainder());
            Functions.Set("log", new Log());
            Functions.Set("log10", new Log10());
            Functions.Set("max", new Max());
            Functions.Set("min", new Min());
            Functions.Set("pow", new Pow());
            Functions.Set("round", new Round());
            Functions.Set("sign", new Sign());
            Functions.Set("sinh", new Sinh());
            Functions.Set("sqrt", new Sqrt());
            Functions.Set("tan", new Tan());
            Functions.Set("tanh", new Tanh());
            Functions.Set("truncate", new Truncate());
            Functions.Set("random", new Random());
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
