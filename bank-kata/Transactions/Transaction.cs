using System;

namespace bank_kata.Transactions
{
    public class Transaction
    {
        public int Amount { get; }
        public DateTime Date { get; }

        public Transaction(int amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        public override bool Equals(object obj)
        {
            if (obj is Transaction == false) {
                return base.Equals(obj);
            }
            var target = (Transaction) obj;
            return target.Amount == Amount && target.Date == Date;
        }
    }
}