using System;
using SampleFramework.Domain.Models;
using SampleFramework.Services.Abstractions;
using SampleFramework.Services.Interfaces;

namespace SampleFramework.Services
{
    public class ApplicationService : BaseService, IApplicationService
    {
        public ApplicationService(IQueryFactory queryFactory, IUmbracoContextFactory umbracoContextFactory,
            IUmbracoHelperFactory umbracoHelperFactory,
            IPublishedContentExtensionsWrapperFactory publishedContentExtensionsWrapperFactory)
            : base(queryFactory, umbracoContextFactory, umbracoHelperFactory, publishedContentExtensionsWrapperFactory)
        {
        }

        public HomePage GetHomePage()
        {
            if (HomeNode == null)
            {
                throw new NullReferenceException("Home Page is NOT available.");
            }

            return PublishedContentExtensionsWrapper.As<HomePage>(HomeNode.Id);
        }
    }
}
