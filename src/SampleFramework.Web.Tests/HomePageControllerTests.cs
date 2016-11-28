using System.Web.Mvc;
using NUnit.Framework;
using SampleFramework.Domain.Models;
using SampleFramework.Services;
using SampleFramework.Shared.Constants;
using SampleFramework.Web.Controllers;
using SampleFramework.Web.Models;
using SampleFramework.Web.Tests.Abstractions;

namespace SampleFramework.Web.Tests
{
    [TestFixture]
    public class HomePageControllerTests : BaseControllerTests
    {
        [Test]
        public void CanInitializeHomePageController()
        {
            Assert.IsNotNull(new HomePageController());
        }

        [Test]
        public void Index_Get_ReturnsHomePageViewModel()
        {
            // Arrange
            const int homePageId = 1;

            var controller = new HomePageController
            {
                ApplicationService = ApplicationServiceMock.Object,
                MapModelService = new MapModelService()
            };

            var homePage = new HomePage { Id = homePageId };
            ApplicationServiceMock.Setup(x => x.GetPageModel<HomePage>(DocTypeAliases.HomePage.Alias)).Returns(homePage);

            var homePageViewModel = controller.MapModelService.Map<HomePageViewModel>(homePage);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<HomePageViewModel>(result.Model);
            Assert.AreEqual(homePageViewModel.Id, ((HomePageViewModel)result.Model).Id);
        }
    }
}
