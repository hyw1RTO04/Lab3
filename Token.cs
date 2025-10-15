using System;
using System.Xml.Serialization;

namespace TextTokenizerApp
{
    [XmlInclude(typeof(Word))]
    [XmlInclude(typeof(Punctuation))]
    public abstract class Token
    {
        [XmlElement("Value")]
        public string Value { get; protected set; }

        protected Token() { }

        protected Token(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;
    }
}
