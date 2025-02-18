using MediatR;
using POC.Infra.CrossCutting.Cache.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using POC.Infra.CrossCutting.Cache.Models;

namespace POC.Infra.CrossCutting.Cache
{
    public class InMemoryCache : ICacheHandler
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;

        public InMemoryCache(IMediator mediator, IMemoryCache cache){
            _mediator = mediator;
            _cache = cache;
        }

        public async Task<Object> SendQuery<T>(T Query) 
        {
            return await _mediator.Send(Query);
        }

        public T SetValue<T>(string key, T Value)
        {
            MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromHours(2))
                .SetAbsoluteExpiration(TimeSpan.FromDays(2))
                .SetPriority(CacheItemPriority.Normal);
            
            
            return _cache.Set(key, Value, cacheOptions);
        }

        public bool GetValue<T>(string key, out T item)
        {
            bool sucess = _cache.TryGetValue<T>(key, out item);

            return sucess;
        }

       
    }
}