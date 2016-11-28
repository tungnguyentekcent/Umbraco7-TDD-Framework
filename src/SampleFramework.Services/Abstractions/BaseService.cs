using SampleFramework.Services.Interfaces;

namespace SampleFramework.Services.Abstractions
{
    public abstract class BaseService
    {
        protected IQueryFactory QueryFactory { get; }
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IUmbracoHelperFactory _umbracoHelperFactory;
        private readonly IPublishedContentExtensionsWrapperFactory _publishedContentExtensionsWrapperFactory;

        protected BaseService(IQueryFactory queryFactory, IUmbracoContextFactory umbracoContextFactory,
            IUmbracoHelperFactory umbracoHelperFactory,
            IPublishedContentExtensionsWrapperFactory publishedContentExtensionsWrapperFactory)
        {
            QueryFactory = queryFactory;
            _umbracoContextFactory = umbracoContextFactory;
            _umbracoHelperFactory = umbracoHelperFactory;
            _publishedContentExtensionsWrapperFactory = publishedContentExtensionsWrapperFactory;
        }

        protected IPublishedContentExtensionsWrapper PublishedContentExtensionsWrapper
            =>
                _publishedContentExtensionsWrapperFactory.GetPublishedContentExtensionsWrapper(_umbracoContextFactory,
                    _umbracoHelperFactory);
    }
}
