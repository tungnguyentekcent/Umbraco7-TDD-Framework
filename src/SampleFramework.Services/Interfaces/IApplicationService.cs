using SampleFramework.Domain.Models;

namespace SampleFramework.Services.Interfaces
{
    public interface IApplicationService
    {
        T GetPageModel<T>(string docTypeAlias) where T : BasePage;

        T GetModelOfCurrentPage<T>(string docTypeAlias) where T : BasePage;
    }
}
