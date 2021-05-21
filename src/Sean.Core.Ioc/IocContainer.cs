using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sean.Core.Ioc
{
    /// <summary>
    /// IOC: Dependency Injection
    /// </summary>
    public class IocContainer
    {
        private IocContainer()
        {
        }

        public static IocContainer Instance { get; } = new IocContainer();

        public IServiceCollection ServiceCollection => _serviceCollection;
        public IServiceProvider ServiceProvider => _serviceProvider;

        /// <summary>
        /// IOC容器
        /// </summary>
        private IServiceCollection _serviceCollection;
        /// <summary>
        /// 服务提供者
        /// </summary>
        private IServiceProvider _serviceProvider;

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configServices"></param>
        public void ConfigureServices(IServiceCollection services, Action<IServiceCollection> configServices = null)
        {
            _serviceCollection = services ?? throw new ArgumentNullException(nameof(services));

            ConfigureServices(configServices);
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="configServices"></param>
        public void ConfigureServices(Action<IServiceCollection> configServices)
        {
            if (_serviceCollection == null)
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddEnvironmentVariables();
                var configuration = configurationBuilder.Build();

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(configuration);

                _serviceCollection = services;
            }

            configServices?.Invoke(_serviceCollection);

            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>()
        {
            return _serviceProvider != null ? _serviceProvider.GetService<T>() : default;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetRequiredService<T>()
        {
            return _serviceProvider != null ? _serviceProvider.GetRequiredService<T>() : default;
        }
    }
}
