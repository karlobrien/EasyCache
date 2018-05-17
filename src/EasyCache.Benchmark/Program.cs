using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using EasyCache.Shared;

namespace EasyCache.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerialCacheBenchmark>();
        }
    }

    [CoreJob]
    [MemoryDiagnoser]
    public class SerialCacheBenchmark
    {
        const int size = 10000;
        private NaiveMemoryCache _naiveCache;
        private ConcurrentMemoryCache _ccMemoryCache;
        private NoSerialCache<EasyObject> _noSerialCache;
        public SerialCacheBenchmark()
        {
            _naiveCache = NaiveMemoryCache.Instance;
            _noSerialCache = NoSerialCache<EasyObject>.Instance;
        }

        [Benchmark]
        public void PopulateNaiveCacheOneByOne()
        {
            for(var i = 0; i < size; i++)
            {
                _naiveCache.Add(i, new EasyObject(i, i+1, i+1), TimeSpan.MinValue);
            }
            _naiveCache.ClearCache();
        }

        [Benchmark]
        public void PopulateWithList()
        {
            List<EasyObject> lst = new List<EasyObject>();

            for(var i = 0; i < size; i++)
            {
                lst.Add(new EasyObject(i, i+1, i+1));
            }

            _naiveCache.Add(lst, t => t.Id, TimeSpan.MinValue);
            _naiveCache.ClearCache();
        }

        [Benchmark]
        public void PopulateNoSerial()
        {
            List<EasyObject> lst = new List<EasyObject>();

            for(var i = 0; i < size; i++)
            {
                lst.Add(new EasyObject(i, i+1, i+1));
            }

            _noSerialCache.Add(lst, t => t.Id, TimeSpan.MinValue);
            _noSerialCache.ClearCache();
        }
    }

    public class EasyObject
    {
        public long Id {get;set;}
        public long Name { get;set;}
        public long Address {get;set;}

        public EasyObject(long id, long name, long address)
        {
            Id = id;
            Name = name;
            Address = address;
        }
    }
}
