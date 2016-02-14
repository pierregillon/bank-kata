using NSubstitute;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class Bank_service_should
    {
        [Fact]
        public void add_deposit_line_statement_to_repository()
        {
            var statementRepository = Substitute.For<IStatementRepository>();
            var bankService = new BankService(statementRepository);

            bankService.Deposit(100);

            statementRepository.Received().Add(new Statement(100));
        }
    }

}
