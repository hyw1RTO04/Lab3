namespace TextTokenizerApp
{
    public class Punctuation : Token
    {
        public Punctuation(string value) : base(Validate(value)) { }

        private static string Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("�������� ����� ���������� �� ����� ���� ������.", nameof(value));
            return value;
        }
    }
}
