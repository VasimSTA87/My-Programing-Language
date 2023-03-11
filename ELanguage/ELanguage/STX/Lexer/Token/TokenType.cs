namespace ELangugage
{
    internal enum TokenType
    {
        Number,
        Word,
        String,

        Print,
        Println,
        If,
        Else,
        While,
        For,
        Do,
        Return,
        Break,
        Continue,
        Func,
        Readln,
        Use,
        Import,

        Increment,
        Decrement,

        Plus,
        Minus,
        Star,
        Slash,
        Equals,
        EqualsEquals,
        Excl,
        ExclEquals,
        LT,
        LTEquals,
        GT,
        GTEquals,

        Lbrace,
        Rbrace,
        
        Lbracket,
        Rbracket,

        LParen,
        RParen,

        Bar,
        BarBar,
        Amp,
        AmpAmp,

        Semicolon,
        Comma,

        EOF
    }
}