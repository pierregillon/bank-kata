using System.Collections.Generic;
using System.Linq;

namespace bank_kata
{
    public class Statement
    {
        private readonly IEnumerable<StatementLine> _statements;

        private Statement(IEnumerable<StatementLine> statements)
        {
            _statements = statements;
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
            return other._statements.SequenceEqual(_statements);
        }
        public override int GetHashCode()
        {
            return _statements?.GetHashCode() ?? 0;
        }
    }
}