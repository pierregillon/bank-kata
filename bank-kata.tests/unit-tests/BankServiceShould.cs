using System;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Bank_service_should
    {
        private static readonly DateTime SOME_TIME = new DateTime(2016, 02, 14);

        private readonly BankService _bankService;
        private readonly IStatementRepository _statementRepository;
        private readonly IClock _clock;

        public Bank_service_should()
        {
            _clock = Substitute.For<IClock>();
            _statementRepository = Substitute.For<IStatementRepository>();
            _bankService = new BankService(_statementRepository, _clock);
        }
        [Fact]
        public void add_deposit_line_statement_to_repository()
        {
            _clock.GetTime().Returns(SOME_TIME);

            _bankService.Deposit(100);

            _statementRepository.Received().Add(new Statement(100, SOME_TIME));
        }

        [Fact]
        public void add_withdraw_line_statement_to_repository()
        {
            _clock.GetTime().Returns(SOME_TIME);

            _bankService.Withdraw(50);

            _statementRepository.Received().Add(new Statement(-50, new DateTime(2016, 02, 14)));
        }
    }
}