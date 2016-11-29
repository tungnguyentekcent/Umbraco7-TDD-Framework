using Umbraco.Web;

namespace SampleFramework.Services.Interfaces
{
    public interface IUmbracoHelperFactory
    {
        UmbracoHelper GetUmbracoHelper(UmbracoContext umbracoContext);
    }
}
