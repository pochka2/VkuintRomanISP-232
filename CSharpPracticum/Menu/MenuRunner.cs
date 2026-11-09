using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level1;
using CSharpPracticum.Tasks.Level2;

namespace CSharpPracticum.Menu;

/// <summary>Главное меню практикума.</summary>
public static class MenuRunner
{
    /// <summary>Запускает программу.</summary>
    public static void Start()
    {
        var first = new SortedDictionary<int, ITask>
        {
            [1] = new Task01_HelloWorld(),
            [2] = new Task02_Primitives(),
            [3] = new Task03_Calculator(),
            [4] = new Task04_Parity(),
            [5] = new Task05_Multiplication(),
            [6] = new Task06_DigitSum(),
            [7] = new Task07_Reverse(),
            [8] = new Task08_FizzBuzz(),
            [9] = new Task09_ArrayStats(),
            [10] = new Task10_Sorting(),
            [11] = new Task11_Matrix(),
            [12] = new Task12_Palindrome(),
            [13] = new Task13_WordCounter(),
            [14] = new Task14_Age(),
            [15] = new Task15_GitBasics()
        };
        var second = new SortedDictionary<int, ITask>
        {
            [16] = new Task16_StringMethods(),
            [17] = new Task17_StringBuilder(),
            [18] = new Task18_Parsing(),
            [19] = new Task19_StackQueue(),
            [20] = new Task20_Generics(),
            [21] = new Task21_WeekDays(),
            [22] = new Task22_Params(),
            [23] = new Task23_Nullable(),
            [24] = new Task24_Animals(),
            [25] = new Task25_Shapes(),
            [26] = new Task26_Discounts(),
            [27] = new Task27_Students(),
            [28] = new Task28_Points(),
            [29] = new Task29_Notifications(),
            [30] = new Task30_BankAccount(),
            [31] = new Task31_FileWriter(),
            [32] = new Task32_Temperature(),
            [33] = new Task33_Employees(),
            [34] = new Task34_WordGroups(),
            [35] = new Task35_GitAdvanced()
        };
        while (true)
        {
            Console.WriteLine("\n=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите уровень: ");
            string input = Console.ReadLine()?.Trim().ToLower();
            if (input == "4" || input == "0" || input == "q")
                return;
            if (input == "1") LevelMenu.Show(1, first);
            else if (input == "2") LevelMenu.Show(2, second);
            else if (input == "3") Console.WriteLine("Третий уровень пока не выполнен.");
            else Console.WriteLine("Неверный пункт меню.");
        }
    }
}
