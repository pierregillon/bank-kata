using bank_kata.Infrastructure;
using NFluent;
using Xunit;

namespace bank_kata.tests.unit_tests
{
    public class ClockShould
    {
        [Fact]
        public void return_today_date_in_dd_MM_yyyy_format()
        {
            var clock = new Clock();

            var today = clock.GetTodayAsString();

            Check.That(today).IsEqualTo("11/02/2016");
        }
    }
}
