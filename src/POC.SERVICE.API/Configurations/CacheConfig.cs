using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.SERVICE.API.Configurations
{
    public static class CacheConfig
    {
        public static WebApplicationBuilder AddAutoCacheConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddMemoryCache();
            

            return builder;
        }
    }
}