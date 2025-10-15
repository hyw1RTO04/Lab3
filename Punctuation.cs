using System;
using System.Xml.Serialization;

namespace TextTokenizerApp
{
    public class Punctuation : Token
    {
        public Punctuation() : base() { } // пустой конструктор для XML

        public Punctuation(string value) : base(Validate(value)) { }

        private static string Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Значение знака препинания не может быть пустым.", nameof(value));
            return value;
        }
    }
}
