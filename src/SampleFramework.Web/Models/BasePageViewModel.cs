namespace SampleFramework.Web.Models
{
    public class BasePageViewModel : BaseViewModel
    {
        public MetaDataViewModel MetaData { get; set; }

        public string Headline { get; set; }

        public string NiceUrl { get; set; }
    }
}
