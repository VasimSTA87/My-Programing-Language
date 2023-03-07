using System;

namespace ELangugage
{
    internal class StringValue : Value
    {
        private string value;

        public StringValue(string value)
        {
            this.value = value;
        }

        public override bool AsBoolean()
        {
            throw new Exception("TYPE:???");
        }

        public override double AsDouble()
        {
            try
            {
                return Double.Parse(value);
            }
            catch (Exception error)
            {
                Console.WriteLine($"TYPE:003 {error}");
            }
            return 0;
        }

        public override string AsString()
        {
            return value;
        }
    }
}
