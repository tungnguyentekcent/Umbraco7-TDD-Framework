using System.Linq;
using SampleFramework.Services.Interfaces;
using umbraco;
using umbraco.interfaces;

namespace SampleFramework.Services.Factories
{
    public class QueryFactory : IQueryFactory
    {
        public INode GetFirstNodeOfType(string docTypeAlias)
        {
            return uQuery.GetNodesByType(docTypeAlias).FirstOrDefault();
        }

        public INode GetCurrentNode()
        {
            return uQuery.GetCurrentNode();
        }
    }
}
