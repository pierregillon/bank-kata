namespace bank_kata.Transactions
{
    public interface ITransactionFactory
    {
        Transaction CreateDepositTransaction(int amount);
        Transaction CreateWithdrawTransaction(int amount);
    }
}