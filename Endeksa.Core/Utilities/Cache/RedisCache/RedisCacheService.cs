﻿using StackExchange.Redis;
using System.Text.Json;

namespace Endeksa.Core.Utilities.Cache.RedisCache
{
    public class RedisCacheService : ICacheService
    {
        private IDatabase _cacheDb;

        public RedisCacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }

        public T GetData<T>(string key)
        {
           var value = _cacheDb.StringGet(key); 
            if(!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;    
        }

        public object RemoveData(string key)
        {
            var _exist = _cacheDb.KeyExists(key);
            if(_exist)
            {
                return _cacheDb.KeyDelete(key);
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);
            return _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expirtyTime);
        }
    }
}

