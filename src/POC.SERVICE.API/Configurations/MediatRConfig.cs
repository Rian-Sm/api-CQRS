using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace POC.SERVICE.API.Configurations
{
    public static class MediatRConfig
    {
        public static WebApplicationBuilder AddMediatRConfiguration(this WebApplicationBuilder builder){
            
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            return builder;
        }
    }
}