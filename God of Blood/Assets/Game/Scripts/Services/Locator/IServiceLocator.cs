namespace Services.Locator
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}