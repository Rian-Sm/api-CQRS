using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.SERVICE.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static WebApplicationBuilder AddAutoMapperConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }
}