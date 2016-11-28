using Moq;
using NUnit.Framework;
using SampleFramework.Web.App_Start;
using Umbraco.Core.Models;
using Umbraco.Tests.TestHelpers;

namespace SampleFramework.Web.Tests.Abstractions
{
    public abstract class BaseControllerTests : BaseRoutingTest
    {
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfig.RegisterAutoMapper();

            GetRoutingContext("/test", 1234, setUmbracoContextCurrent: true);
        }

        protected static IPublishedContent MockIPublishedContent()
        {
            var mock = new Mock<IPublishedContent>();
            mock.Setup(x => x.Id).Returns(CurrentPageId);
            return mock.Object;
        }

        protected static int CurrentPageId => 1000;
    }
}
