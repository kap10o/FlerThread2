using System;
using System.Collections.Generic;

namespace SyncExamplesCS
{
    public class Stamp
    {
        public int ClientId { get; }
        public double Balance { get; }

        public Stamp(int clientId, double balance)
        {
            ClientId = clientId;
            Balance = balance;
        }
    }
}
