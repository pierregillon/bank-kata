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

        public Bank_service_should()
        {
            _clock = Substitute.For<IClock>();
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _bankService = new BankService(_transactionRepository, _clock);
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
    }
}