using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sean.Core.Ioc.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, Action<IServiceCollection> configServices = null)
        {
            IocContainer.Instance.ConfigureServices(services, configServices);
        }
    }
}
