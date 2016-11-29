using Umbraco.Core.Models;

namespace SampleFramework.Services.Interfaces
{
    public interface IMemberServiceWrapper
    {
        IMember CreateMember(string username, string email, string name, string memberTypeAlias);

        void SavePassword(IMember member, string password);

        void Save(IMember member, bool raiseEvents = true);
    }
}
