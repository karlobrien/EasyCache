using System;
using System.Collections.Generic;

namespace EasyCache
{
    /// <summary>
    /// Cache Api
    /// </summary>
    public interface IContainer
    {
        T Get<T>(string key);
        T Get<T>(long key);

        void Add<T>(long key, T item, TimeSpan timeToLive);
        void Add<T>(List<T> items, Func<T, long> keyGen, TimeSpan timeToLive);

        bool IsExpired(long key);
    }

    /// <summary>
    /// Readonly Cache Api
    /// Consumers can only read from the cache
    /// </summary>
    public interface IReadCache
    {
        T Get<T>(string key);
        T Get<T>(long key);
        bool IsExpired(long key);
    }

    /// <summary>
    /// Producer can write to the cache when insert/ updates occur
    /// </summary>
    public interface IWriteCache
    {
        void Add<T>(long key, T item, TimeSpan timeToLive);
        void Add<T>(List<T> items, Func<T, long> keyGen, TimeSpan timeToLive);
    }
}
