using System;
using Example.NetCore.Contracts;
using Example.NetCore.Impls;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sean.Core.Ioc;

namespace Example.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 配置服务（依赖注入）
            IocContainer.Instance.ConfigureServices(services =>
            {
                services.AddTransient<ITestService, TestService>();
            });

            // 2. 获取服务
            var configuration = IocContainer.Instance.GetService<IConfiguration>();
            var testService = IocContainer.Instance.GetService<ITestService>();

            // 3. 使用服务
            testService.Execute("测试内容");

            Console.ReadLine();
        }
    }
}
