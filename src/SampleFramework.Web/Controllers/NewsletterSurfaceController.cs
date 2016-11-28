using System.Web.Mvc;
using SampleFramework.Services.Interfaces;
using SampleFramework.Shared.Constants;
using SampleFramework.Web.Models;
using Umbraco.Web;

namespace SampleFramework.Web.Controllers
{
    public class NewsletterSurfaceController : BaseSurfaceController
    {
        public IApplicationService ApplicationService { get; set; }

        public NewsletterSurfaceController()
        {
        }

        public NewsletterSurfaceController(UmbracoContext umbracoContext) : base(umbracoContext)
        {
        }

        public NewsletterSurfaceController(UmbracoContext umbracoContext, UmbracoHelper umbracoHelper)
            : base(umbracoContext, umbracoHelper)
        {
        }

        public ActionResult Subscribe(string email)
        {
            const string successKey = "success";

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            
            var newsletterFolder = ApplicationService.GetNode(DocTypeAliases.NewsletterFolder.Alias);

            var contentService = ContentServiceFactory.GetContentService(this);

            var content = contentService.CreateContent(email, newsletterFolder.Id,
                DocTypeAliases.Newsletter.Alias);

            content.SetValue(DocTypeAliases.Newsletter.Properties.Email, email);

            contentService.Save(content);

            TempData[successKey] = true;

            return RedirectToCurrentUmbracoPage();
        }
    }
}