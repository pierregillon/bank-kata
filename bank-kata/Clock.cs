using System;

namespace bank_kata
{
    public class Clock : IClock
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}