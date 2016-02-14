using System;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.acceptance_tests
{
    public class Statement_Printing
    {
        private readonly IConsole _console;
        private readonly IClock _clock;
        private readonly BankService _bankService;

        public Statement_Printing()
        {
            _console = Substitute.For<IConsole>();
            _clock = Substitute.For<IClock>();

            _bankService = new BankService(
                new InMemoryTransactionRepository(),
                new ConsoleStatementPrinter(_console, new StatementLineFormatter()),
                _clock);
        }

        [Fact]
        public void a_bank_service_should_print_statements_in_inverse_chronological_order()
        {
            _clock.GetTime().Returns(
                new DateTime(2014, 04, 01),
                new DateTime(2014, 04, 02),
                new DateTime(2014, 04, 10));

            _bankService.Deposit(1000);
            _bankService.Withdraw(100);
            _bankService.Deposit(500);
            _bankService.PrintStatements();

            _console.Received().Print(
                "DATE       | AMOUNT  | BALANCE" + Environment.NewLine +
                "10/04/2014 | 500.00 | 1400.00" + Environment.NewLine +
                "02/04/2014 | -100.00 | 900.00" + Environment.NewLine +
                "01/04/2014 | 1000.00 | 1000.00" + Environment.NewLine
                );
        }
    }
}