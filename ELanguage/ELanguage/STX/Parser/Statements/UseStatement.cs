using ELanguage.Libs;
using ELangugage;
using System;

namespace ELanguage
{
    internal class UseStatement : Statement
    {
        public string path;

        public UseStatement(string path)
        {
            this.path = path;
        }

        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
        
        public void Execute()
        {
            switch (path)
            {
                case "std":
                    new UseStd().Init();
                    break;
                case "math":
                    new UseMath().Init();
                    break;
                case "sysio":
                    new Sysio().Init();
                    break;
                case "time":
                    new Time().Init();
                    break;
                case "json":
                    new JsonUtil().Init();
                    break;
                case "converter":
                    new DataConverter().Init();
                    break;
                case "forms":
                    new UseForms().Init();
                    break;
                case "encoding":
                    new Encoding().Init();
                    break;
            }
        }
    }
}
