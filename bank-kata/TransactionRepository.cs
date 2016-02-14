using System.Collections.Generic;

namespace bank_kata
{
    public class TransactionRepository : ITransactionRepository
    {
        public void Add(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }
        public IReadOnlyCollection<Transaction> GetTransactions()
        {
            throw new System.NotImplementedException();
        }
    }
}