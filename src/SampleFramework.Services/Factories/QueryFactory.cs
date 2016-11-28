using System.Linq;
using SampleFramework.Services.Interfaces;
using SampleFramework.Shared.Constants;
using umbraco;
using umbraco.interfaces;

namespace SampleFramework.Services.Factories
{
    public class QueryFactory : IQueryFactory
    {
        public INode GetNodeByType(string docTypeAlias)
        {
            return uQuery.GetNodesByType(docTypeAlias).FirstOrDefault();
        }

        public INode GetCurrentNodeWithType(string docTypeAlias)
        {
            var currentNode = uQuery.GetCurrentNode();
            return currentNode.NodeTypeAlias == docTypeAlias ? currentNode : null;
        }
    }
}
