using POC.Infra.CrossCutting.IoC;

namespace POC.SERVICE.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            NativeInjectionBootStrapper.RegisterServices(builder);

            return builder;
        }
    }
}
