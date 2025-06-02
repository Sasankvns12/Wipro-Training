using System;
public interface IBankAccount
{
    public void Deposit(double amount);
    public void WithDraw(double amount);
    public void CheckBalance();
    
    
}
class SavingsAccount : IBankAccount
{
    public void Deposit(double amount)
    {
        Console.WriteLine("Deposited[amount] into SavingsAccount");
    }
    public void WithDraw(double amount)
    {
        Console.WriteLine("WithDraw[amount] from SavingsAccount");
    }
    public void CheckBalance()
    {
        Console.WriteLine("Checking Balance in SavingsAccount");
    }
}
class CurrentAccount : IBankAccount
{
    public void Deposit(double amount)
    {
        Console.WriteLine("Deposited[amount] into CurrentAccount");
    }
    public void WithDraw(double amount)
    {
        Console.WriteLine("WithDraw[amount] from CurrentAccount");
    }
    public void CheckBalance()
    {
        Console.WriteLine("Checking Balance in CurrentAccount");
    }
}
class Program
{
    public static void Main()
    {
        IBankAccount SavingsAccount = new SavingsAccount();
        IBankAccount CurrentAccount = new CurrentAccount();
        Console.WriteLine("SavingsAccount Transactions :");
        SavingsAccount.Deposit(1000);
        SavingsAccount.WithDraw(300);
        SavingsAccount.CheckBalance();
        Console.WriteLine("\nCurrentAccount Transactions :");
        CurrentAccount.Deposit(2000);
        CurrentAccount.WithDraw(500);
        CurrentAccount.CheckBalance();
    }
}
