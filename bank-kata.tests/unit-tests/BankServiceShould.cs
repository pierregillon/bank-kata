using System;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Bank_service_should
    {
        private static readonly DateTime SOME_TIME = new DateTime(2016, 02, 14);

        private readonly BankService _bankService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IClock _clock;
        private readonly IStatementPrinter _statementPrinter;

        public Bank_service_should()
        {
            _clock = Substitute.For<IClock>();
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _statementPrinter = Substitute.For<IStatementPrinter>();

            _bankService = new BankService(_transactionRepository, _statementPrinter, _clock);
        }

        [Fact]
        public void register_transaction_for_a_deposit()
        {
            _clock.GetTime().Returns(SOME_TIME);

            _bankService.Deposit(100);

            _transactionRepository.Received().Add(new Transaction(100, SOME_TIME));
        }

        [Fact]
        public void register_transaction_for_a_withdraw()
        {
            _clock.GetTime().Returns(SOME_TIME);

            _bankService.Withdraw(50);

            _transactionRepository.Received().Add(new Transaction(-50, new DateTime(2016, 02, 14)));
        }

        [Fact]
        public void print_statements()
        {
            _transactionRepository.GetTransactions().Returns(new[]
            {
                new Transaction(40, new DateTime(2016, 02, 14)),
                new Transaction(-20, new DateTime(2016, 02, 15)),
            });

            _bankService.PrintStatements();

            _statementPrinter.Received().Print(Statement.Create(new []
            {
                new StatementLine(new DateTime(2016, 02, 15), -20, 20),
                new StatementLine(new DateTime(2016, 02, 14), 40, 40),
            }));
        }
    }
}