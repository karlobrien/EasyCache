using System;
using EasyCache.Shared;
using Xunit;

namespace EasyCache.Tests
{
    public class MemoryCacheTests
    {
        [Fact]
        public void CacheStores_ReturnsMatchingObject()
        {
            var instance = MemoryCache.Instance;

            SimpleObject first = new SimpleObject();
            first.Id = 1;
            first.Name = "Karl";
            first.Address = "location here";

            instance.Add<SimpleObject>(first.Id, first, TimeSpan.MinValue);

            var result = instance.Get<SimpleObject>(1);

            Assert.True(result.Name == first.Name);

        }
    }

    public class SimpleObject
    {
        public long Id {get;set;}
        public string Name { get;set;}
        public string Address {get;set;}
    }
}
