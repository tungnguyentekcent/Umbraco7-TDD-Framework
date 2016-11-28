using SampleFramework.Services.Interfaces;
using SampleFramework.Services.Wrappers;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Factories
{
    public class MembershipHelperFactory: IMembershipHelperFactory
    {
        public IMembershipHelperWrapper GetMembershipHelperWrapper(PluginController controller)
        {
            return new MembershipHelperWrapper(controller);
        }

        public IMembershipHelperWrapper GetMembershipHelperWrapper(UmbracoController controller)
        {
            return new MembershipHelperWrapper(controller);
        }
    }
}
