using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 27. Сортировка студентов.</summary>
public class Task27_Students : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Сортировка студентов";
    /// <summary>Описание задания.</summary>
    public string Description => "Отсортировать студентов по оценке и имени.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IComparable<Student> по убыванию оценки",
        "IComparer<Student> по имени",
        "Обе сортировки List<Student>",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Студенты отсортированы по оценкам и по имени.";
    /// <summary>Подсказка.</summary>
    public string Hint => "В CompareTo можно сравнить AverageGrade в обратном порядке.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        List<Student> students = new List<Student>
        {
            new Student("Петя", 4.2), new Student("Аня", 4.8),
            new Student("Ваня", 3.6), new Student("Борис", 4.5)
        };
        students.Sort();
        Console.WriteLine("По оценке:");
        Print(students);
        students.Sort(new ByNameComparer());
        Console.WriteLine("По имени:");
        Print(students);
    }

    private static void Print(List<Student> students)
    {
        foreach (Student student in students)
            Console.WriteLine($"{student.Name}: {student.AverageGrade}");
    }

    private class Student : IComparable<Student>
    {
        /// <summary>Имя.</summary>
        public string Name { get; }
        /// <summary>Свойство.</summary>
        public double AverageGrade { get; }
        /// <summary>Создаёт студента.</summary>
        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }
        /// <summary>Сравнивает оценки.</summary>
        public int CompareTo(Student other)
        {
            if (other == null) return -1;
            return other.AverageGrade.CompareTo(AverageGrade);
        }
    }

    private class ByNameComparer : IComparer<Student>
    {
        /// <summary>Сравнивает имена.</summary>
        public int Compare(Student a, Student b)
        {
            return string.Compare(a?.Name, b?.Name, StringComparison.CurrentCulture);
        }
    }
}
