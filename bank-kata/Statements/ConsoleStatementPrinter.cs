using System;
using System.Collections.Generic;
using System.Linq;
using bank_kata.Infrastructure;
using bank_kata.Transactions;

namespace bank_kata.Statements
{
    public class ConsoleStatementPrinter : IStatementPrinter
    {
        private const string STATEMENT_HEADER = "DATE | AMOUNT | BALANCE";

        private readonly IConsole _console;

        public ConsoleStatementPrinter(IConsole console)
        {
            _console = console;
        }

        public void Print(IEnumerable<Transaction> transactions)
        {
            var runningBalance = 0;

            var statements = transactions
                .Select(x => Format(x.Date, x.Amount, runningBalance += x.Amount))
                .Reverse()
                .ToList();

            statements.Insert(0, STATEMENT_HEADER);

            _console.Print(string.Join(Environment.NewLine, statements));
        }

        public string Format(DateTime date, int amount, int balance)
        {
            return $"{date.ToShortDateString()} | {ToDecimal(amount)} | {ToDecimal(balance)}";
        }

        private string ToDecimal(int value)
        {
            return $"{value:0.00}";
        }
    }
}