using System;
using Example.NetCore.Contracts;

namespace Example.NetCore.Impls
{
    public class TestService : ITestService
    {
        public void Execute(string content)
        {
            Console.WriteLine(content);
        }
    }
}
