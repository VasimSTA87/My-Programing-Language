namespace ELangugage
{
    internal class Token
    {
        public TokenType? type = null;
        public string value;
        public int pos;

        public Token(TokenType type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public Token(TokenType type)
        {
            this.type = type;
            value = "";
        }

        public TokenType? getType()
        {
            return type;
        }

        public string getValue()
        {
            return value;
        }
    }
}