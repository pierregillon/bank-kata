using System;
using System.Collections.Generic;
using System.Linq;
using bank_kata.Infrastructure;
using bank_kata.Statements;
using bank_kata.Transactions;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Console_statement_printer_should
    {
        private readonly IEnumerable<Transaction> NO_TRANSACTION = Enumerable.Empty<Transaction>();

        private readonly IConsole _console;
        private readonly ConsoleStatementPrinter _consoleStatementPrinter;

        public Console_statement_printer_should()
        {
            _console = Substitute.For<IConsole>();
            _consoleStatementPrinter = new ConsoleStatementPrinter(_console);
        }

        [Fact]
        public void should_always_print_the_header()
        {
            _consoleStatementPrinter.Print(NO_TRANSACTION);

            _console.Received().Print("DATE | AMOUNT | BALANCE");
        }

        [Fact]
        public void print_transactions_in_reverse_chronological_order()
        {
            _consoleStatementPrinter.Print(new[]
            {
                new Transaction(40, new DateTime(2016, 02, 14)),
                new Transaction(-20, new DateTime(2016, 02, 15)),
            });

            _console.Received().Print(
                "DATE | AMOUNT | BALANCE" + Environment.NewLine +
                "15/02/2016 | -20.00 | 20.00" + Environment.NewLine +
                "14/02/2016 | 40.00 | 40.00"
                );
        }
    }
}