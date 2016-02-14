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
            _transactionRepository.Add(new Transaction(amount, _clock.GetTime()));
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.Add(new Transaction(-amount, _clock.GetTime()));
        }

        public void PrintStatements()
        {
            throw new System.NotImplementedException();
        }
    }
}