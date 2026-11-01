using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задания.Common;

namespace Задания.Tasks.Level_2
{
    public class Task18_TryParse_vs_try_catch : ITask
    {
        public string Title => "сравнить два способа обработки некорректного ввода числа.";
        public string Description => "Cравнить производительность конкатенации через + и StringBuilder.";

        public string[] Requirements => new[]
        {
            "Способ 1: int.TryParse — вернуть bool + значение через out.",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException.",
            "Оба оформить отдельными методами.",
            "Продемонстрировать на корректном и некорректном вводе."
        };
        public void Run()
        { 
            string[] testInputs = { "123", "abc", "  45  ", "999999999999", "", "3.14" };

            Console.WriteLine("Сравнение способов обработки ввода числа:\n");

            foreach (string input in testInputs)
            { 
                Console.WriteLine($"--- Ввод: \"{input}\" ---");

                
                bool success1 = TryParseMethod(input, out int result1);
                Console.WriteLine($"TryParse: {(success1 ? $"OK, число = {result1}" : "Ошибка: не число")}");

                
                bool success2 = ParseMethod(input, out int result2);
                Console.WriteLine($"Parse+try/catch: {(success2 ? $"OK, число = {result2}" : "Ошибка: перехвачено исключение")}");

                Console.WriteLine();
            }
        }

        
        static bool TryParseMethod(string input, out int value)
        {
            
            return int.TryParse(input, out value);
        }

       
        static bool ParseMethod(string input, out int value)
        {
            try
            {
                value = int.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                
                value = 0; 
                return false;
            }
            catch (OverflowException)
            {
                
                value = 0;
                return false;
            }
            catch (ArgumentNullException)
            {
                
                value = 0;
                return false;
            }
            
        }
    }
}
