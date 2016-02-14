using System;
using bank_kata.Infrastructure;
using bank_kata.Transactions;
using NFluent;
using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class TransactionFactoryShould
    {
        private readonly DateTime SOME_TIME = new DateTime(2016, 02, 15);

        private readonly IClock _clock;
        private readonly TransactionFactory _transactionFactory;

        public TransactionFactoryShould()
        {
            _clock = Substitute.For<IClock>();
            _transactionFactory = new TransactionFactory(_clock);
        }

        [Fact]
        public void Create_A_Deposit_Transaction_From_Current_System_Date()
        {
            _clock.GetTime().Returns(SOME_TIME);

            var transaction = _transactionFactory.CreateDepositTransaction(300);

            Check.That(transaction).IsEqualTo(new Transaction(300, SOME_TIME));
        }

        [Fact]
        public void Create_A_Withdraw_Transaction_From_Current_System_Date()
        {
            _clock.GetTime().Returns(SOME_TIME);

            var transaction = _transactionFactory.CreateWithdrawTransaction(300);

            Check.That(transaction).IsEqualTo(new Transaction(-300, SOME_TIME));
        }
    }
}