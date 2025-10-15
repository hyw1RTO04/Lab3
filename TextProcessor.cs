using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TextTokenizerApp
{
    public static class TextProcessor
    {
        // 1. Сортировка по количеству слов
        public static IEnumerable<Sentence> GetSentencesByWordCount(Text text)
        {
            var list = new List<Sentence>(text.Sentences);
            list.Sort((a, b) => a.WordCount.CompareTo(b.WordCount));
            return list;
        }

        // 2. Сортировка по длине
        public static IEnumerable<Sentence> GetSentencesByLength(Text text)
        {
            var list = new List<Sentence>(text.Sentences);
            list.Sort((a, b) => a.Length.CompareTo(b.Length));
            return list;
        }

        // 3. Поиск слов заданной длины в вопросительных предложениях
        public static IEnumerable<string> FindWordsInQuestions(Text text, int length)
        {
            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var sentence in text.Sentences)
            {
                if (sentence.IsQuestion)
                {
                    foreach (var token in sentence.Tokens)
                    {
                        if (token is Word word && word.Length == length)
                            result.Add(word.Value.ToLower());
                    }
                }
            }
            return result;
        }

        // 4. Удаление слов заданной длины, начинающихся с согласной
        public static void RemoveWordsByLengthAndConsonant(Text text, int length)
        {
            foreach (var sentence in text.Sentences)
            {
                var tokens = sentence.Tokens as List<Token>;
                if (tokens == null) continue;

                for (int i = tokens.Count - 1; i >= 0; i--)
                {
                    if (tokens[i] is Word word &&
                        word.Length == length &&
                        word.StartsWithConsonant())
                    {
                        tokens.RemoveAt(i);
                    }
                }
            }
        }

        // 5. Замена слов заданной длины в предложении
        public static void ReplaceWordsInSentence(Text text, int sentenceIndex, int wordLength, string replacement)
        {
            if (sentenceIndex < 0 || sentenceIndex >= text.Sentences.Count)
                throw new ArgumentOutOfRangeException(nameof(sentenceIndex));

            var sentence = text.Sentences[sentenceIndex];
            var tokens = sentence.Tokens as List<Token>;
            if (tokens == null) return;

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] is Word word && word.Length == wordLength)
                {
                    tokens[i] = new Word(replacement);
                }
            }
        }

        // 6. Удаление стоп-слов
        public static void RemoveStopWords(Text text, HashSet<string> stopWords)
        {
            foreach (var sentence in text.Sentences)
            {
                var tokens = sentence.Tokens as List<Token>;
                if (tokens == null) continue;

                for (int i = tokens.Count - 1; i >= 0; i--)
                {
                    if (tokens[i] is Word word &&
                        stopWords.Contains(word.Value.ToLower()))
                    {
                        tokens.RemoveAt(i);
                    }
                }
            }
        }

        // 6.1 Загрузка стоп-слов из файла
        public static HashSet<string> LoadStopWords(string filePath)
        {
            var stopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл со стоп-словами не найден", filePath);

            foreach (var line in File.ReadLines(filePath))
            {
                var word = line.Trim().ToLower();
                if (!string.IsNullOrEmpty(word))
                    stopWords.Add(word);
            }

            return stopWords;
        }

        // 6.2 Объединение нескольких списков стоп-слов
        public static HashSet<string> MergeStopWordSets(params HashSet<string>[] sets)
        {
            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var set in sets)
            {
                foreach (var word in set)
                    result.Add(word);
            }
            return result;
        }
    }
}
