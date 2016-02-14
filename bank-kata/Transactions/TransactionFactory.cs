using bank_kata.Infrastructure;

namespace bank_kata.Transactions
{
    public class TransactionFactory : ITransactionFactory
    {
        private readonly IClock _clock;

        public TransactionFactory(IClock clock)
        {
            _clock = clock;
        }

        public Transaction CreateNew(int amount)
        {
            return new Transaction(amount, _clock.GetTime());
        }
    }
}