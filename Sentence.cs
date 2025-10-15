using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TextTokenizerApp
{
    public class Sentence
    {
        [XmlArray("Tokens")]
        [XmlArrayItem("Word", typeof(Word))]
        [XmlArrayItem("Punctuation", typeof(Punctuation))]
        private readonly List<Token> _tokens = new();

        [XmlIgnore]
        public IReadOnlyList<Token> Tokens => _tokens;

        public void AddToken(Token token) => _tokens.Add(token);

        public IEnumerable<Word> GetWords() => _tokens.OfType<Word>();
        public IEnumerable<Punctuation> GetPunctuations() => _tokens.OfType<Punctuation>();

        [XmlIgnore]
        public int WordCount => GetWords().Count();

        [XmlIgnore]
        public int Length => _tokens.Sum(t => t.Value.Length);

        [XmlIgnore]
        public bool IsQuestion => _tokens.LastOrDefault() is Punctuation p && p.Value == "?";

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var t in _tokens)
            {
                if (t is Punctuation)
                    sb.Append(t.Value);
                else
                {
                    if (sb.Length > 0)
                        sb.Append(' ');
                    sb.Append(t.Value);
                }
            }
            return sb.ToString().Trim();
        }
    }
}

