using System;
using System.Xml.Serialization;

namespace TextTokenizerApp
{
    public class Word : Token
    {
        public Word() : base() { }

        public Word(string value) : base(value) { }

        [XmlIgnore]
        public int Length => Value.Length;

        public bool StartsWithConsonant()
        {
            const string consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";
            return !string.IsNullOrEmpty(Value) &&
                   consonants.Contains(char.ToLower(Value[0]));
        }
    }
}
