using System;
using System.Collections.Generic;

namespace EasyCache.Shared
{
    public class MemoryCache : IContainer
    {
        //Lazy initialization of cache
        private MemoryCache()
        {

        }

        public void Add<T>(long key, T item, TimeSpan timeToLive)
        {

            throw new NotImplementedException();
        }

        public void Add<T>(List<T> items, Func<T, long> keyGen, TimeSpan timeToLive)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(long key)
        {
            throw new NotImplementedException();
        }

        public bool IsExpired(long key)
        {
            throw new NotImplementedException();
        }
    }
}