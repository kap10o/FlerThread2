using System;
using System.ComponentModel;

namespace SyncExamplesCS
{
    internal class BankAccount
    {
        private double balance;
        private Security security;
        private int numberOfTransactions;
        private object lockObject = new object();
        private object lockObject2 = new object();

        public BankAccount(double initAmount)
        {
            balance = initAmount;
            security = new Security();
        }

        public void Transaction(double amount, int clientId)
        {
            lock (lockObject)
            {
                lock (lockObject2)
                {
                    Console.WriteLine($"Client {clientId} is inside the transfer method.");
                    security.MakePreTransactionStamp(balance, clientId);
                    balance += amount;
                    numberOfTransactions++;
                    security.MakePostTransactionStamp(balance, clientId);
                    security.VerifyLastTransaction(amount);
                }
            }
        }
        public void Transaction2(double amount, int clientId)
        {
            lock (lockObject2)
            {
                lock (lockObject)
                {
                    Console.WriteLine($"Client {clientId} is inside the transfer2 method.");
                    security.MakePreTransactionStamp(balance, clientId);
                    balance += amount;
                    numberOfTransactions++;
                    security.MakePostTransactionStamp(balance, clientId);
                    security.VerifyLastTransaction(amount);
                }
            }
        }

        public double Balance
        {
            get
            {
                lock (lockObject)
                {
                    lock (lockObject2)
                    {
                        return balance;
                    }
                }
            }
        }

        public int GetNumberOfErrors()
        {
                lock (lockObject2)
                {
                    lock (lockObject)
                    {
                        return security.numberOfErrors;
                    }
                }
        }

        public int GetNumberOfTransactions()
        {
            lock (lockObject)
            {
                lock (lockObject2)
                {
                    return numberOfTransactions;
                }
            }
        }
    }
}