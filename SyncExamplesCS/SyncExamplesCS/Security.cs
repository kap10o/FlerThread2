using System;
using System.Collections.Generic;

namespace SyncExamplesCS
{
    public class Security
    {
        private List<Stamp> transactionHistory;
        public int numberOfErrors { get; private set; }

        public Security()
        {
            transactionHistory = new List<Stamp>();
            numberOfErrors = 0;
        }

        public Stamp MakePreTransactionStamp(double balance, int clientId)
        {
            var stamp = new Stamp(clientId, balance);
            transactionHistory.Add(stamp);
            return stamp;
        }

        public Stamp MakePostTransactionStamp(double balance, int clientId)
        {
            var stamp = new Stamp(clientId, balance);
            transactionHistory.Add(stamp);
            return stamp;
        }

        public bool VerifyLastTransaction(double amount)
        {
            // Get the last two stamps
            var lastStamp = transactionHistory[transactionHistory.Count - 1];
            var prevStamp = transactionHistory[transactionHistory.Count - 2];

            // Calculate the actual change in balance
            double actualChange = lastStamp.Balance - prevStamp.Balance;

            // Check if the actual change in balance is within the threshold
            if (actualChange == amount)
            {
                // Transaction verified
                return true;
            }
            else
            {
                // Transaction not verified
                numberOfErrors++;
                return false;
            }
        }
    }
}
