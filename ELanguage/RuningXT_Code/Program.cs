using System;
using System.Diagnostics;

namespace RuningXT_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Environment.GetCommandLineArgs()[2];

            string compilerPath = "C:\\Users\\User\\source\\repos\\ELanguage\\ELanguage\\bin\\Debug\\ELanguage.exe";
            Process.Start(compilerPath, file);
            
            Console.WriteLine(3);
            Console.ReadKey();
        }
    }
}
