using System.Collections.Generic;
using System.Text;

namespace TextTokenizerApp
{
    
    public class Text
    {
        private readonly List<Sentence> _sentences = new();

        public IReadOnlyList<Sentence> Sentences => _sentences;

        public void AddSentence(Sentence sentence)
        {
            _sentences.Add(sentence);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var s in _sentences)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }
    }
}
