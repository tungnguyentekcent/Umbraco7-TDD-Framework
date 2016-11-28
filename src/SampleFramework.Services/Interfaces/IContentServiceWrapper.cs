using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace SampleFramework.Services.Interfaces
{
    public interface IContentServiceWrapper
    {
        IContent CreateContent(string name, int parentId, string contentTypeAlias, int userId = 0);

        void Save(IContent content, int userId = 0, bool raiseEvents = true);
    }
}
