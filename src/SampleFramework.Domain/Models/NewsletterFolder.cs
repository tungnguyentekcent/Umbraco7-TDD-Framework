using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Our.Umbraco.Ditto;

namespace SampleFramework.Domain.Models
{
    public class NewsletterFolder : BaseModel
    {
        [UmbracoProperty("children")]
        public IEnumerable<Newsletter> Newsletters { get; set; }
    }
}
