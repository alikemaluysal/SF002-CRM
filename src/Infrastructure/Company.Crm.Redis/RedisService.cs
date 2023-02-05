using Microsoft.Extensions.Caching.Distributed;

namespace Company.Crm.Redis
{
    public class RedisService
    {
        private readonly IDistributedCache _redis;

        public RedisService(IDistributedCache redis)
        {
            _redis = redis;
        }

        public void SetCache(string key, string value)
        {
            var options = new DistributedCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromDays(1),
                AbsoluteExpiration = DateTime.Now.AddDays(1)
            };
            _redis.SetString(key, value, options);
        }

        public string GetCache(string key)
        {
            return _redis.GetString(key);
        }

        public void RemoveCache(string key)
        {
            _redis.Remove(key);
        }
    }
}