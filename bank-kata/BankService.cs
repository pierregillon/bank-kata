namespace bank_kata
{
    public class BankService : IBankService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IClock _clock;

        public BankService(ITransactionRepository transactionRepository, IClock clock)
        {
            _transactionRepository = transactionRepository;
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
            throw new System.NotImplementedException();
        }

        private Transaction CreateTransaction(int amount)
        {
            return new Transaction(amount, _clock.GetTime());
        }
    }
}