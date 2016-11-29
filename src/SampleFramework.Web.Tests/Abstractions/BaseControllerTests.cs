using Moq;
using NUnit.Framework;
using SampleFramework.Services.Interfaces;
using SampleFramework.Web.App_Start;
using Umbraco.Core.Models;
using Umbraco.Tests.TestHelpers;
using Umbraco.Web.Routing;

namespace SampleFramework.Web.Tests.Abstractions
{
    public abstract class BaseControllerTests : BaseRoutingTest
    {
        protected static int CurrentPageId => 1000;

        protected Mock<IApplicationService> ApplicationServiceMock { get; set; }

        public RoutingContext RoutingContext { get; set; }

        [SetUp]
        public virtual void SetUp()
        {
            AutoMapperConfig.RegisterAutoMapper();

            RoutingContext = GetRoutingContext("/test", 1234, setUmbracoContextCurrent: true);

            ApplicationServiceMock = new Mock<IApplicationService>();
        }

        protected static IPublishedContent MockIPublishedContent()
        {
            var mock = new Mock<IPublishedContent>();
            mock.Setup(x => x.Id).Returns(CurrentPageId);
            return mock.Object;
        }
    }
}
