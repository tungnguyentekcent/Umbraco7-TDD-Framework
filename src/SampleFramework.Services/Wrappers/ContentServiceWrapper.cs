using SampleFramework.Services.Interfaces;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Wrappers
{
    public class ContentServiceWrapper : IContentServiceWrapper
    {
        private readonly IContentService _contentService;

        public ContentServiceWrapper(PluginController controller)
        {
            _contentService = controller.Services.ContentService;
        }

        public IContent CreateContent(string name, int parentId, string contentTypeAlias, int userId = 0)
        {
            return _contentService.CreateContent(name, parentId, contentTypeAlias, userId);
        }

        public void Save(IContent content, int userId = 0, bool raiseEvents = true)
        {
            _contentService.Save(content, userId, raiseEvents);
        }
    }
}
