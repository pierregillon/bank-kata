using System;
using bank_kata.Infrastructure;
using bank_kata.Statements;
using bank_kata.Transactions;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Console_statement_printer_should
    {
        private readonly IConsole _console;
        private readonly StatementLineFormatter _statementLineFormatter;
        private readonly ConsoleStatementPrinter _consoleStatementPrinter;

        public Console_statement_printer_should()
        {
            _console = Substitute.For<IConsole>();
            _statementLineFormatter = Substitute.For<StatementLineFormatter>();
            _consoleStatementPrinter = new ConsoleStatementPrinter(_console, _statementLineFormatter);
        }

        [Fact]
        public void ask_to_format_orderlines()
        {
            _consoleStatementPrinter.Print(new[]
            {
                new Transaction(40, new DateTime(2016, 02, 14)),
                new Transaction(-20, new DateTime(2016, 02, 15)),
            });

            _statementLineFormatter.Received().Format(new StatementLine(new DateTime(2016, 02, 15), 40, 40));
            _statementLineFormatter.Received().Format(new StatementLine(new DateTime(2016, 02, 15), -20, 20));
        }

        [Fact]
        public void print_statement_to_the_console()
        {
            _consoleStatementPrinter.Print(new[]
            {
                new Transaction(40, new DateTime(2016, 02, 14)),
                new Transaction(-20, new DateTime(2016, 02, 15)),
            });

            _console.Received().Print(Arg.Any<string>());
        }
    }
}