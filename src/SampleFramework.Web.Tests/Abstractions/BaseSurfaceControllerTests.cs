using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using SampleFramework.Services.Interfaces;
using SampleFramework.Web.Controllers;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.Routing;

namespace SampleFramework.Web.Tests.Abstractions
{
    public abstract class BaseSurfaceControllerTests : BaseControllerTests
    {
        protected Mock<IMemberServiceFactory> MemberServiceFactoryMock { get; set; }
        protected Mock<IMembershipHelperFactory> MembershipHelperFactoryMock { get; set; }
        protected Mock<IContentServiceFactory> ContentServiceFactoryMock { get; set; }
        protected Mock<IMemberService> MemberServiceMock { get; set; }
        protected Mock<IMembershipHelperWrapper> MembershipHelperWrapperMock { get; set; }
        protected Mock<IContentService> ContentServiceMock { get; set; }

        public override void SetUp()
        {
            base.SetUp();

            MemberServiceFactoryMock = new Mock<IMemberServiceFactory>();
            MembershipHelperFactoryMock = new Mock<IMembershipHelperFactory>();
            ContentServiceFactoryMock = new Mock<IContentServiceFactory>();
            MemberServiceMock = new Mock<IMemberService>();
            MembershipHelperWrapperMock = new Mock<IMembershipHelperWrapper>();
            ContentServiceMock = new Mock<IContentService>();

            MemberServiceFactoryMock.Setup(x => x.GetMemberService(It.IsAny<BaseSurfaceController>()))
                .Returns(MemberServiceMock.Object);
            MembershipHelperFactoryMock.Setup(x => x.GetMembershipHelperWrapper(It.IsAny<BaseSurfaceController>()))
                .Returns(MembershipHelperWrapperMock.Object);
            ContentServiceFactoryMock.Setup(x => x.GetContentService(It.IsAny<BaseSurfaceController>()))
                .Returns(ContentServiceMock.Object);
        }

        /// <summary>
        /// This function was got from: http://126kr.com/article/7ksi7oqf239
        /// To mock the Umbraco context in order to test method calls that require Umbraco context.
        /// Ex: RedirectToCurrentUmbracoPage(), CurrentPage.Id
        /// </summary>
        /// <returns></returns>
        protected static void SetupControllerContext(UmbracoContext umbCtx, Controller controller)
        {
            var webRoutingSettings = Mock.Of<IWebRoutingSection>(section => section.UrlProviderMode == "AutoLegacy");
            var contextBase = umbCtx.HttpContext;
            var pcr = new PublishedContentRequest(new Uri("http://localhost/test"),
                umbCtx.RoutingContext,
                webRoutingSettings,
                s => Enumerable.Empty<string>())
            {
                PublishedContent = MockIPublishedContent()
            };

            var routeData = new RouteData();
            var routeDefinition = new RouteDefinition
            {
                PublishedContentRequest = pcr
            };

            routeData.DataTokens.Add("umbraco-route-def", routeDefinition);
            controller.ControllerContext = new ControllerContext(contextBase, routeData, controller);
        }
    }
}
