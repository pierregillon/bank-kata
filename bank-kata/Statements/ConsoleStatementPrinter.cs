using System;
using System.Collections.Generic;
using System.Linq;
using bank_kata.Infrastructure;
using bank_kata.Transactions;

namespace bank_kata.Statements
{
    public class ConsoleStatementPrinter : IStatementPrinter
    {
        private readonly IConsole _console;

        public ConsoleStatementPrinter(IConsole console)
        {
            _console = console;
        }

        public void Print(IEnumerable<Transaction> transactions)
        {
            var statement = GenerateStatementFrom(transactions);
            var line = "DATE | AMOUNT | BALANCE" + Environment.NewLine;
            foreach (var orderLine in statement.OrderLines) {
                line += Format(orderLine) + Environment.NewLine;
            }
            _console.Print(line);
        }

        private static Statement GenerateStatementFrom(IEnumerable<Transaction> transactions)
        {
            var statementLines = GenerateStatementLines(transactions);
            return Statement.Create(statementLines);
        }
        private static IEnumerable<StatementLine> GenerateStatementLines(IEnumerable<Transaction> transactions)
        {
            var balance = 0;
            return transactions.Select(transaction => new StatementLine(
                transaction.Date,
                transaction.Amount,
                balance += transaction.Amount));
        }

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