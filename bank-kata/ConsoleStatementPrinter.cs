namespace bank_kata
{
    public class ConsoleStatementPrinter : IStatementPrinter
    {
        private readonly IConsole _console;
        private readonly StatementLineFormatter _statementLineFormatter;

        public ConsoleStatementPrinter(
            IConsole console, 
            StatementLineFormatter statementLineFormatter)
        {
            _console = console;
            _statementLineFormatter = statementLineFormatter;
        }

        public void Print(Statement statement)
        {
            foreach (var orderLine in statement.OrderLines) {
                _statementLineFormatter.Format(orderLine);
            }
        }
    }
}