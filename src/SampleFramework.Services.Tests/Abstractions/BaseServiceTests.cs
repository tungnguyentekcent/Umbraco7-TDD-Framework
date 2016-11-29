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

            UmbracoContextFactoryMock = new Mock<IUmbracoContextFactory>();
            UmbracoContextFactoryMock.Setup(x => x.GetUmbracoContext()).Returns(UmbracoContext);


            UmbracoHelperFactoryMock = new Mock<IUmbracoHelperFactory>();
            UmbracoHelperFactoryMock.Setup(x => x.GetUmbracoHelper(UmbracoContext))
                .Returns(UmbracoHelper);

            QueryFactoryMock = new Mock<IQueryFactory>();

            PublishedContentExtensionsWrapperMock = new Mock<IPublishedContentExtensionsWrapper>();

            PublishedContentExtensionsWrapperFactoryMock = new Mock<IPublishedContentExtensionsWrapperFactory>();
            PublishedContentExtensionsWrapperFactoryMock.Setup(
                x =>
                    x.GetPublishedContentExtensionsWrapper(UmbracoContextFactoryMock.Object,
                        UmbracoHelperFactoryMock.Object)).Returns(PublishedContentExtensionsWrapperMock.Object);
        }

        protected UmbracoContext UmbracoContext { get; set; }

        protected UmbracoHelper UmbracoHelper { get; set; }
        
        protected Mock<IUmbracoHelperFactory> UmbracoHelperFactoryMock { get; set; }

        protected Mock<IUmbracoContextFactory> UmbracoContextFactoryMock { get; set; }

        protected Mock<IQueryFactory> QueryFactoryMock { get; set; }

        protected Mock<IPublishedContentExtensionsWrapperFactory> PublishedContentExtensionsWrapperFactoryMock { get; set; }

        protected Mock<IPublishedContentExtensionsWrapper> PublishedContentExtensionsWrapperMock { get; set; }
    }
}
