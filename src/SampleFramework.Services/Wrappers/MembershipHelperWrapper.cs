using SampleFramework.Services.Interfaces;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;

namespace SampleFramework.Services.Wrappers
{
    public class MembershipHelperWrapper : IMembershipHelperWrapper
    {
        private readonly MembershipHelper _membershipHelper;

        public MembershipHelperWrapper(PluginController controller)
        {
            _membershipHelper = controller.Members;
        }

        public MembershipHelperWrapper(UmbracoController controller)
        {
            _membershipHelper = controller.Members;
        }

        public bool Login(string username, string password)
        {
            return _membershipHelper.Login(username, password);
        }

        public void Logout()
        {
            _membershipHelper.Logout();
        }

        public bool IsLoggedIn()
        {
            return _membershipHelper.IsLoggedIn();
        }

        public IPublishedContent GetCurrentMember()
        {
            return _membershipHelper.GetCurrentMember();
        }
    }
}
