namespace ELangugage
{
    public abstract class Value
    {
        public virtual double AsDouble()
        {
            return 0;
        }

        public virtual string AsString()
        {
            return "";
        }

        public virtual bool AsBoolean()
        {
            return false;
        }

        internal virtual Statement AsModule()
        {
            return null;
        }
    }
}