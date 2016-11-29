using Our.Umbraco.Ditto;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace SampleFramework.Domain.DittoProcessors
{
    public class ContentKeyProcessor : DittoProcessorAttribute
    {
        public override object ProcessValue()
        {
            var content = Value as IPublishedContent;
            return content?.GetKey();
        }
    }
}