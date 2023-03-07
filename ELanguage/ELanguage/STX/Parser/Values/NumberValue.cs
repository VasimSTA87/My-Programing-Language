using System;

namespace ELangugage
{
    internal class NumberValue : Value
    {
        private double value;

        public NumberValue(double value)
        {
            this.value = value;
        }
        
        public NumberValue(bool value)
        {
            this.value = value ? 1 : 0;
        }

        public override bool AsBoolean()
        {
            if (value == 1) return true;
            else if (value == 0) return false;

            else throw new Exception("TYPE:???");
        }

        public override double AsDouble()
        {
            return value;
        }
        
        public override string AsString()
        {
            return value.ToString();
        }
    }
}
