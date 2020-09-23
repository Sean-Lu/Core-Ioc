namespace Demo.NetCore.Contracts
{
    public interface ITestService
    {
        void Do(string content);
    }

    public interface ITestService<T>
    {
        void Do(T content);
    }
}
