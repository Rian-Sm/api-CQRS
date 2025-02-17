using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Caching.Hosting;
using System.Threading.Tasks;
using MediatR;

namespace POC.Infra.CrossCutting.Cache
{
    public class InMemoryCache
    {
         private readonly IMediator _mediator;
         private readonly IMemoryCacheManager _memoryCache;

         public InMemoryCache(IMediator mediator, IMemoryCacheManager memoryCache){
             _mediator = mediator;
             _memoryCache = memoryCache;
         }

         public async Task<Object> SendQuery<T>(T Query) 
         {
             return await _mediator.Send(Query);
         }
    }
}