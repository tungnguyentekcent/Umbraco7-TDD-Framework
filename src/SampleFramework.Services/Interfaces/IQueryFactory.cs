using umbraco.interfaces;

namespace SampleFramework.Services.Interfaces
{
    public interface IQueryFactory
    {
        INode GetFirstNodeOfType(string docTypeAlias);

        INode GetCurrentNode();
    }
}
