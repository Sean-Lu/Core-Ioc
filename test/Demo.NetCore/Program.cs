using System;
using Demo.NetCore.Contracts;
using Demo.NetCore.Impls;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sean.Core.Ioc;

namespace Demo.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 配置服务（DI依赖注入）
            ServiceManager.ConfigureServices(services =>
            {
                services.AddTransient<ITestService, TestService>();
                services.AddTransient(typeof(ITestService<>), typeof(TestService<>));
            });

            // 2. 获取服务
            var configuration = ServiceManager.GetService<IConfiguration>();
            var testService = ServiceManager.GetService<ITestService>();
            var testService2 = ServiceManager.GetService<ITestService<string>>();

            // 3. 使用服务
            var endPoint = configuration.GetValue("Redis:endPoints", string.Empty);
            var pwd = configuration.GetValue("Redis:pwd", string.Empty);
            testService.Do(endPoint);
            testService2.Do(endPoint);

            Console.ReadLine();
        }
    }
}
