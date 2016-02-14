using System;

namespace bank_kata.Infrastructure
{
    public interface IClock
    {
        DateTime GetTime();
    }
}