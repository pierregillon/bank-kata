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

        public Transaction CreateDepositTransaction(int amount)
        {
            return new Transaction(amount, _clock.GetTime());
        }

        public Transaction CreateWithdrawTransaction(int amount)
        {
            return new Transaction(-amount, _clock.GetTime());
        }
    }
}