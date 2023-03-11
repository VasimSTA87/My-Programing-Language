using ELanguage.Parser;
using ELangugage;
using System;

namespace ELanguage.Libs
{
    internal class Time : ILib
    {
        public void Init()
        {
            throw new NotImplementedException();
        }

        private class Now : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(DateTime.Now.ToString());
            }
        }
        
        private class Today : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(DateTime.Today.ToString());
            }
        }
        
        private class UtcNow : Function
        {
            public Value Execute(params Value[] args)
            {
                return new StringValue(DateTime.UtcNow.ToString());
            }
        }
        
        private class IsLeapYear : Function
        {
            public Value Execute(params Value[] args)
            {
                return new NumberValue(DateTime.IsLeapYear((int)args[0].AsDouble()));
            }
        }
        
        private class DaysInMonth : Function
        {
            public Value Execute(params Value[] args)
            {
                return new NumberValue(DateTime.DaysInMonth((int)args[0].AsDouble(), (int)args[0].AsDouble()));
            }
        }
    }
}
