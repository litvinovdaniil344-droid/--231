using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задания.Common;

namespace Задания.Tasks.Level_2
{
    public class Task16__StringExtensions : ITask
    {
        public string Title => "StringExtension";
        public string Description => "Написать extension-методы для string.";

        public string[] Requirements => new[]
        {
            "Реализовать в статическом классе StringExtensions.",
            "Методы: IsPalindrome(), WordCount(), ReverseString().",
            "Методы должны быть public static с this string первым параметром.",
            "Продемонстрировать вызов на 2–3 строках."
        };
        public void Run() 
        {
            string s1 = "А роза упала на лапу Азора";
            string s2 = "Hello world, this is C#!";
            string s3 = "abc";

            Console.WriteLine($"{s1} -> IsPalindrome: {s1.IsPalindrome()}");
            Console.WriteLine($"WordCount(\"{s2}\") = {s2.WordCount()}");
            Console.WriteLine($"Reverse(\"{s3}\") = {s3.ReverseString()}");
        }
    }
    public static class StringExtension
    {
        public  static bool IsPalindrome(this string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return true;
            }
            var cleaned = new string(str
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLowerInvariant)
                .ToArray());

            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            return str.Split(
                new[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries
            ).Length;
        }
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            var sb = new StringBuilder(str.Length);
            for (int i = str.Length - 1; i >= 0; i--)
                sb.Append(str[i]);
            return sb.ToString();
        }

    }
}
