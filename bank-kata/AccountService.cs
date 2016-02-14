using bank_kata.Statements;
using bank_kata.Transactions;

namespace bank_kata
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionFactory _transactionFactory;
        private readonly IStatementPrinter _statementPrinter;

        public AccountService(
            ITransactionRepository transactionRepository,
            ITransactionFactory transactionFactory,
            IStatementPrinter statementPrinter)
        {
            _transactionRepository = transactionRepository;
            _transactionFactory = transactionFactory;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.Add(_transactionFactory.CreateNew(amount));
        }
        public void Withdraw(int amount)
        {
            _transactionRepository.Add(_transactionFactory.CreateNew(-amount));
        }
        public void PrintStatement()
        {
            var transactions = _transactionRepository.GetTransactions();
            _statementPrinter.Print(transactions);
        }
    }
}