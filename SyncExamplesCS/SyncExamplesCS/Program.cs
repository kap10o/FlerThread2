using System;
using System.Threading;

namespace SyncExamplesCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            BankAccount account = new BankAccount(0);
            Client[] clients = new Client[100];
            Thread[] clientThreads = new Thread[100];

            // Create clients and corresponding threads
            for (int i = 0; i < clients.Length; i++)
            {
                clients[i] = new Client(account, i + 1);
                clientThreads[i] = new Thread(clients[i].Start);
            }

            // Start all client threads
            foreach (var thread in clientThreads)
            {
                thread.Start();
                //thread.Join();
            }

            double totalAmountTransactioned = 0;
            foreach (var client in clients)
            {
                totalAmountTransactioned += client.GetTotalAmountTransactioned();
            }

            // Print required information
            Console.WriteLine("Number of transactions: " + account.GetNumberOfTransactions());
            Console.WriteLine("Number of errors: " + account.GetNumberOfErrors());
            Console.WriteLine("All transactions of Clients sums into: " + totalAmountTransactioned + ", balance on account: " + account.Balance);
        }
    }
}