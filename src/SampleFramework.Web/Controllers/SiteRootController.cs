using SampleFramework.Services.Interfaces;

namespace SampleFramework.Web.Controllers
{
    public class SiteRootController : HomePageController
    {
        public SiteRootController()
        {
        }

        public SiteRootController(IApplicationService applicationService)
            : base(applicationService)
        {
        }
    }
}