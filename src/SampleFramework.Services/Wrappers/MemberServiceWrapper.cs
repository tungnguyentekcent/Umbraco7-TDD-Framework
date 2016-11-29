using SampleFramework.Services.Interfaces;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Wrappers
{
    public class MemberServiceWrapper : IMemberServiceWrapper
    {
        private readonly IMemberService _memberService;

        public MemberServiceWrapper(PluginController controller)
        {
            _memberService = controller.Services.MemberService;
        }

        public IMember CreateMember(string username, string email, string name, string memberTypeAlias)
        {
            return _memberService.CreateMember(username, email, name, memberTypeAlias);
        }

        public void SavePassword(IMember member, string password)
        {
            _memberService.SavePassword(member, password);
        }

        public void Save(IMember member, bool raiseEvents = true)
        {
            _memberService.Save(member, raiseEvents);
        }
    }
}
