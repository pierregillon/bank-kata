using System;
using System.Collections.Generic;
using bank_kata.Statements;
using bank_kata.Transactions;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class AccountServiceShould
    {
        private static readonly DateTime SOME_TIME = new DateTime(2016, 02, 14);
        private readonly IEnumerable<Transaction> SOME_TRANSACTIONS = new[]
        {
            new Transaction(40, new DateTime(2016, 02, 14)),
            new Transaction(-20, new DateTime(2016, 02, 15)),
        };

        private readonly AccountService _accountService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionFactory _transactionFactory;
        private readonly IStatementPrinter _statementPrinter;

        public AccountServiceShould()
        {
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _transactionFactory = Substitute.For<ITransactionFactory>();
            _statementPrinter = Substitute.For<IStatementPrinter>();

            _accountService = new AccountService(_transactionRepository, _transactionFactory, _statementPrinter);
        }

        [Fact]
        public void store_a_deposit_transaction()
        {
            _transactionFactory.CreateDepositTransaction(Arg.Any<int>()).Returns(info => new Transaction((int) info[0], SOME_TIME));

            _accountService.Deposit(100);

            _transactionRepository.Received().Add(new Transaction(100, SOME_TIME));
        }

        [Fact]
        public void store_a_withdraw_transaction()
        {
            _transactionFactory.CreateWithdrawTransaction(Arg.Any<int>()).Returns(info => new Transaction(-(int) info[0], SOME_TIME));

            _accountService.Withdraw(50);

            _transactionRepository.Received().Add(new Transaction(-50, SOME_TIME));
        }

        [Fact]
        public void print_a_statement()
        {
            _transactionRepository.GetTransactions().Returns(SOME_TRANSACTIONS);

            _accountService.PrintStatement();

            _statementPrinter.Received().Print(SOME_TRANSACTIONS);
        }
    }
}