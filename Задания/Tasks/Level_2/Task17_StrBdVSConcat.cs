using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задания.Common;

namespace Задания.Tasks.Level_2
{
    public class Task17_StrBdVSConcat : ITask
    {
        public string Title => "StringBuilder vs конкатенация (замер)";
        public string Description => "Cравнить производительность конкатенации через + и StringBuilder.";

        public string[] Requirements => new[]
        {
            "Собрать строку из 10 000 (или 100 000) чисел двумя способами.",
            "Замерить время каждого через Stopwatch.",
            "Вывести оба времени и разницу.",
            "Объяснить в комментарии, почему StringBuilder быстрее."
        };
        public void Run()
        {
            const int count = 10_000;

            Console.WriteLine($"Сравнение сборки строки из {count} чисел...\n");


            Stopwatch swPlus = Stopwatch.StartNew();

            string resultPlus = "";
            for (int i = 0; i < count; i++)
            {
                resultPlus += i.ToString() + ",";
            }

            swPlus.Stop();


            Stopwatch swBuilder = Stopwatch.StartNew();


            StringBuilder sb = new StringBuilder(count * 6);
            for (int i = 0; i < count; i++)
            {
                sb.Append(i);
                sb.Append(',');
            }
            string resultBuilder = sb.ToString();

            swBuilder.Stop();


            bool isEqual = resultPlus == resultBuilder;

            Console.WriteLine($"Метод '+':          {swPlus.ElapsedMilliseconds} мс");
            Console.WriteLine($"StringBuilder:      {swBuilder.ElapsedMilliseconds} мс");
            double diff = swPlus.Elapsed.TotalMilliseconds - swBuilder.Elapsed.TotalMilliseconds;

            
            double ratio = swPlus.Elapsed.TotalMilliseconds / Math.Max(swBuilder.Elapsed.TotalMilliseconds, 0.001);

            Console.WriteLine($"Разница:            {diff:F2} мс (метод '+' медленнее в {ratio:F1} раз)");
            Console.WriteLine($"\nРезультаты равны:   {(isEqual ? "Да" : "Нет")}");

            // ==========================================================
            // ПОЧЕМУ STRINGBUILDER БЫСТРЕЕ? (Объяснение в комментарии)
            // ==========================================================
            /*
             * 1. ИММУТАБЕЛЬНОСТЬ (НЕИЗМЕНЯЕМОСТЬ) STRING
             * В C# тип string неизменяем. Когда мы пишем resultPlus += ..., 
             * мы не дописываем символы в конец старой строки. 
             * Мы каждый раз создаем НОВУЮ строку в памяти, копируем туда 
             * старую целиком и добавляем новую часть. 
             * 
             * 2. КВАДРАТИЧНАЯ СЛОЖНОСТЬ O(N^2)
             * На шаге 1 копируется 1 символ. На шаге 5000 копируется уже ~25 000 символов.
             * На шаге 10 000 копируется ~60 000 символов.
             * Итого за цикл происходит копирование сотен мегабайт данных.
             * StringBuilder же использует внутри изменяемый массив (буфер) и просто 
             * дописывает символы в конец. Сложность — линейная O(N).
             * 
             * 3. СБОРЩИК МУСОРА (GC)
             * Конкатенация через '+' создает 10 000 промежуточных строк. 
             * Все они становятся мусором и нагружают GC (Garbage Collector), 
             * вызывая микро-паузы в работе программы.
             * StringBuilder создает в памяти всего один массив и одну финальную строку.
             * 
             * 4. РАСШИРЕНИЕ БУФЕРА
             * Когда внутренний массив StringBuilder переполняется, он увеличивает 
             * свою ёмкость в 2 раза (capacity doubling). Это происходит редко и 
             * не требует копирования всех данных на каждом шаге. А если задать ёмкость 
             * заранее (как мы сделали: new StringBuilder(count * 6)), расширений вообще не будет.
             */
        }
    }
}
