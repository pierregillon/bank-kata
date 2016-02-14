using System.Collections.Generic;
using System.Linq;

namespace bank_kata.Statements
{
    public class Statement
    {
        public IEnumerable<StatementLine> OrderLines { get; }

        private Statement(IEnumerable<StatementLine> statements)
        {
            OrderLines = statements;
        }

        public static Statement Create(IEnumerable<StatementLine> statementLines)
        {
            var reversedList = statementLines.OrderByDescending(x => x.Date).ToArray();
            return new Statement(reversedList);
        }

        public override bool Equals(object obj)
        {
            return obj is Statement
                ? Equals((Statement) obj)
                : base.Equals(obj);
        }
        protected bool Equals(Statement other)
        {
            return other.OrderLines.SequenceEqual(OrderLines);
        }
        public override int GetHashCode()
        {
            return OrderLines?.GetHashCode() ?? 0;
        }
    }
}