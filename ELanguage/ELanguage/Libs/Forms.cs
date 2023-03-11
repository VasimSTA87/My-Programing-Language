using ELanguage.Parser;
using ELangugage;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ELanguage.Libs
{
    internal class UseForms : ILib
    { 
        public static Form window;

        public void Init()
        {
            Functions.Set("window", new NewWindow());
            Functions.Set("button", new NewButton());
        }

        private class NewWindow : Function
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

        private class NewButton : Function
        {
            public Value Execute(params Value[] args)
            {
                Button btn = new Button();

                switch (args.Length)
                {
                    case 1:
                        btn.Text = args[0].AsString();
                        btn.Size = new Size(50, 25);
                        btn.Top = 0;
                        btn.Left = 0;
                        break;
                    case 3:
                        btn.Size = new Size((int)args[1].AsDouble(), (int)args[2].AsDouble());
                        break;
                }

                window.Controls.Add(btn);
                return new NumberValue(0);
            }
        }
    }
}