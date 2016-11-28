using System.Web.Mvc;
using SampleFramework.Domain.Models;
using SampleFramework.Shared.Constants;
using SampleFramework.Web.Models;

namespace SampleFramework.Web.Controllers
{
    public class HomePageController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var homePage = ApplicationService.GetPageModel<HomePage>(DocTypeAliases.HomePage.Alias);
            return View("HomePage", MapModelService.Map<HomePageViewModel>(homePage));
        }
    }
}