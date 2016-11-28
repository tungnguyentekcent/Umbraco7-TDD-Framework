using SampleFramework.Services.Interfaces;
using SampleFramework.Services.Wrappers;

namespace SampleFramework.Services.Factories
{
    public class PublishedContentExtensionsWrapperFactory : IPublishedContentExtensionsWrapperFactory
    {
        public IPublishedContentExtensionsWrapper GetPublishedContentExtensionsWrapper(IUmbracoContextFactory umbracoContextFactory,
            IUmbracoHelperFactory umbracoHelperFactory)
        {
            return new PublishedContentExtensionsWrapper(umbracoContextFactory, umbracoHelperFactory);
        }
    }
}
