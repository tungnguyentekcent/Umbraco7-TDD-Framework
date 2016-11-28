using SampleFramework.Domain.Models;
using SampleFramework.Services.Interfaces;

namespace SampleFramework.Web.Tests.Stubs
{
    public class StubApplicationService : IApplicationService
    {
        public T GetPageModel<T>(string docTypeAlias) where T : BasePage
        {
            throw new System.NotImplementedException();
        }

        public T GetModelOfCurrentPage<T>(string docTypeAlias) where T : BasePage
        {
            throw new System.NotImplementedException();
        }
    }
}
