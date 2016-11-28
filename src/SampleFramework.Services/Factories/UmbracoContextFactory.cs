using SampleFramework.Services.Interfaces;
using Umbraco.Web;

namespace SampleFramework.Services.Factories
{
    public class UmbracoContextFactory : IUmbracoContextFactory
    {
        public UmbracoContext GetUmbracoContext()
        {
            return UmbracoContext.Current;
        }
    }
}
