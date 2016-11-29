using Umbraco.Web;

namespace SampleFramework.Services.Interfaces
{
    public interface IPublishedContentExtensionsWrapper
    {
        T As<T>(int id) where T : class;
    }
}
