using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextTokenizerApp
{
    
    public class Sentence
    {
        private readonly List<Token> _tokens = new();

        public IReadOnlyList<Token> Tokens => _tokens;

        public void AddToken(Token token)
        {
            _tokens.Add(token);
        }

        public IEnumerable<Word> GetWords() => _tokens.OfType<Word>();

        public IEnumerable<Punctuation> GetPunctuations() => _tokens.OfType<Punctuation>();

        public int WordCount => GetWords().Count();

        public int Length => _tokens.Sum(t => t.Value.Length);

        public bool IsQuestion =>
            _tokens.LastOrDefault() is Punctuation p && p.Value == "?";

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
