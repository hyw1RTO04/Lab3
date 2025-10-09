using System;

namespace TextTokenizerApp
{
    
    public abstract class Token
    {
        public string Value { get; protected set; }

        protected Token(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;
    }
}
