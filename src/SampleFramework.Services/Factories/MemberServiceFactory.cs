using SampleFramework.Services.Interfaces;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Factories
{
    public class MemberServiceFactory : IMemberServiceFactory
    {
        public IMemberService GetMemberService(PluginController controller)
        {
            return controller.Services.MemberService;
        }
    }
}
