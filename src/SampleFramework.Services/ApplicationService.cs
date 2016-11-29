using System;
using SampleFramework.Domain.Models;
using SampleFramework.Services.Abstractions;
using SampleFramework.Services.Interfaces;
using umbraco.interfaces;

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
        
        public T GetPageModel<T>(string docTypeAlias) where T : BaseModel
        {
            var pageNode = QueryFactory.GetCurrentNode();

            if (pageNode == null || pageNode.NodeTypeAlias != docTypeAlias)
            {
                pageNode = QueryFactory.GetFirstNodeOfType(docTypeAlias);
            }

            if (pageNode == null)
            {
                throw new NullReferenceException($"Page with Document Type: [{docTypeAlias}] is NOT available.");
            }

            return PublishedContentExtensionsWrapper.As<T>(pageNode.Id);
        }

        public INode GetNode(string docTypeAlias)
        {
            var node = QueryFactory.GetFirstNodeOfType(docTypeAlias);
            if (node == null)
            {
                throw new NullReferenceException(
                    $"The requested Node with Document Type: [{docTypeAlias}] is NOT available.");
            }

            return node;
        }
    }
}
