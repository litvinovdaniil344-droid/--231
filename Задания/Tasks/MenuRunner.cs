using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Задание.Tasks.Level1;
using Задания.Common;
using Задания.Tasks.Level_2;
using Задания.Tasks.Level_3;
using Задания.Tasks.Level1;
using Задания.Tasks.Level2;

namespace Задания.Menu
{
    public class MenuRunner
    {
        private List<ITask> level1Tasks = new List<ITask>();
        private List<ITask> level2Tasks = new List<ITask>();
        private List<ITask> level3Tasks = new List<ITask>();
        public MenuRunner()
        {
            level1Tasks.Add(new Task01_HelloWorld());
            level1Tasks.Add(new Task02_PrimitivesMethod());
            level1Tasks.Add(new Task03_Calculator());
            level1Tasks.Add(new Task04_Parity());
            level1Tasks.Add(new Task05_Multiplication());
            level1Tasks.Add(new Task06_SDN());
            level1Tasks.Add(new Task07_Reverse());
            level1Tasks.Add(new Task08_Fizz());
            level1Tasks.Add(new Task09_Array());
            level1Tasks.Add(new Task10_BubIns());
            level1Tasks.Add(new Task11_MatrixDiagonal());
            level1Tasks.Add(new Task12_Palindrome());
            level1Tasks.Add(new Task13_Dictionary());
            level1Tasks.Add(new Task14_AgeCalculator());
            level2Tasks.Add(new Task16__StringExtensions());
            level2Tasks.Add(new Task17_StrBdVSConcat());
            level2Tasks.Add(new Task18_TryParse_vs_try_catch());
            level2Tasks.Add(new Task19_MyCollections());
            level2Tasks.Add(new Task20_Generalizations());
            level2Tasks.Add(new Task34_GroupText());
            level2Tasks.Add(new Task22_paramsMethod());
            level2Tasks.Add(new Task23_Nullable());
            level2Tasks.Add(new Task24_Animals());
            level2Tasks.Add(new Task25_Interface());
            level2Tasks.Add(new Task26_Pattern());
            level2Tasks.Add(new Task27_Comparer());
            level2Tasks.Add(new Task28_Equals());
            level2Tasks.Add(new Task29_Fabric());
            level2Tasks.Add(new Task30_Bank());
            level2Tasks.Add(new Task31_Disposible());
            level2Tasks.Add(new Task32_Validation());
            level2Tasks.Add(new Task33_LINQ());
            level2Tasks.Add(new Task34_GroupText());
            level3Tasks.Add(new Task36_Dubl());
            level3Tasks.Add(new Task37_Fibonachi());
            level3Tasks.Add(new Task38_ListVsLList());
            level3Tasks.Add(new Task39_numbersi());
            level3Tasks.Add(new Task40_Async());
            level3Tasks.Add(new Task41_ParTask());
            level3Tasks.Add(new Task42_Cancelation());
            level3Tasks.Add(new Task43_ExpOrdwer());
            level3Tasks.Add(new Task44_TodoL());
            level3Tasks.Add(new Task45_Library());

        }
        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый");
                Console.WriteLine("2. Уровень 2 — Средний");
                Console.WriteLine("3. Уровень 3 — Продвинутый");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите уровень: ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Level1Menu();
                } if (choice == "2")
                {
                    Level2Menu();
                } if (choice == "3") 
                {
                    Level3Menu();
                }
                else if (choice == "0" || choice == "q")
                {
                    isRunning = false;
                }
            }
        }
        private void Level1Menu()
        {
            bool inLevel1 = true;
            while (inLevel1)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 1 ---");
                for (int i = 0; i < level1Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {level1Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    inLevel1 = false;
                }
                else
                {
                    int index = int.Parse(choice) - 1;

                    if (index >= 0 && index < level1Tasks.Count)
                    {
                        Console.Clear();
                        ConsoleHelper.PrintTaskInfo(level1Tasks[index]);
                        level1Tasks[index].Run();
                        ConsoleHelper.Pause();
                    }
                }
            }
            
            
        }
        private void Level2Menu() 
        {  
            bool inLevel2 = true;
            while (inLevel2)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 2 ---");
                for (int i = 0; i < level2Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {level2Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    inLevel2 = false;
                }
                else
                {
                    int index = int.Parse(choice) - 1;

                    if (index >= 0 && index < level2Tasks.Count)
                    {
                        Console.Clear();
                        ConsoleHelper.PrintTaskInfo(level2Tasks[index]);
                        level2Tasks[index].Run();
                        ConsoleHelper.Pause();
                    }
                }
            }

        }
        private void Level3Menu()
        {
            bool inLevel3 = true;
            while (inLevel3)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 3 ---");
                for (int i = 0; i < level3Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {level3Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    inLevel3 = false;
                }
                else
                {
                    int index = int.Parse(choice) - 1;

                    if (index >= 0 && index < level3Tasks.Count)
                    {
                        Console.Clear();
                        ConsoleHelper.PrintTaskInfo(level3Tasks[index]);
                        level3Tasks[index].Run();
                        ConsoleHelper.Pause();
                    }
                }
            }

        }
    }
}
