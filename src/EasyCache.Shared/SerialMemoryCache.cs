using System;
using System.Collections.Specialized;
using System.Runtime;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace EasyCache.Shared
 {
    public class SerialMemoryCache : MemoryCache
    {
        public SerialMemoryCache(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
        {

        }
    }
}