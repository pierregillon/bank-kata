using System;
using bank_kata.Infrastructure;

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

        public void Print(Statement statement)
        {
            var line = "DATE       | AMOUNT  | BALANCE" + Environment.NewLine;
            foreach (var orderLine in statement.OrderLines) {
                line += _statementLineFormatter.Format(orderLine) + Environment.NewLine;
            }
            _console.Print(line);
        }
    }
}