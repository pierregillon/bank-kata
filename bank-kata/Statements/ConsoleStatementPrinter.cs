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
        private readonly StatementLineFormatter _statementLineFormatter;

        public ConsoleStatementPrinter(
            IConsole console,
            StatementLineFormatter statementLineFormatter)
        {
            _console = console;
            _statementLineFormatter = statementLineFormatter;
        }

        public void Print(IEnumerable<Transaction> transactions)
        {
            var statement = GenerateStatementFrom(transactions);
            var line = "DATE       | AMOUNT  | BALANCE" + Environment.NewLine;
            foreach (var orderLine in statement.OrderLines) {
                line += _statementLineFormatter.Format(orderLine) + Environment.NewLine;
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
    }
}