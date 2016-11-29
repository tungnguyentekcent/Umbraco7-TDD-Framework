using System.Collections.Generic;
using SampleFramework.Domain.Models;
using SampleFramework.Shared.Constants;

namespace SampleFramework.Web.ApiControllers
{
    public class NewsletterApiController : BaseUmbracoApiController
    {
        public IEnumerable<Newsletter> GetNewsletters()
        {
            var newsletterFolder =
                ApplicationService.GetPageModel<NewsletterFolder>(DocTypeAliases.NewsletterFolder.Alias);

            return newsletterFolder.Newsletters;
        }
    }
}