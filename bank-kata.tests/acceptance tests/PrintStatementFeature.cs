using System;
using bank_kata.Infrastructure;
using bank_kata.Statements;
using bank_kata.Transactions;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.acceptance_tests
{
    public class PrintStatementFeature
    {
        private readonly IConsole _console;
        private readonly IClock _clock;
        private readonly AccountService _accountService;

        public PrintStatementFeature()
        {
            _console = Substitute.For<IConsole>();
            _clock = Substitute.For<IClock>();

            _accountService = new AccountService(
                new InMemoryTransactionRepository(),
                new TransactionFactory(_clock), 
                new ConsoleStatementPrinter(_console));
        }

        [Fact]
        public void an_account_service_should_print_statement_containing_all_transactions()
        {
            _clock.GetTime().Returns(
                new DateTime(2014, 04, 01),
                new DateTime(2014, 04, 02),
                new DateTime(2014, 04, 10));

            _accountService.Deposit(1000);
            _accountService.Withdraw(100);
            _accountService.Deposit(500);
            _accountService.PrintStatement();

            _console.Received().Print(
                "DATE | AMOUNT | BALANCE" + Environment.NewLine +
                "10/04/2014 | 500.00 | 1400.00" + Environment.NewLine +
                "02/04/2014 | -100.00 | 900.00" + Environment.NewLine +
                "01/04/2014 | 1000.00 | 1000.00"
                );
        }
    }
}