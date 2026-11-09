using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 30. Банковский счёт.</summary>
public class Task30_BankAccount : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Банковский счёт";
    /// <summary>Описание задания.</summary>
    public string Description => "Положить и снять деньги с обработкой ошибки.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Приватный баланс",
        "Deposit и Withdraw",
        "Собственное InsufficientFundsException",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Деньги не уходят в минус, ошибка обрабатывается.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Перед снятием проверь баланс.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        BankAccount account = new BankAccount();
        account.Deposit(500m);
        account.Withdraw(200m);
        Console.WriteLine("Баланс: " + account.Balance);
        try { account.Withdraw(1000m); }
        catch (InsufficientFundsException ex) { Console.WriteLine(ex.Message); }
        Console.WriteLine("Баланс после ошибки: " + account.Balance);
    }

    private class InsufficientFundsException : Exception
    {
        /// <summary>Создаёт ошибку.</summary>
        public InsufficientFundsException(string message) : base(message) { }
    }

    private class BankAccount
    {
        private decimal balance;
        /// <summary>Остаток на счёте.</summary>
        public decimal Balance => balance;
        /// <summary>Пополняет счёт.</summary>
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            balance += amount;
        }
        /// <summary>Снимает деньги.</summary>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (amount > balance) throw new InsufficientFundsException("Недостаточно денег.");
            balance -= amount;
        }
    }
}
