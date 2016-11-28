using umbraco.interfaces;

namespace SampleFramework.Services.Interfaces
{
    public interface IQueryFactory
    {
        INode GetNodeByType(string docTypeAlias);

        INode GetCurrentNodeWithType(string docTypeAlias);
    }
}
