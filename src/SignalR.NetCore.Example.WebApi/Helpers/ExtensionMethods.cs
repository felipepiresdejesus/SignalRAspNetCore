using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace SignalR.NetCore.Example.WebApi.Helpers
{
    public static class ExtensionMethods
    {
        public static void ConfigureCaseSignalR(this IServiceCollection services)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new SignalRContractResolver()
            };

            var serviceDescriptor = new ServiceDescriptor(typeof(JsonSerializer),
                provider => JsonSerializer.Create(settings),
                ServiceLifetime.Transient);

            services.Add(serviceDescriptor);
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("corsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
        }
    }
}
