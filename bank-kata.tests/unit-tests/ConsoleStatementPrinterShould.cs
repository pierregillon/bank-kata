using System;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Console_statement_printer_should
    {
        [Fact]
        public void ask_to_format_orderlines()
        {
            var console = Substitute.For<IConsole>();
            var statementLineFormatter = Substitute.For<StatementLineFormatter>();
            var consoleStatementPrinter = new ConsoleStatementPrinter(console, statementLineFormatter);

            var statementLine1 = new StatementLine(new DateTime(2016, 02, 15), -20, 20);
            var statementLine2 = new StatementLine(new DateTime(2016, 02, 15), 40, 40);

            consoleStatementPrinter.Print(Statement.Create(new[]
            {
                statementLine1,
                statementLine2
            }));

            statementLineFormatter.Received().Format(statementLine2);
            statementLineFormatter.Received().Format(statementLine1);
        }
    }

}