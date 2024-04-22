using SyncExamplesCS;
using System;
using System.Threading;

internal class Client
{
    private readonly BankAccount account;
    private readonly Random random;
    private bool operating;
    private double totalAmountTransactioned;
    private readonly int clientId;

    public Client(BankAccount account, int clientId) 
    {
        this.account = account;
        this.clientId = clientId;
        random = new Random();
        operating = true;
        totalAmountTransactioned = 0;
    }

    public void Start()
    {
        // Randomly decide whether to deposit or withdraw
        bool deposit = random.Next(2) == 0;

        // Random amount between 100 and 500 in increments of 100
        double amount = random.Next(1, 6) * 100;

        // If it's not a deposit, make the amount negative
        if (!deposit)
        {
            amount = -amount;
        }

        // Deposit or withdraw
        if (deposit)
        {
            account.Transaction(amount, clientId); // Pass clientId to Transaction
            Console.WriteLine($"Client {clientId} deposited {amount:F2}. Balance: {account.Balance:F2}");
        }
        else
        {
            account.Transaction2(amount, clientId); // Pass clientId to Transaction
            Console.WriteLine($"Client {clientId} withdrew {amount:F2}. Balance: {account.Balance:F2}");
        }

        // Update total amount transacted
        totalAmountTransactioned += amount;

        // Stop the client after completing one transaction
        operating = false;
    }

    public double GetTotalAmountTransactioned()
    {
        return totalAmountTransactioned;
    }
}

