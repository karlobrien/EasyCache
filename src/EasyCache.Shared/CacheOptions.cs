using System;

namespace EasyCache.Shared
{
    public class CacheOptions
    {
        public TimeSpan TimeToLive { get;}

        public CacheOptions(TimeSpan live)
        {
            TimeToLive = live;
        }
    }
}