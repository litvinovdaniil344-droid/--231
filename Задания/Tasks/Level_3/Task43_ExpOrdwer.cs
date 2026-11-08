using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задания.Common;

namespace Задания.Tasks.Level_3
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }
    public class Task43_ExpOrdwer : ITask
    {
        public string Title => "Множественные типы исключений, порядок catch";
        public string Description => "Продемонстрировать порядок обработки исключений.";

        public string[] Requirements => new[]
        {
            "Метод, который может бросить FormatException, DivideByZeroException или свой CustomException.",
            "Несколько catch-блоков в правильном порядке (от частного к общему).",
            "Продемонстрировать все три сценария.",
            "В конце — finally с выводом «завершено».",
            "Объяснить в комментарии, почему порядок catch важен."
        };

        public void Run()
        {
            Console.WriteLine("--- Сценарий 1: FormatException ---");
            TestScenario("abc");

            Console.WriteLine("\n--- Сценарий 2: DivideByZeroException ---");
            TestScenario("10_0");

            Console.WriteLine("\n--- Сценарий 3: CustomException ---");
            TestScenario("custom");

            Console.WriteLine("\n--- Сценарий 4: Без ошибок ---");
            TestScenario("42");
        }

        private void TestScenario(string input)
        {
            try
            {
                ProcessInput(input);
                Console.WriteLine("Успешно обработано!");
            }

            catch (CustomException ex)
            {
                Console.WriteLine($"Поймано CustomException: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Поймано FormatException: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Поймано DivideByZeroException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Поймано какое-то другое исключение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("  [finally]: завершено.");
            }
        }

        private void ProcessInput(string input)
        {
            if (input == "custom")
            {
                throw new CustomException("Сработало кастомное исключение!");
            }

            if (input == "10_0")
            {
                int zero = 0;
                int result = 10 / zero;
            }

            int number = int.Parse(input);
            Console.WriteLine($"  Число успешно распарсено: {number}");
        }
    }
}
