using System.Web.Mvc;
using NUnit.Framework;
using SampleFramework.Services;
using SampleFramework.Web.Controllers;
using SampleFramework.Web.Models;
using SampleFramework.Web.Tests.Abstractions;
using SampleFramework.Web.Tests.Stubs;

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

            var applicationService = new StubApplicationService();
            var controller = new HomePageController(applicationService);
            controller.MapModelService = new MapModelService();

            var homePage = applicationService.GetHomePage();

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
