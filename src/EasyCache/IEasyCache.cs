using System;
using System.Collections.Generic;

namespace EasyCache
{
    public interface IEasyCache<TKey, TVal> where TKey : struct
    {
        TVal Get(TKey key);
        List<TVal> GetItems(List<TKey> keys);
        bool TryGetValue(TKey key, out TVal value);
        bool TryGetValues(List<TKey> key, out List<TVal> lstValues);

        void Add(TKey key, TVal item);
        void Add(List<TVal> items, Func<TVal, TKey> keyGen);
    }

    public interface ICacheEntry
    {
        DateTime TimeToLive {get; set;}
        byte[] Item {get;set;}
        Action RemoveCallback {get;set;}
    }
}