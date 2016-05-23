namespace Core.Configuration
{
    public interface IConfigurationFinder
    {
        T FindFromConfig<T>(System.Configuration.Configuration configuration);
    }
}
