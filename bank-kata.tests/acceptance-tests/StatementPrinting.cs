using NSubstitute;
using Xunit;

namespace bank_kata.tests
{
    public class Statement_Printing
    {
        [Fact]
        public void a_bank_service_should_print_statements_in_inverse_chronological_order()
        {
            var console = Substitute.For<IConsole>();
            var bankService = new BankService(
                new InMemoryTransactionRepository(), 
                new ConsoleStatementPrinter(console, new StatementLineFormatter()), 
                new Clock());

            bankService.Deposit(1000);
            bankService.Withdraw(100);
            bankService.Deposit(500);
            bankService.PrintStatements();

            console.Received().Print(
                "DATE       | AMOUNT  | BALANCE" +
                "10/04/2014 | 500.00  | 1400.00" +
                "02/04/2014 | -100.00 |  900.00" +
                "01/04/2014 | 1000.00 | 1000.00"
                );
        }
    }
}