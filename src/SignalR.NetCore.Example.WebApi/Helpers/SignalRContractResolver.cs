using System;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace SignalR.NetCore.Example.WebApi.Helpers
{
    public class SignalRContractResolver : IContractResolver
    {
        public JsonContract ResolveContract(Type type)
        {
            var signalRAssembly = typeof(Microsoft.AspNetCore.SignalR.Infrastructure.Connection).GetTypeInfo().Assembly;

            if (type.GetTypeInfo().Assembly.Equals(signalRAssembly))
            {
                var defaultContractSerializer = new DefaultContractResolver();
                return defaultContractSerializer.ResolveContract(type);
            }
            else
            {
                var camelCaseContractResolver = new CamelCasePropertyNamesContractResolver();
                return camelCaseContractResolver.ResolveContract(type);
            }
        }
    }
}
