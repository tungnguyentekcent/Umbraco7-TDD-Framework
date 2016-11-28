using Moq;
using NUnit.Framework;
using SampleFramework.Domain.Models;
using SampleFramework.Services.Tests.Abstractions;
using umbraco.interfaces;

namespace SampleFramework.Services.Tests
{
    [TestFixture]
    public class ApplicationServiceTests : BaseServiceTests
    {
        [Test]
        public void GetHomePage_ReturnsHomePage()
        {
            // Arrange
            const int MockHomePageId = 1;

            var applicationService = new ApplicationService(MockQueryFactory.Object, MockUmbracoContextFactory.Object,
                MockUmbracoHelperFactory.Object,
                MockPublishedContentExtensionsWrapperFactory.Object);

            var mockHomeNode = new Mock<INode>();
            mockHomeNode.Setup(x => x.Id).Returns(MockHomePageId);
            MockQueryFactory.Setup(x => x.GetHomeNode()).Returns(mockHomeNode.Object);

            var homePage = new HomePage { Id = MockHomePageId };
            MockPublishedContentExtensionsWrapper.Setup(x => x.As<HomePage>(homePage.Id)).Returns(homePage);

            // Act
            var result = applicationService.GetHomePage();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(homePage, result);
        }
    }
}
