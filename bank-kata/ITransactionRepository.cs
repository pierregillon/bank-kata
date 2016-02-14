using System.Collections.Generic;

namespace bank_kata
{
    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        IReadOnlyCollection<Transaction> GetTransactions();
    }
}