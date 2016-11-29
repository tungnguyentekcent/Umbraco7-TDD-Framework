using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Interfaces
{
    public interface IMemberServiceFactory
    {
        IMemberService GetMemberService(PluginController controller);
    }
}
