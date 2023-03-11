using ELanguage.Parser;
using System.Collections.Generic;

namespace ELangugage
{
    internal class Functions
    {
        public static Dictionary<string, Function> functions = new Dictionary<string, Function>();
        
        public static bool IsExists(string name)
        {
            return functions.ContainsKey(name);
        }

        public static Function Get(string name)
        {
            if (!IsExists(name)) return null;
            return functions[name];
        }

        public static void Set(string name, Function value)
        {
            if (!IsExists(name))
                functions.Add(name, value);
        }
    }
}