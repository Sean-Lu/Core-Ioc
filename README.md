## 简介

> 通过DI（依赖注入）实现IOC，核心类：`IocContainer`

## Packages

| Package | NuGet Stable | NuGet Pre-release | Downloads |
| ------- | ------------ | ----------------- | --------- |
| [Sean.Core.Ioc](https://www.nuget.org/packages/Sean.Core.Ioc/) | [![Sean.Core.Ioc](https://img.shields.io/nuget/v/Sean.Core.Ioc.svg)](https://www.nuget.org/packages/Sean.Core.Ioc/) | [![Sean.Core.Ioc](https://img.shields.io/nuget/vpre/Sean.Core.Ioc.svg)](https://www.nuget.org/packages/Sean.Core.Ioc/) | [![Sean.Core.Ioc](https://img.shields.io/nuget/dt/Sean.Core.Ioc.svg)](https://www.nuget.org/packages/Sean.Core.Ioc/) |

## Nuget包引用

> **Id：Sean.Core.Ioc**

- Package Manager

```
PM> Install-Package Sean.Core.Ioc
```

## 使用示例

> 项目：examples\Example.NetCore

```c#
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
```
