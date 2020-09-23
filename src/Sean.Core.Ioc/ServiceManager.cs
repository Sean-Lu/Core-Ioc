using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sean.Core.Ioc
{
    /// <summary>
    /// IOC：DI（依赖注入）
    /// </summary>
    public class ServiceManager
    {
        /// <summary>
        /// IOC容器
        /// </summary>
        private static IServiceCollection _serviceCollection;
        /// <summary>
        /// 服务提供者
        /// </summary>
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            _serviceCollection = services ?? throw new ArgumentNullException(nameof(services));
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configServices"></param>
        public static void ConfigureServices(IServiceCollection services, Action<IServiceCollection> configServices)
        {
            _serviceCollection = services ?? throw new ArgumentNullException(nameof(services));

            ConfigureServices(configServices);
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="configServices"></param>
        public static void ConfigureServices(Action<IServiceCollection> configServices)
        {
            if (_serviceCollection == null)
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", true)
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
        public static T GetService<T>()
        {
            if (_serviceProvider == null)
            {
                throw new InvalidOperationException($"Before executing this method, please execute the {nameof(ConfigureServices)} method.");
            }

            return _serviceProvider.GetService<T>();
        }
    }
}
