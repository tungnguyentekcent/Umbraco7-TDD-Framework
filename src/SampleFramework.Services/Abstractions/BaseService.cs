using SampleFramework.Services.Interfaces;
using umbraco.interfaces;

namespace SampleFramework.Services.Abstractions
{
    public abstract class BaseService
    {
        private readonly IQueryFactory _queryFactory;
        private readonly IUmbracoContextFactory _umbracoContextFactory;
        private readonly IUmbracoHelperFactory _umbracoHelperFactory;
        private readonly IPublishedContentExtensionsWrapperFactory _publishedContentExtensionsWrapperFactory;

        protected BaseService(IQueryFactory queryFactory, IUmbracoContextFactory umbracoContextFactory,
            IUmbracoHelperFactory umbracoHelperFactory,
            IPublishedContentExtensionsWrapperFactory publishedContentExtensionsWrapperFactory)
        {
            _queryFactory = queryFactory;
            _umbracoContextFactory = umbracoContextFactory;
            _umbracoHelperFactory = umbracoHelperFactory;
            _publishedContentExtensionsWrapperFactory = publishedContentExtensionsWrapperFactory;
        }

        protected IPublishedContentExtensionsWrapper PublishedContentExtensionsWrapper
            =>
                _publishedContentExtensionsWrapperFactory.GetPublishedContentExtensionsWrapper(_umbracoContextFactory,
                    _umbracoHelperFactory);

        protected INode HomeNode => _queryFactory.GetHomeNode();
    }
}
