using System;

namespace EasyCache
{
    public interface IExpiryCacheEntry<T>
    {
        DateTime TimeToLive {get; set;}
        T Item {get; set;}
        Action RemoveCallback {get; set;}
        Action ExpiryEvent { get; set;}
    }
}