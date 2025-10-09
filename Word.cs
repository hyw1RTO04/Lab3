using System;

namespace TextTokenizerApp
{
    public class Word : Token
    {
        public Word(string value) : base(value) { }

        public int Length => Value.Length;

        
        public bool StartsWithConsonant()
        {
            const string consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";
            return !string.IsNullOrEmpty(Value) &&
                   consonants.Contains(char.ToLower(Value[0]));
        }
    }
}
