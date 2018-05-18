using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace EasyCache.Shared
{
    public class ConcurrentMemoryCache : IReadCache, IWriteCache
    {
        private static readonly Lazy<ConcurrentMemoryCache> lazy = new Lazy<ConcurrentMemoryCache>(() => new ConcurrentMemoryCache());
        public static ConcurrentMemoryCache Instance { get { return lazy.Value; } }

        private ConcurrentMemoryCache()
        {
            _cache = new ConcurrentDictionary<long, byte[]>();
        }
        private ConcurrentDictionary<long, byte[]> _cache;

        public void Add<T>(long key, T item, TimeSpan timeToLive)
        {
            try
            {
                var reduced = MsgPackImpl.Serialize(item);
                _cache.AddOrUpdate(key, reduced, (k, value) => reduced);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void Add<T>(List<T> items, Func<T, long> keyGen, TimeSpan timeToLive)
        {
            for(var i = 0; i < items.Count; i++)
            {
                var reduced = MsgPackImpl.Serialize(items[i]);
                var key = keyGen(items[i]);
                _cache.AddOrUpdate(key, reduced, (k, value) => reduced);
            }
        }

        public T Get<T>(long key)
        {
            byte[] result;
            if (_cache.TryGetValue(key, out result))
                return MsgPackImpl.Deserialize<T>(result);
            return default(T);
        }

        public T Get<T>(string key)
        {
            //deserialize
            throw new NotImplementedException();
        }

        public bool IsExpired(long key)
        {
            throw new NotImplementedException();
        }

        public void ClearCache()
        {
            _cache.Clear();
        }
    }
}