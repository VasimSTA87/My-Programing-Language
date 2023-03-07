using ELanguage.Parser;
using ELangugage;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ELanguage.Libs
{
    internal class UseForms
    {
        public static Form window;

        public static void AddLib(Dictionary<string, Function> functions)
        {
            functions.Add("newWindow", new NewWindow());
            functions.Add("update", new Update());
        }

        public class NewWindow : Function
        {
            public Value Execute(params Value[] args)
            {
                string title = "New Window";
                int width = 240;
                int heigth = 120;

                switch (args.Length)
                {
                    case 1:
                        title = args[0].AsString();
                        break;
                    case 2:
                        width = (int)args[0].AsDouble();
                        heigth = (int)args[1].AsDouble();
                        break;
                    case 3:
                        title = args[0].AsString();
                        width = (int)args[1].AsDouble();
                        heigth = (int)args[2].AsDouble();
                        break;
                }
                window = new Form()
                {
                    Text = title,
                    Width = width,
                    Height = heigth
                };

                window.ShowDialog();

                return new NumberValue(0);
            }
        }

        public class Update : Function
        {
            public Value Execute(params Value[] args)
            {
                window.Update();

                return new NumberValue(0);
            }
        }
    }
}