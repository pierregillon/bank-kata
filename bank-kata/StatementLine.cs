using System;

namespace bank_kata
{
    public class StatementLine
    {
        public DateTime Date { get; }
        public int Amount { get; }
        public int Balance { get; }

        public StatementLine(DateTime date, int amount, int balance)
        {
            Date = date;
            Amount = amount;
            Balance = balance;
        }

        public override bool Equals(object obj)
        {
            return obj is StatementLine
                ? Equals((StatementLine) obj)
                : base.Equals(obj);
        }
        protected bool Equals(StatementLine other)
        {
            return Date.Equals(other.Date) && Amount == other.Amount && Balance == other.Balance;
        }
        public override int GetHashCode()
        {
            unchecked {
                var hashCode = Date.GetHashCode();
                hashCode = (hashCode*397) ^ Amount;
                hashCode = (hashCode*397) ^ Balance;
                return hashCode;
            }
        }
    }
}