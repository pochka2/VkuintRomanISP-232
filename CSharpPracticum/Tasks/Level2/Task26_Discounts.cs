using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 26. Стратегия скидок.</summary>
public class Task26_Discounts : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Стратегия скидок";
    /// <summary>Описание задания.</summary>
    public string Description => "Рассчитать цену с разными скидками.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IDiscountStrategy.Apply(decimal)",
        "Нет скидки, VIP 10%, промо 20%",
        "PriceCalculator принимает стратегию",
    };
    /// <summary>Подсказка.</summary>
    public string Hint => "Калькулятор должен работать с любым видом скидки.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        decimal price = 1000m;
        foreach (IDiscountStrategy strategy in new IDiscountStrategy[]
        {
            new NoDiscount(), new VipDiscount(), new PromoDiscount()
        })
        {
            PriceCalculator calculator = new PriceCalculator(strategy);
            Console.WriteLine($"{strategy.GetType().Name}: {calculator.Calculate(price)}");
        }
    }

    private interface IDiscountStrategy
    {
        decimal Apply(decimal price);
    }
    private class NoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price;
    }
    private class VipDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.9m;
    }
    private class PromoDiscount : IDiscountStrategy
    {
        public decimal Apply(decimal price) => price * 0.8m;
    }
    private class PriceCalculator
    {
        private readonly IDiscountStrategy strategy;
        public PriceCalculator(IDiscountStrategy strategy) { this.strategy = strategy; }
        public decimal Calculate(decimal price) => strategy.Apply(price);
    }
}
