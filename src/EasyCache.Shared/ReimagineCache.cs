using System;
using System.Collections.Concurrent;

namespace EasyCache.Shared
{
    public class ReImagineCache<TValue>
    {
        private ConcurrentDictionary<long, IExpiryCacheEntry<TValue>> _cache;

        //producer thread to update the dictionary, check for updates from the source

        public ReImagineCache()
        {
            //start up the thread to update the cache

        }

        public bool TryGetValue(long key, out TValue value)
        {
            IExpiryCacheEntry<TValue> item = null;
            if (!_cache.TryGetValue(key, out item))
                return false;

        }
    }

    public class SampleObject
    {
        public long Id {get;set;}
        public string Name { get;set;}
        public string Address {get;set;}
    }

    public class ExpiryCacheEntry : IExpiryCacheEntry<SampleObject>
    {
        public DateTime TimeToLive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SampleObject Item { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action RemoveCallback { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Action ExpiryEvent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}