using System;
using System.Collections.Generic;

namespace EasyCache.Shared
{
    public class NaiveMemoryCache : IReadCache, IWriteCache
    {
        private static readonly Lazy<NaiveMemoryCache> lazy = new Lazy<NaiveMemoryCache>(() => new NaiveMemoryCache());

        //TODO Need to a locking to dictionary or use concurrent
        public static NaiveMemoryCache Instance { get { return lazy.Value; } }

        private NaiveMemoryCache()
        {
            _cache = new Dictionary<long, byte[]>();
        }
        private Dictionary<long, byte[]> _cache;

        public void Add<T>(long key, T item, TimeSpan timeToLive)
        {
            try
            {
                var reduced = MsgPackImpl.Serialize(item);
                _cache.Add(key, reduced);
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
                var reduce = MsgPackImpl.Serialize(items[i]);
                var key = keyGen(items[i]);
                _cache.Add(key, reduce);
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