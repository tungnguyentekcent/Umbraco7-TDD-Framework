using SampleFramework.Services.Interfaces;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;

namespace SampleFramework.Services.Wrappers
{
    public class MembersWrapper : IMembersWrapper
    {
        private readonly MembershipHelper _members;

        public MembersWrapper(PluginController controller)
        {
            _members = controller.Members;
        }

        public bool Login(string username, string password)
        {
            return _members.Login(username, password);
        }
    }
}
