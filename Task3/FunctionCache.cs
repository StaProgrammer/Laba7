using System;
using System.Collections.Generic;
public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    public delegate TResult Func<TKey, TResult>(TKey key);

    public TResult GetResult(TKey key, Func<TKey, TResult> function, TimeSpan cacheDuration)
    {
        if (cache.ContainsKey(key) && IsCacheValid(key, cacheDuration))
        {
            return cache[key].Result;
        }

        TResult result = function(key);
        cache[key] = new CacheItem(result, DateTime.Now);

        return result;
    }

    private bool IsCacheValid(TKey key, TimeSpan cacheDuration)
    {
        DateTime now = DateTime.Now;
        DateTime cacheTime = cache[key].Timestamp;
        return (now - cacheTime) <= cacheDuration;
    }

    private class CacheItem
    {
        public TResult Result { get; }
        public DateTime Timestamp { get; }

        public CacheItem(TResult result, DateTime timestamp)
        {
            Result = result;
            Timestamp = timestamp;
        }
    }
}