using Moq;
using NUnit.Framework;
using SampleFramework.Services.Interfaces;
using Umbraco.Tests.TestHelpers;
using Umbraco.Web;

namespace SampleFramework.Services.Tests.Abstractions
{
    public abstract class BaseServiceTests : BaseRoutingTest
    {
        [SetUp]
        public void Setup()
        {
            UmbracoContext = GetRoutingContext("/test").UmbracoContext;
            UmbracoHelper = new UmbracoHelper(UmbracoContext);

            MockUmbracoContextFactory = new Mock<IUmbracoContextFactory>();
            MockUmbracoContextFactory.Setup(x => x.GetUmbracoContext()).Returns(UmbracoContext);


            MockUmbracoHelperFactory = new Mock<IUmbracoHelperFactory>();
            MockUmbracoHelperFactory.Setup(x => x.GetUmbracoHelper(UmbracoContext))
                .Returns(UmbracoHelper);

            MockQueryFactory = new Mock<IQueryFactory>();

            MockPublishedContentExtensionsWrapper = new Mock<IPublishedContentExtensionsWrapper>();

            MockPublishedContentExtensionsWrapperFactory = new Mock<IPublishedContentExtensionsWrapperFactory>();
            MockPublishedContentExtensionsWrapperFactory.Setup(
                x =>
                    x.GetPublishedContentExtensionsWrapper(MockUmbracoContextFactory.Object,
                        MockUmbracoHelperFactory.Object)).Returns(MockPublishedContentExtensionsWrapper.Object);
        }

        protected UmbracoContext UmbracoContext { get; set; }

        protected UmbracoHelper UmbracoHelper { get; set; }



        protected Mock<IUmbracoHelperFactory> MockUmbracoHelperFactory { get; set; }

        protected Mock<IUmbracoContextFactory> MockUmbracoContextFactory { get; set; }

        protected Mock<IQueryFactory> MockQueryFactory { get; set; }

        protected Mock<IPublishedContentExtensionsWrapperFactory> MockPublishedContentExtensionsWrapperFactory { get; set; }

        protected Mock<IPublishedContentExtensionsWrapper> MockPublishedContentExtensionsWrapper { get; set; }
    }
}
