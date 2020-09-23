using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sean.Core.Ioc.Extensions
{
    public static class ServiceExtensions
    {
        public static void InitIoc(this IServiceCollection services, Action<IServiceCollection> configServices = null)
        {
            ServiceManager.ConfigureServices(services, configServices);
        }
    }
}
