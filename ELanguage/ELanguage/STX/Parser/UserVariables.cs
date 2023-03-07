using System;
using System.Collections.Generic;

namespace ELangugage
{
    public static class UserVariables
    {
        private static Stack<List<Variable>> stack = new Stack<List<Variable>>();

        public static List<Variable> variables = new List<Variable>()
        {
            new Variable("PI", new NumberValue(Math.PI)),
            new Variable("E", new NumberValue(Math.E)),
            new Variable("Zero", new NumberValue(0)),
        };

        public static void Push()
        {
            stack.Push(new List<Variable>(variables));
        }

        public static void Pop()
        {
            stack.Pop();
        }

        public static bool IsExists(string name)
        {
            foreach(Variable constant in variables)
            {
                if (constant.name == name)
                    return true;
            }
            return false;
        }

        public static Value Get(string name)
        {
            if (!IsExists(name))
                return null;
            foreach (Variable constant in variables)
            {
                if (constant.name == name)
                    return constant.value;
            }
            return Get("Zero");
        }
        
        public static Variable GetVariable(string name)
        {
            foreach (Variable variable in variables)
            {
                if (variable.name == name)
                    return variable;
            }
            return GetVariable("Zero");
        }

        public static void Set(string name, Value value)
        {
            if (!IsExists(name))
                variables.Add(new Variable(name, value));
            else
                GetVariable(name).value = value;
        }
    }

    public class Variable
    {
        public string name;
        public Value value;

        public Variable(string name, Value value)
        {
            this.name = name;
            this.value = value;
        }

        public string GetName()
        {
            return name;
        }
        public Value GetValue()
        {
            return value;
        }
    }
}