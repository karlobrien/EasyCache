using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using EasyCache;
using EasyCache.Shared.Logging;

namespace EasyCache.Shared
{
    public class EasyMemoryCache<TKey, TValue> : IEasyCache<TKey, TValue> where TKey : struct
    {
        private static readonly ILog Logger = LogProvider.For<EasyMemoryCache<TKey, TValue>>();
        private ConcurrentDictionary<TKey, ICacheEntry> _dictionary;
        private readonly CacheOptions _cacheOptions;
        //pass serializer in here
        public EasyMemoryCache(CacheOptions cacheOptions)
        {
            _dictionary = new ConcurrentDictionary<TKey, ICacheEntry>();
            _cacheOptions = cacheOptions;
        }

        public void Add(TKey key, TValue item)
        {
            //Build cache entry
            //SErialize value to bytes
            ICacheEntry cacheEntry = new CacheEntry();
            cacheEntry.TimeToLive = DateTime.UtcNow.Add(_cacheOptions.TimeToLive);
            cacheEntry.Item = MsgPackImpl.Serialize<TValue>(item);

            if (_dictionary.TryAdd(key, cacheEntry))
            {

            }

        }

        public void Add(List<TValue> items, Func<TValue, TKey> keyGen)
        {
            throw new NotImplementedException();
        }

        public TValue Get(TKey key)
        {
            throw new NotImplementedException();
        }

        public List<TValue> GetItems(List<TKey> keys)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValues(List<TKey> key, out List<TValue> lstValues)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// It s important to implement both equals and gethashcode,
    /// due to collisions, in particular while using dictionaries.
    /// if two object returns same hashcode, they are inserted in the dictionary with chaining.
    /// While accessing the item equals method is used.
    /// if they return the same hash, the equals will be used to determine if they are the same.
    /// if two things are equal (Equals(...) == true) then they must return the same value for GetHashCode()
    //if the GetHashCode() is equal, it is not necessary for them to be the same; this is a collision, and Equals will be called to see if it is a real equality or not.
    /// </summary>

    public struct SimpleKey : IEquatable<SimpleKey>
    {
        public long Id { get; }
        public long EmployeeId { get; }

        public SimpleKey(long id, long employeeId)
        {
            Id = id;
            EmployeeId = employeeId;
        }

        public bool Equals(SimpleKey other)
        {
            return other.Id == Id && other.EmployeeId == EmployeeId;
        }

        public override string ToString()
        {
            return "";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                long result = 0;
                result = (result * 397) ^ Id;
                result = (result * 397) ^ EmployeeId;
                return (int)result;
            }
        }
    }

    public class CacheEntry : ICacheEntry
    {
        public DateTime TimeToLive { get; set; }
        public byte[] Item {get;set;}
        public Action RemoveCallback {get;set;}
    }
}