using System.Collections.Generic;
using bank_kata.Transactions;

namespace bank_kata.Statements
{
    public interface IStatementPrinter
    {
        void Print(IEnumerable<Transaction> transactions);
    }
}