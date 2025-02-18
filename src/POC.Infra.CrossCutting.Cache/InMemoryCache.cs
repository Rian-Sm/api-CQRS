using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Caching.Hosting;
using System.Threading.Tasks;
using MediatR;
using POC.Infra.CrossCutting.Cache.Interfaces;

namespace POC.Infra.CrossCutting.Cache
{
    public class InMemoryCache : ICacheHandler
    {
         private readonly IMediator _mediator;
         private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy;

         public InMemoryCache(IMediator mediator){
             _mediator = mediator;
            
            _policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10) // Expira em 10 minutos
            };
         }

         public async Task<Object> SendQuery<T>(T Query) 
         {
             return await _mediator.Send(Query);
         }

         public void AddToCache(string key, object value)
        {
            _cache.Add(key, value, _policy);
        }

        public object GetFromCache(string key)
        {
            return _cache.Get(key);
        }

        public void RemoveFromCache(string key)
        {
            _cache.Remove(key);
        }
    }
}