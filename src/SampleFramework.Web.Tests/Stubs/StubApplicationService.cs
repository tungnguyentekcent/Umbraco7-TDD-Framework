using SampleFramework.Domain.Models;
using SampleFramework.Services.Interfaces;

namespace SampleFramework.Web.Tests.Stubs
{
    public class StubApplicationService : IApplicationService
    {
        public HomePage GetHomePage()
        {
            var homePage = new HomePage { Id = 1 };
            return homePage;
        }
    }
}
