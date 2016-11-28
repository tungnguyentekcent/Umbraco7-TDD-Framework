namespace SampleFramework.Services.Interfaces
{
    public interface IPublishedContentExtensionsWrapperFactory
    {
        IPublishedContentExtensionsWrapper GetPublishedContentExtensionsWrapper(
            IUmbracoContextFactory umbracoContextFactory, IUmbracoHelperFactory umbracoHelperFactory);
    }
}
