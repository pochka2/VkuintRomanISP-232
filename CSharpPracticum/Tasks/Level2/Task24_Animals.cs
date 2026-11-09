using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 24. Животные и наследование.</summary>
public class Task24_Animals : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Животные и наследование";
    /// <summary>Описание задания.</summary>
    public string Description => "Показать полиморфизм животных.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Абстрактный Animal и ToString",
        "Dog, Cat, Bird",
        "List<Animal> и Bird.Fly",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Все животные имеют метод MakeSound, но звуки разные.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog("Бобик"), new Cat("Мурка"), new Bird("Кеша")
        };
        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
            animal.MakeSound();
            if (animal is Bird bird) bird.Fly();
        }
    }

    private abstract class Animal
    {
        public string Name { get; }
        protected Animal(string name) { Name = name; }
        public abstract void MakeSound();
        public override string ToString() => $"{GetType().Name}: {Name}";
    }

    private class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine("Гав!");
    }

    private class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine("Мяу!");
    }

    private class Bird : Animal
    {
        public Bird(string name) : base(name) { }
        public override void MakeSound() => Console.WriteLine("Чирик!");
        public void Fly() => Console.WriteLine("Птица летит.");
    }
}
