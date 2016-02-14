namespace bank_kata.Transactions
{
    public interface ITransactionFactory
    {
        Transaction CreateNew(int amount);
    }
}