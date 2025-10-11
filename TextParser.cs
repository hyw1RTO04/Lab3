using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextTokenizerApp
{
    public static class TextParser
    {
        public static Text Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Исходный текст пуст.");

            var text = new Text();

            var sentencePattern = @"[^.!?;]+[.!?;…]*";
            var sentenceMatches = Regex.Matches(input, sentencePattern, RegexOptions.Multiline);

            foreach (Match s in sentenceMatches)
            {
                var sentence = ParseSentence(s.Value);
                if (sentence.Tokens.Count > 0)
                    text.AddSentence(sentence);
            }

            return text;
        }

        private static Sentence ParseSentence(string sentenceText)
        {
            var sentence = new Sentence();

            
            var tokenPattern = @"\p{L}[\p{L}\p{Pd}]*|[^\p{L}\p{Pd}\s]";
            var tokens = Regex.Matches(sentenceText, tokenPattern, RegexOptions.Multiline);

            foreach (Match token in tokens)
            {
                var value = token.Value;

                
                if (Regex.IsMatch(value, @"\p{L}"))
                    sentence.AddToken(new Word(value));
                else
                    sentence.AddToken(new Punctuation(value));
            }

            return sentence;
        }
    }
}

