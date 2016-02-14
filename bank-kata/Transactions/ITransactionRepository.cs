using System.Collections.Generic;

namespace bank_kata.Transactions
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        IReadOnlyCollection<Transaction> GetTransactions();
    }
}