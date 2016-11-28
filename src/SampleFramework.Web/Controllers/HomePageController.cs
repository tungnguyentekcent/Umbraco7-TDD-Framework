using System.Web.Mvc;
using SampleFramework.Services.Interfaces;
using SampleFramework.Web.Models;

namespace SampleFramework.Web.Controllers
{
    public class HomePageController : BaseController
    {
        public HomePageController()
        { }

        public HomePageController(IApplicationService applicationService)
        {
            ApplicationService = applicationService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var homePage = ApplicationService.GetHomePage();
            return View("HomePage", MapModelService.Map<HomePageViewModel>(homePage));
        }
        protected IApplicationService ApplicationService { get; set; }
    }
}