using System;
using Demo.NetCore.Contracts;

namespace Demo.NetCore.Impls
{
    public class TestService : ITestService
    {
        public void Do(string content)
        {
            Console.WriteLine(content);
        }
    }
    public class TestService<T> : ITestService<T>
    {
        public void Do(T content)
        {
            Console.WriteLine(content);
        }
    }
}
