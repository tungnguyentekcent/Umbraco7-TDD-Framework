using SampleFramework.Services.Interfaces;
using Umbraco.Web;

namespace SampleFramework.Services.Factories
{
    public class UmbracoHelperFactory : IUmbracoHelperFactory
    {
        public UmbracoHelper GetUmbracoHelper(UmbracoContext umbracoContext)
        {
            return new UmbracoHelper(umbracoContext);
        }
    }
}
