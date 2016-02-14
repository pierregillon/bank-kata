namespace bank_kata
{
    public class BankService : IBankService
    {
        private readonly IStatementRepository _statementRepository;
        private readonly IClock _clock;

        public BankService(IStatementRepository statementRepository, IClock clock)
        {
            _statementRepository = statementRepository;
            _clock = clock;
        }

        public void Deposit(int amount)
        {
            _statementRepository.Add(new Statement(amount, _clock.GetTime()));
        }

        public void Withdraw(int amount)
        {
            _statementRepository.Add(new Statement(-amount, _clock.GetTime()));
        }

        public void PrintStatements()
        {
            throw new System.NotImplementedException();
        }
    }
}