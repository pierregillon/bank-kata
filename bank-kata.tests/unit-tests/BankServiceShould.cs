using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Bank_service_should
    {
        private readonly BankService _bankService;
        private readonly IStatementRepository _statementRepository;

        public Bank_service_should()
        {
            _statementRepository = Substitute.For<IStatementRepository>();
            _bankService = new BankService(_statementRepository);
        }

        [Fact]
        public void add_deposit_line_statement_to_repository()
        {
            _bankService.Deposit(100);

            _statementRepository.Received().Add(new Statement(100));
        }

        [Fact]
        public void add_withdraw_line_statement_to_repository()
        {
            _bankService.Withdraw(50);

            _statementRepository.Received().Add(new Statement(-50));
        }
    }
}