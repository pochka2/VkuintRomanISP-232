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
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Каждое животное издаёт свой звук.";
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
        /// <summary>Имя.</summary>
        public string Name { get; }
        protected Animal(string name) { Name = name; }
        /// <summary>Издаёт звук.</summary>
        public abstract void MakeSound();
        /// <summary>Выводит название животного.</summary>
        public override string ToString() => $"{GetType().Name}: {Name}";
    }

    private class Dog : Animal
    {
        /// <summary>Создаёт собаку.</summary>
        public Dog(string name) : base(name) { }
        /// <summary>Издаёт звук.</summary>
        public override void MakeSound() => Console.WriteLine("Гав!");
    }

    private class Cat : Animal
    {
        /// <summary>Создаёт кошку.</summary>
        public Cat(string name) : base(name) { }
        /// <summary>Издаёт звук.</summary>
        public override void MakeSound() => Console.WriteLine("Мяу!");
    }

    private class Bird : Animal
    {
        /// <summary>Создаёт птицу.</summary>
        public Bird(string name) : base(name) { }
        /// <summary>Издаёт звук.</summary>
        public override void MakeSound() => Console.WriteLine("Чирик!");
        /// <summary>Птица летит.</summary>
        public void Fly() => Console.WriteLine("Птица летит.");
    }
}
