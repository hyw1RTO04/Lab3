using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TextTokenizerApp
{
    [XmlRoot("Text")]
    public class Text
    {
        [XmlArray("Sentences")]
        [XmlArrayItem("Sentence")]
        private readonly List<Sentence> _sentences = new();

        [XmlIgnore]
        public IReadOnlyList<Sentence> Sentences => _sentences;

        public void AddSentence(Sentence sentence) => _sentences.Add(sentence);

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var s in _sentences)
                sb.AppendLine(s.ToString());
            return sb.ToString();
        }
    }
}
