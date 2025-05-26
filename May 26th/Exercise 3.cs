using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Transaction
{
    public DateTime Timestamp { get; set; }
    public string Type { get; } // "Deposit" or "Withdrawal"
    public decimal Amount { get; }
    public decimal Balance { get; }

    public Transaction(string type, decimal amount, decimal balance)
    {
        Timestamp = DateTime.Now;
        Type = type;
        Amount = amount;
        Balance = balance;
    }

    public override string ToString()
    {
        return $"{Timestamp:yyyy-MM-dd HH:mm:ss} | {Type,-10} | {Amount,10:C} | {Balance,10:C}";
    }

    public string ToFileString()
    {
        return $"{Timestamp:yyyy-MM-dd HH:mm:ss}|{Type}|{Amount}|{Balance}";
    }

    public static Transaction FromFileString(string line)
    {
        var parts = line.Split('|');
        return new Transaction(
            parts[1],
            decimal.Parse(parts[2]),
            decimal.Parse(parts[3]))
        {
            Timestamp = DateTime.Parse(parts[0])
        };
    }
}

public class BankAccount
{
    private decimal _balance;
    private readonly List<Transaction> _transactions = new List<Transaction>();
    private const string TransactionFile = "transactions.txt";

    public string AccountNumber { get; }
    public string Owner { get; }
    public decimal Balance => _balance;
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public BankAccount(string accountNumber, string owner, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        _balance = initialBalance;

        if (initialBalance > 0)
        {
            _transactions.Add(new Transaction("Initial", initialBalance, _balance));
        }

        LoadTransactionHistory();
        PrintSummary();
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive");
        }

        _balance += amount;
        _transactions.Add(new Transaction("Deposit", amount, _balance));
        SaveTransaction(_transactions.Last());
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive");
        }

        if (_balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        _balance -= amount;
        _transactions.Add(new Transaction("Withdrawal", amount, _balance));
        SaveTransaction(_transactions.Last());
    }

    private void SaveTransaction(Transaction transaction)
    {
        try
        {
            File.AppendAllText(TransactionFile, transaction.ToFileString() + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving transaction: {ex.Message}");
        }
    }

    private void LoadTransactionHistory()
    {
        if (!File.Exists(TransactionFile))
        {
            return;
        }

        try
        {
            var lines = File.ReadAllLines(TransactionFile);
            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    _transactions.Add(Transaction.FromFileString(line));
                }
            }

            if (_transactions.Any())
            {
                _balance = _transactions.Last().Balance;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading transaction history: {ex.Message}");
        }
    }

    public void PrintSummary()
    {
        Console.WriteLine($"Account Summary for {Owner} ({AccountNumber})");
        Console.WriteLine($"Current Balance: {Balance:C}");
        Console.WriteLine($"Transaction Count: {Transactions.Count}");

        if (Transactions.Count > 0)
        {
            Console.WriteLine("\nLast 5 Transactions:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Date                | Type      | Amount     | Balance");
            Console.WriteLine("--------------------------------------------------");

            foreach (var transaction in Transactions.TakeLast(5))
            {
                Console.WriteLine(transaction);
            }
        }
    }

    public void PrintFullTransactionHistory()
    {
        Console.WriteLine($"\nComplete Transaction History for {Owner} ({AccountNumber})");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Date                | Type      | Amount     | Balance");
        Console.WriteLine("--------------------------------------------------");

        foreach (var transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var account = new BankAccount("123456789", "John Doe", 1000);

        // Example transactions
        account.Deposit(500);
        account.Withdraw(200);
        account.Deposit(1000);
        account.Withdraw(300);

        // Display full history
        account.PrintFullTransactionHistory();
    }
}