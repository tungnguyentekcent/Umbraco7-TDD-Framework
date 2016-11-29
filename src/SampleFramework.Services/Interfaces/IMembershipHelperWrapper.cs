using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace SampleFramework.Services.Interfaces
{
    public interface IMembershipHelperWrapper
    {
        bool Login(string username, string password);

        void Logout();

        bool IsLoggedIn();

        IPublishedContent GetCurrentMember();
    }
}
