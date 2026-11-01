using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задания.Common;

namespace Задания.Tasks.Level1
{


    public class Task01_HelloWorld : ITask
    {
        public string Title => "Hello, World + текущая дата";

        public string Description => "Вывести приветствие и текущую дату.";

        public string[] Requirements => new[]
        {
            "Вывести 'Hello, World!'",
            "Вывести текущую дату и время"
        };

        public void Run()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine($"Текущая дата и время: {DateTime.Now}");
        }
    }

}