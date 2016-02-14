using System;
using bank_kata.Infrastructure;
using bank_kata.Statements;
using bank_kata.Transactions;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class AccountServiceShould
    {
        private static readonly DateTime SOME_TIME = new DateTime(2016, 02, 14);

        private readonly AccountService _accountService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IClock _clock;
        private readonly IStatementPrinter _statementPrinter;

        public AccountServiceShould()
        {
            _clock = Substitute.For<IClock>();
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _statementPrinter = Substitute.For<IStatementPrinter>();

            _accountService = new AccountService(_transactionRepository, _statementPrinter, _clock);
        }

        [Fact]
        public void store_a_deposit_transaction()
        {
            _clock.GetTime().Returns(SOME_TIME);

            _accountService.Deposit(100);

            _transactionRepository.Received().Add(new Transaction(100, SOME_TIME));
        }

        [Fact]
        public void store_a_withdraw_transaction()
        {
            _clock.GetTime().Returns(SOME_TIME);

            _accountService.Withdraw(50);

            _transactionRepository.Received().Add(new Transaction(-50, new DateTime(2016, 02, 14)));
        }

        [Fact]
        public void print_a_statement()
        {
            _transactionRepository.GetTransactions().Returns(new[]
            {
                new Transaction(40, new DateTime(2016, 02, 14)),
                new Transaction(-20, new DateTime(2016, 02, 15)),
            });

            _accountService.PrintStatement();

            _statementPrinter.Received().Print(Statement.Create(new []
            {
                new StatementLine(new DateTime(2016, 02, 15), -20, 20),
                new StatementLine(new DateTime(2016, 02, 14), 40, 40),
            }));
        }
    }
}