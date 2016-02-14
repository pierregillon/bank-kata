namespace bank_kata
{
    public interface IBankService
    {
        void Deposit(int amount);
        void Withdraw(int amount);
        void PrintStatements();
    }
}
