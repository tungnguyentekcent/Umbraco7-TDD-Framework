using SampleFramework.Services.Interfaces;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Factories
{
    public class ContentServiceFactory : IContentServiceFactory
    {
        public IContentService GetContentService(PluginController controller)
        {
            return controller.Services.ContentService;
        }
    }
}
