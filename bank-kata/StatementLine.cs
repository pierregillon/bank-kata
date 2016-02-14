using System;

namespace bank_kata
{
    public class StatementLine
    {
        public DateTime Date { get; }
        private readonly int _amount;
        private readonly int _balance;

        public StatementLine(DateTime date, int amount, int balance)
        {
            Date = date;
            _amount = amount;
            _balance = balance;
        }

        public override bool Equals(object obj)
        {
            return obj is StatementLine
                ? Equals((StatementLine) obj)
                : base.Equals(obj);
        }
        protected bool Equals(StatementLine other)
        {
            return Date.Equals(other.Date) && _amount == other._amount && _balance == other._balance;
        }
        public override int GetHashCode()
        {
            unchecked {
                var hashCode = Date.GetHashCode();
                hashCode = (hashCode*397) ^ _amount;
                hashCode = (hashCode*397) ^ _balance;
                return hashCode;
            }
        }
    }
}