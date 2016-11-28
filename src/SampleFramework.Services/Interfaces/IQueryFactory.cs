using umbraco.interfaces;

namespace SampleFramework.Services.Interfaces
{
    public interface IQueryFactory
    {
        INode GetHomeNode();
    }
}
