using SampleFramework.Services.Interfaces;
using Umbraco.Web.Mvc;

namespace SampleFramework.Web.Controllers
{
    public class BaseController : RenderMvcController
    {
        public IMapModelService MapModelService { get; set; }
    }
}