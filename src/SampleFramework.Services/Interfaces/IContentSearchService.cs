using Examine;

namespace SampleFramework.Services.Interfaces
{
    public interface IContentSearchService
    {
        ISearchResults SearchNodes(string alias);
    }
}
