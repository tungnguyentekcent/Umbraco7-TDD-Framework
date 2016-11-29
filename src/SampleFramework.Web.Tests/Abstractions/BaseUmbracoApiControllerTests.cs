using Moq;
using NUnit.Framework;
using SampleFramework.Services.Interfaces;

namespace SampleFramework.Web.Tests.Abstractions
{
    public abstract class BaseUmbracoApiControllerTests : BaseControllerTests
    {
        protected Mock<IPublishedContentExtensionsWrapper> MockPublishedContentExtensionsWrapper { get; set; }

        protected Mock<IContentSearchService> MockContentSearchService { get; set; }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            MockPublishedContentExtensionsWrapper = new Mock<IPublishedContentExtensionsWrapper>();
            MockContentSearchService = new Mock<IContentSearchService>();
        }
    }
}
