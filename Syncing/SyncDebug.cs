using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public async Task<List<string>> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            await Parallel.ForEachAsync(items, new ParallelOptions { MaxDegreeOfParallelism = 10 }, async (i, token) =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            });
            
            return bag.ToList();
        }

        public async Task<Dictionary<int, string>> InitializeDictionary(Func<int, string> getItem)
        {
            var lockObject = new object();
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() => {
                    lock (lockObject)
                    {
                        foreach (var item in itemsToInitialize)
                        {
                            concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                        }
                    }
                }))
                .ToList();

            
            foreach (var thread in threads)
            {
                thread.Start();
            }
            
            
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}