using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 28. Равенство точек.</summary>
public class Task28_Points : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Равенство точек";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить Equals, GetHashCode и HashSet.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IEquatable<Point>",
        "Equals(object) и GetHashCode",
        "Дубликаты не увеличивают HashSet",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Для одинаковых x и y должен получаться одинаковый хеш.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        Point a = new Point(2, 3);
        Point b = new Point(2, 3);
        Point c = new Point(5, 7);
        Console.WriteLine("Равны: " + a.Equals(b));
        HashSet<Point> points = new HashSet<Point> { a, b, c };
        Console.WriteLine("Уникальных точек: " + points.Count);
    }

    private class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) { X = x; Y = y; }
        public bool Equals(Point other) => other != null && X == other.X && Y == other.Y;
        public override bool Equals(object obj) => Equals(obj as Point);
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }
}
