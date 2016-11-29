using Moq;
using NUnit.Framework;
using SampleFramework.Shared.Constants;
using SampleFramework.Web.SurfaceControllers;
using SampleFramework.Web.Tests.Abstractions;
using umbraco.interfaces;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace SampleFramework.Web.Tests
{
    [TestFixture]
    public class NewsletterSurfaceControllerTests : BaseSurfaceControllerTests
    {
        [Test]
        public void Subscribe_PostEmail_CreatesContentNodeInUmbracoAndRedirectsToCurrentUmbracoPageWithTempData()
        {
            // Arrange
            const string successKey = "success";
            const int newsletterFolderId = 1;
            const string submittedEmail = "test@test.com";

            var umbCtx = RoutingContext.UmbracoContext;
            var controller = new NewsletterSurfaceController(umbCtx, new UmbracoHelper(umbCtx));
            SetupControllerContext(umbCtx, controller);
            
            var mockNewsletterFolderNode = new Mock<INode>();
            mockNewsletterFolderNode.Setup(x => x.Id).Returns(newsletterFolderId);
            ApplicationServiceMock.Setup(x => x.GetNode(DocTypeAliases.NewsletterFolder.Alias))
                .Returns(mockNewsletterFolderNode.Object);

            var mockContent = new Mock<IContent>();
            ContentServiceMock.Setup(
                x =>
                    x.CreateContent(submittedEmail, mockNewsletterFolderNode.Object.Id,
                        DocTypeAliases.Newsletter.Alias, 0)).Returns(mockContent.Object);

            controller.ApplicationService = ApplicationServiceMock.Object;
            controller.ContentServiceFactory = ContentServiceFactoryMock.Object;

            // Act
            var result = controller.Subscribe(submittedEmail) as RedirectToUmbracoPageResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(controller.TempData[successKey]);
            ContentServiceMock.Verify(
                x =>
                    x.CreateContent(submittedEmail, mockNewsletterFolderNode.Object.Id,
                        DocTypeAliases.Newsletter.Alias, 0), Times.Once);
            mockContent.Verify(x => x.SetValue(DocTypeAliases.Newsletter.Properties.Email, submittedEmail), Times.Once);
            ContentServiceMock.Verify(x => x.SaveAndPublishWithStatus(mockContent.Object, 0, true), Times.Once);
        }
    }
}
