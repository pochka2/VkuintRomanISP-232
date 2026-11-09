using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

/// <summary>Задание 29. Фабрика уведомлений.</summary>
public class Task29_Notifications : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Фабрика уведомлений";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать уведомления через фабрику.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "INotification.Send",
        "Email, Sms, Push",
        "NotificationFactory.Create(NotificationType)",
    };
    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Все три вида уведомлений работают.";
    /// <summary>Подсказка.</summary>
    public string Hint => "В фабрике удобно использовать switch.";

    /// <summary>Выполняет задание.</summary>
    public void Run()
    {
        foreach (NotificationType type in Enum.GetValues<NotificationType>())
        {
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Привет!");
        }
    }

    private enum NotificationType { Email, Sms, Push }
    private interface INotification
    {
        /// <summary>Отправляет сообщение.</summary>
        void Send(string message);
    }
    private class EmailNotification : INotification
    {
        /// <summary>Отправляет сообщение.</summary>
        public void Send(string message) => Console.WriteLine("Email: " + message);
    }
    private class SmsNotification : INotification
    {
        /// <summary>Отправляет сообщение.</summary>
        public void Send(string message) => Console.WriteLine("SMS: " + message);
    }
    private class PushNotification : INotification
    {
        /// <summary>Отправляет сообщение.</summary>
        public void Send(string message) => Console.WriteLine("Push: " + message);
    }
    private static class NotificationFactory
    {
        /// <summary>Создаёт уведомление.</summary>
        public static INotification Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentException("Нет такого типа")
            };
        }
    }
}
