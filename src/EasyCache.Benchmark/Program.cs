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
            //ar summary = BenchmarkRunner.Run<SerialCacheBenchmark>();
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
