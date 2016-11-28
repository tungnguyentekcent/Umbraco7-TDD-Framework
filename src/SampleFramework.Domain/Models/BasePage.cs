using Our.Umbraco.Ditto;

namespace SampleFramework.Domain.Models
{
    public class BasePage : BaseModel
    {
        [CurrentContentAs]
        public MetaData MetaData { get; set; }

        public string Headline { get; set; }

        public string NiceUrl { get; set; }
    }
}
