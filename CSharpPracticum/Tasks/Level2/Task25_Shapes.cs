using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 25. Фигуры и сортировка.</summary>
public class Task25_Shapes : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Фигуры и сортировка";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти площадь фигур и отсортировать.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IShape: Area и Perimeter",
        "Circle, Rectangle, Triangle",
        "Пять фигур, сортировка по площади",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Фигуры отсортированы по площади.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для треугольника можно применить формулу Герона.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(2), new Rectangle(2, 3), new Triangle(3, 4, 5),
            new Circle(1), new Rectangle(5, 2)
        };
        Console.WriteLine("До сортировки:");
        Print(shapes);
        shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));
        Console.WriteLine("После сортировки:");
        Print(shapes);
    }

    private static void Print(List<IShape> shapes)
    {
        foreach (IShape shape in shapes)
            Console.WriteLine($"{shape.GetType().Name}: площадь {shape.Area():F2}, периметр {shape.Perimeter():F2}");
    }

    private interface IShape
    {
        /// <summary>Площадь фигуры.</summary>
        double Area();
        /// <summary>Периметр фигуры.</summary>
        double Perimeter();
    }

    private class Circle : IShape
    {
        private readonly double radius;
        /// <summary>Создаёт круг.</summary>
        public Circle(double radius) { this.radius = radius; }
        /// <summary>Считает площадь.</summary>
        public double Area() => Math.PI * radius * radius;
        /// <summary>Считает периметр.</summary>
        public double Perimeter() => 2 * Math.PI * radius;
    }

    private class Rectangle : IShape
    {
        private readonly double width, height;
        /// <summary>Создаёт прямоугольник.</summary>
        public Rectangle(double width, double height) { this.width = width; this.height = height; }
        /// <summary>Считает площадь.</summary>
        public double Area() => width * height;
        /// <summary>Считает периметр.</summary>
        public double Perimeter() => 2 * (width + height);
    }

    private class Triangle : IShape
    {
        private readonly double a, b, c;
        /// <summary>Создаёт треугольник.</summary>
        public Triangle(double a, double b, double c) { this.a = a; this.b = b; this.c = c; }
        /// <summary>Считает периметр.</summary>
        public double Perimeter() => a + b + c;
        /// <summary>Считает площадь.</summary>
        public double Area()
        {
            double s = Perimeter() / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }
}
