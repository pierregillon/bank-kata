using System;

namespace bank_kata
{
    public class StatementLineFormatter
    {
        public string Format(StatementLine statementLine)
        {
            return $"{statementLine.Date.ToShortDateString()} | {ToDecimal(statementLine.Amount)} | {ToDecimal(statementLine.Balance)}";
        }

        private string ToDecimal(int value)
        {
            return $"{value:0.00}";
        }
    }
}