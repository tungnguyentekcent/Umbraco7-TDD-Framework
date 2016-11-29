using Umbraco.Web;

namespace SampleFramework.Services.Interfaces
{
    public interface IUmbracoContextFactory
    {
        UmbracoContext GetUmbracoContext();
    }
}
