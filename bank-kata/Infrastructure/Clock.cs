using System;

namespace bank_kata.Infrastructure
{
    public class Clock : IClock
    {
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}