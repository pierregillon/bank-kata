using System;
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
            var statementLine1 = new StatementLine(new DateTime(2016, 02, 15), -20, 20);
            var statementLine2 = new StatementLine(new DateTime(2016, 02, 15), 40, 40);

            _consoleStatementPrinter.Print(Statement.Create(new[]
            {
                statementLine1,
                statementLine2
            }));

            _statementLineFormatter.Received().Format(statementLine2);
            _statementLineFormatter.Received().Format(statementLine1);
        }

        [Fact]
        public void print_statement_to_the_console()
        {
            var statementLine1 = new StatementLine(new DateTime(2016, 02, 15), -20, 20);
            var statementLine2 = new StatementLine(new DateTime(2016, 02, 15), 40, 40);

            _consoleStatementPrinter.Print(Statement.Create(new[]
            {
                statementLine1,
                statementLine2
            }));

            _console.Received().Print(Arg.Any<string>());
        }
    }

}