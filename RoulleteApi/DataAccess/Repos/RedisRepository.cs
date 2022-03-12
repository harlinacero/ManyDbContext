using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RoulleteApi.Entities;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace RoulleteApi.DataAccess
{
    public class RedisRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly RedisClient _redisClient;
        private readonly IConfiguration _configuration;
        public RedisRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            RedisEndpoint redisEndpoint = GetConnectionString();

            _redisClient = new RedisClient(redisEndpoint);
        }

        private RedisEndpoint GetConnectionString()
        {
            var connectionString = _configuration.GetConnectionString("RedisConnection");
            var conn = JsonConvert.DeserializeObject<RedisEndpoint>(connectionString);
            return new RedisEndpoint(conn.Host, conn.Port);
        }

        public void Delete(string id)
        {
            using (_redisClient)
            {
                _redisClient.Delete(id);
            }
        }

        public TEntity Get(string id)
        {
            using (_redisClient)
            {
                return _redisClient.Get<TEntity>(id);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (_redisClient)
            {
                return _redisClient.GetAll<TEntity>();
            }
        }

        public TEntity Add(TEntity value)
        {
            using (_redisClient)
            {

                if (_redisClient.Add(value.Id, value))
                {
                    return _redisClient.Get<TEntity>(value.Id);
                }
                return default;

            }
        }

        public TEntity Update(TEntity value)
        {
            using(_redisClient)
            {              
                if(_redisClient.Set<TEntity>(value.Id, value))
                {
                    return _redisClient.Get<TEntity>(value.Id);
                }

                return default;
            }
        }
    }
}
