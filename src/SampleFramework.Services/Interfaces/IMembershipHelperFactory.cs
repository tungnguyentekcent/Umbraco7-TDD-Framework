using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web.Mvc;

namespace SampleFramework.Services.Interfaces
{
    public interface IMembershipHelperFactory
    {
        IMembershipHelperWrapper GetMembershipHelperWrapper(PluginController controller);

        IMembershipHelperWrapper GetMembershipHelperWrapper(UmbracoController controller);
    }
}
