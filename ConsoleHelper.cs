using System;
using System.Collections.Generic;

namespace TextTokenizerApp
{
    public static class ConsoleHelper
    {
        // Вывод разделителя
        public static void PrintDivider()
        {
            Console.WriteLine(new string('-', 60));
        }

        // Безопасный ввод строки (не пустой)
        public static string ReadNonEmptyString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        // Безопасный ввод числа
        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int result;
            bool valid;
            do
            {
                Console.Write(prompt);
                valid = int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max;
                if (!valid)
                    Console.WriteLine($"Введите корректное число ({min}–{max}).");
            } while (!valid);

            return result;
        }

        // Вывод коллекции предложений
        public static void PrintSentences(IEnumerable<string> sentences, string header = "Список предложений:")
        {
            Console.WriteLine(header);
            int i = 1;
            foreach (var s in sentences)
            {
                Console.WriteLine($"{i++}. {s}");
            }
        }

        // Печать текста
        public static void PrintText(string text)
        {
            Console.WriteLine("\n=== Исходный текст ===");
            Console.WriteLine(text);
            Console.WriteLine("======================\n");
        }

        // Меню выбора
        public static int ShowMenu(string title, string[] options)
        {
            Console.WriteLine($"\n{title}");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            return ReadInt("Выберите пункт: ", 1, options.Length);
        }

        // Подтверждение действия
        public static bool Confirm(string message)
        {
            Console.Write($"{message} (y/n): ");
            var key = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return char.ToLower(key) == 'y';
        }

        // Сообщение об ошибке
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {message}");
            Console.ResetColor();
        }

        // Информационное сообщение
        public static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
