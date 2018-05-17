using System;
using System.Collections.Generic;

namespace EasyCache.Shared
{
    public class NoSerialCache<TIn> //: IReadCache, IWriteCache
    {
        private static readonly Lazy<NoSerialCache<TIn>> lazy = new Lazy<NoSerialCache<TIn>>(() => new NoSerialCache<TIn>());
        public static NoSerialCache<TIn> Instance { get { return lazy.Value; } }

        private NoSerialCache()
        {
            _cache = new Dictionary<long, TIn>();
        }
        private Dictionary<long, TIn> _cache;

        public void Add(long key, TIn item, TimeSpan timeToLive)
        {
            try
            {
                _cache.Add(key, item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Add(List<TIn> items, Func<TIn, long> keyGen, TimeSpan timeToLive)
        {
            for(var i = 0; i < items.Count; i++)
            {
                var key = keyGen(items[i]);
                _cache.Add(key, items[i]);
            }
        }

        public TIn Get(long key)
        {
            TIn result;
            if (_cache.TryGetValue(key, out result))
                return result;
            return default(TIn);
        }

        public TIn Get(string key)
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