using System.Reflection;

namespace POC.SERVICE.API.Configurations
{
    public static class MediatRConfig
    {
        public static WebApplicationBuilder AddMediatRConfiguration(this WebApplicationBuilder builder){
            
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); 

            return builder;
        }
    }
}