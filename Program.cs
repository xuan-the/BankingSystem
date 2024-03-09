using System;

public class BankAccount
{
    private string accountNumber;
    private decimal balance;

    public BankAccount(string accountNumber, decimal initialBalance)
    {
        this.accountNumber = accountNumber;
        if (initialBalance < 0)
        {
            throw new ArgumentException("Initial balance cannot be negative.");
        }
        this.balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }

        balance += amount;
        Console.WriteLine($"Deposited: ${amount}. New balance: ${balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }

        if (balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds for withdrawal.");
        }

        balance -= amount;
        Console.WriteLine($"Withdrawn: ${amount}. New balance: ${balance}");
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public string AccountNumber
    {
        get { return accountNumber; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an instance of BankAccount with an initial balance
            BankAccount account = new BankAccount("1234567890", 1000);

            // Perform transactions
            account.Deposit(500);
            account.Withdraw(200);
            account.Withdraw(1000);  // This will fail due to insufficient funds
            account.Deposit(-100);   // This will fail due to negative deposit amount

            // Display balance after each transaction
            Console.WriteLine($"Current Balance: ${account.GetBalance()}");

            // Wait for user to press Enter before closing
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

            // Wait for user to press Enter before closing
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
