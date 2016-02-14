using System.Collections.Generic;
using System.Linq;
using bank_kata.Infrastructure;
using bank_kata.Statements;
using bank_kata.Transactions;

namespace bank_kata
{
    public class BankService : IBankService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;
        private readonly IClock _clock;

        public BankService(
            ITransactionRepository transactionRepository,
            IStatementPrinter statementPrinter,
            IClock clock)
        {
            _transactionRepository = transactionRepository;
            _statementPrinter = statementPrinter;
            _clock = clock;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.Add(CreateTransaction(amount));
        }
        public void Withdraw(int amount)
        {
            _transactionRepository.Add(CreateTransaction(-amount));
        }
        public void PrintStatements()
        {
            var transactions = _transactionRepository.GetTransactions();
            _statementPrinter.Print(GenerateStatementFrom(transactions));
        }

        private Transaction CreateTransaction(int amount)
        {
            return new Transaction(amount, _clock.GetTime());
        }
        private static Statement GenerateStatementFrom(IEnumerable<Transaction> transactions)
        {
            var statementLines = GenerateStatementLines(transactions);
            return Statement.Create(statementLines);
        }
        private static IEnumerable<StatementLine> GenerateStatementLines(IEnumerable<Transaction> transactions)
        {
            var balance = 0;
            return transactions.Select(transaction => new StatementLine(
                transaction.Date,
                transaction.Amount,
                balance += transaction.Amount));
        }
    }
}