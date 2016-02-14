using System;

namespace bank_kata
{
    public class Statement
    {
        private readonly int _amount;

        public Statement(int amount, DateTime dateTime)
        {
            _amount = amount;
        }

        public override bool Equals(object obj)
        {
            if (obj is Statement == false) {
                return base.Equals(obj);
            }
            var target = (Statement) obj;
            return target._amount == _amount;
        }
    }
}