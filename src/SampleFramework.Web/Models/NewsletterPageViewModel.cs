using System.ComponentModel.DataAnnotations;

namespace SampleFramework.Web.Models
{
    public class NewsletterPageViewModel : BasePageViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}