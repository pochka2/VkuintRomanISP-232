
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace ExpenseTracker;

public partial class MainWindow : Window
{
    ObservableCollection<Expense> expenses = new ObservableCollection<Expense>();

    string connectionString = Environment.GetEnvironmentVariable("EXPENSE_TRACKER_CONNECTION") ?? "";

    public MainWindow()
    {
        InitializeComponent();

        ExpensesDataGrid.ItemsSource = expenses;
        ExpenseDatePicker.SelectedDate = DateTime.Today;

        try
        {
            LoadExpenses();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка загрузки: " + ex.Message);
        }
    }

    // Загружаем расходы из базы
    private void LoadExpenses()
    {
        expenses.Clear();

        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string sql = "SELECT Id, Amount, Category, ExpenseDate FROM Expenses";

        using SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Expense expense = new Expense();

            expense.Id = reader.GetInt32(0);
            expense.Amount = reader.GetDecimal(1);
            expense.Category = reader.GetString(2);
            expense.Date = reader.GetDateTime(3);

            expenses.Add(expense);
        }

        UpdateTotal();
    }

    // Добавляем расход
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (!decimal.TryParse(AmountTextBox.Text, out decimal amount) || amount <= 0)
        {
            MessageBox.Show("Введите правильную сумму.");
            return;
        }

        if (ExpenseDatePicker.SelectedDate == null)
        {
            MessageBox.Show("Выберите дату.");
            return;
        }

        ComboBoxItem item = (ComboBoxItem)CategoryComboBox.SelectedItem;
        string category = item.Content.ToString();

        try
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO Expenses (Amount, Category, ExpenseDate) " +
                         "VALUES (@amount, @category, @date)";

            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@date", ExpenseDatePicker.SelectedDate.Value);

            command.ExecuteNonQuery();

            LoadExpenses();
            AmountTextBox.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка добавления: " + ex.Message);
        }
    }

    // Удаляем расход
    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        Expense selected = ExpensesDataGrid.SelectedItem as Expense;

        if (selected == null)
        {
            MessageBox.Show("Выберите расход для удаления.");
            return;
        }

        try
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sql = "DELETE FROM Expenses WHERE Id = @id";

            using SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", selected.Id);

            command.ExecuteNonQuery();

            LoadExpenses();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка удаления: " + ex.Message);
        }
    }

    // Считаем общую сумму
    private void UpdateTotal()
    {
        decimal total = 0;

        foreach (Expense expense in expenses)
        {
            total += expense.Amount;
        }

        TotalTextBlock.Text = $"Всего расходов: {total:0.00} руб.";
    }
}

public class Expense
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
}
