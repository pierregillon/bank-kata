using System.Collections.Generic;

namespace bank_kata.Transactions
{
    public class InMemoryTransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public IReadOnlyCollection<Transaction> GetTransactions()
        {
            return _transactions;
        }
    }
}