using ELangugage;
using System;
using System.Collections.Generic;

namespace ELanguage.Parser.Values
{
    internal class ArrayValue : Value
    {
        private Value[] elemetns;

        public ArrayValue(int length)
        {
            elemetns = new Value[length];
        }
        
        public ArrayValue(Value[] elemetns)
        {
            List<Value> array = new List<Value>();

            for(int i = 0; i < elemetns.Length; i++)
                array.Add(elemetns[i]);

            this.elemetns = array.ToArray();
        }
        
        public ArrayValue(ArrayValue array)
        {
            elemetns = array.elemetns;
        }
        
        public ArrayValue(string[] arr)
        {
            List<Value> array = new List<Value>();

            for (int i = 0; i < elemetns.Length; i++)
                array.Add(new StringValue(arr[i]));
            
            elemetns = array.ToArray();
        }

        public Value GetValue(int index)
        {
            return elemetns[index];
        }

        public void SetValue(int index, Value value)
        {
            elemetns[index] = value;
        }

        public override string AsString()
        {
            string result = "";

            foreach (Value value in elemetns)
                result += $"[{value.AsString()}]";
            
            return result;
        }
    }
}
