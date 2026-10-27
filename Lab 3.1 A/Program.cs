using System;
using System.Linq;

namespace Lab3_Task1
{
    
    class Program
    {
        
        static string GetSubstringAfterColon(string text)
        {
            int colonIndex = text.IndexOf(':');

            // Якщо двоїкрапка відсутня в тексті
            if (colonIndex == -1)
            {
                return "Символ ':' у тексті не знайдено.";
            }

            // Якщо двоїкрапка є останнім символом рядка
            if (colonIndex == text.Length - 1)
            {
                return "Після символу ':' немає інших символів.";
            }

            // Повертаємо підрядок, починаючи з наступного після ':' символу
            return text.Substring(colonIndex + 1);
        }

        // 1(б): Метод підраховує кількість речень, що містять непарну кількість слів
        static int CountSentencesWithOddWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            // Символи, що розділяють речення
            char[] sentenceDelimiters = new char[] { '.', '!', '?' };

            // Розбиваємо текст на окремі речення
            string[] sentences = text.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);

            int oddWordSentenceCount = 0;

            foreach (string sentence in sentences)
            {
                // Символи, що розділяють слова всередині речення
                char[] wordDelimiters = new char[] { ' ', ',', ';', '-', ':', '\t', '\n', '\r' };

                // Отримуємо масив слів поточного речення
                string[] words = sentence.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries);

                // Якщо кількість слів непарна (і слів більше 0)
                if (words.Length > 0 && words.Length % 2 != 0)
                {
                    oddWordSentenceCount++;
                }
            }

            return oddWordSentenceCount;
        }

        
        static void Main(string[] args)
        {
            // Налаштування UTF-8 кодування для коректного відображення кирилиці
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
               
                Console.WriteLine("  ЗАВДАННЯ 1  ");
                
                Console.WriteLine("Введіть текстовий рядок (або введіть 0 для виходу):");
                

                string inputText = Console.ReadLine();

                // Перевірка на вихід при введенні 0
                if (inputText.Trim() == "0")
                {
                    Console.WriteLine("\nЗавершення роботи програми.");
                    break;
                }

                if (string.IsNullOrWhiteSpace(inputText))
                {
                    Console.WriteLine("\nПомилка! Введено порожній рядок. Спробуйте ще раз.");
                    continue;
                }

                // Виконання підпункту (а)
                string resultA = GetSubstringAfterColon(inputText);
                Console.WriteLine("\nа) Символи після першого двоїкрапки (':'):");
                Console.WriteLine($"   {resultA}");

                // Виконання підпункту (б)
                int resultB = CountSentencesWithOddWords(inputText);
                Console.WriteLine("\nб) Кількість речень з непарною кількістю слів:");
                Console.WriteLine($"   {resultB}");
            }
        }
    }
}