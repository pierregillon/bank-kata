using System;

namespace bank_kata
{
    public class Transaction
    {
        private readonly int _amount;

        public Transaction(int amount, DateTime dateTime)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            if (obj is Transaction == false) {
                return base.Equals(obj);
            }
            var target = (Transaction) obj;
            return target._amount == _amount;
        }
    }
}