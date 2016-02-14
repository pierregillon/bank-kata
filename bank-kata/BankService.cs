namespace bank_kata
{
    public class BankService : IBankService
    {
        private readonly IStatementRepository _statementRepository;

        public BankService(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
        }

        public void Deposit(int amount)
        {
            _statementRepository.Add(new Statement(amount));
        }

        public void Withdraw(int amount)
        {
            _statementRepository.Add(new Statement(-amount));
        }

        public void PrintStatements()
        {
            throw new System.NotImplementedException();
        }
    }
}