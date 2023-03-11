using ELanguage;
using System;
using System.Collections.Generic;
using System.IO;

namespace ELangugage
{
    internal class Program
    {
        private static bool debugMode = false;
        private static bool testMode = true;

        private static void Main()
        {
            if (testMode)
            {
                // path to test file
                Run(File.ReadAllText("C:\\Users\\User\\source\\repos\\ELanguage\\ELanguage\\Example\\test.cfm"));
            }
            else
            {
                string[] args = Environment.GetCommandLineArgs();
                string filePath = args[1];
                Console.WriteLine(filePath);
                string code = File.ReadAllText(filePath);

                try
                {
                    Run(code);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.ReadKey();
                }

                Console.WriteLine("Press any key to exit ");
                Console.ReadKey();
            }
        }

        private static void Run(string code)
        {
            Lexer lexer = new Lexer(code);

            List<Token> tokens = lexer.Tokenize();
            if(debugMode)
            {
                foreach (Token token in tokens)
                    Console.WriteLine($"TOKEN: {token.getType()}, VALUE: {token.value}");
            }

            Statement program = new Parser(tokens).Parse();

            program.Accept(new FunctionAdder());
            program.Execute();
            
        }
    }
}