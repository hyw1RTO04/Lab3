namespace TextTokenizerApp
{
    public class Punctuation : Token
    {
        public Punctuation(string value) : base(Validate(value)) { }

        private static string Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("«начение знака препинани€ не может быть пустым.", nameof(value));
            return value;
        }
    }
}
