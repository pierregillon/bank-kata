using bank_kata.Infrastructure;
using bank_kata.Statements;
using bank_kata.Transactions;

namespace bank_kata
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _statementPrinter;
        private readonly IClock _clock;

        public AccountService(
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
        public void PrintStatement()
        {
            var transactions = _transactionRepository.GetTransactions();
            _statementPrinter.Print(transactions);
        }

        private Transaction CreateTransaction(int amount)
        {
            return new Transaction(amount, _clock.GetTime());
        }
        
    }
}