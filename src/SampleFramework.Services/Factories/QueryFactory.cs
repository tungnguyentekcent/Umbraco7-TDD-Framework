using System.Linq;
using SampleFramework.Services.Interfaces;
using SampleFramework.Shared.Constants;
using umbraco;
using umbraco.interfaces;

namespace SampleFramework.Services.Factories
{
    public class QueryFactory : IQueryFactory
    {
        public INode GetHomeNode()
        {
            return uQuery.GetNodesByType(DocTypeAliases.HomePage).FirstOrDefault();
        }
    }
}
