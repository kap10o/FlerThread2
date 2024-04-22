using System;

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
                    security.MakePreTransactionStamp(balance, clientId);
                    balance += amount;
                    numberOfTransactions++;
                    security.MakePostTransactionStamp(balance, clientId);
                    security.VerifyLastTransaction(amount);
            }
        }

        public double Balance
        {
            get
            {
                lock (lockObject)
                {
                    return balance;
                }
            }
        }

        public int GetNumberOfErrors()
        {
            return security.numberOfErrors;
        }

        public int GetNumberOfTransactions()
        {
            return numberOfTransactions;
        }
    }
}