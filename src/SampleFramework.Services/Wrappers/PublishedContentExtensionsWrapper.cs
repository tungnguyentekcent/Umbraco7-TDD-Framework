using Our.Umbraco.Ditto;
using SampleFramework.Services.Interfaces;
using Umbraco.Web;

namespace SampleFramework.Services.Wrappers
{
    public class PublishedContentExtensionsWrapper : IPublishedContentExtensionsWrapper
    {
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IUmbracoHelperFactory _umbracoHelperFactory;

        public PublishedContentExtensionsWrapper(IUmbracoContextFactory umbracoContextFactory,
            IUmbracoHelperFactory umbracoHelperFactory)
        {
            _umbracoHelperFactory = umbracoHelperFactory;
            _umbracoContextFactory = umbracoContextFactory;
        }

        public T As<T>(int id) where T : class
        {
            return UmbracoHelper.TypedContent(id).As<T>();
        }

        public UmbracoContext UmbracoContext => _umbracoContextFactory.GetUmbracoContext();

        public UmbracoHelper UmbracoHelper => _umbracoHelperFactory.GetUmbracoHelper(UmbracoContext);
    }
}
