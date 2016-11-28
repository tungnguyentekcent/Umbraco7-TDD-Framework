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
        
        public T GetPageModel<T>(string docTypeAlias) where T : BasePage
        {
            var pageNode = QueryFactory.GetCurrentNode();

            if (pageNode.NodeTypeAlias != docTypeAlias)
            {
                pageNode = QueryFactory.GetFirstNodeOfType(docTypeAlias);
            }

            if (pageNode == null)
            {
                throw new NullReferenceException($"Page with {docTypeAlias} document type is NOT available.");
            }

            return PublishedContentExtensionsWrapper.As<T>(pageNode.Id);
        }
    }
}
