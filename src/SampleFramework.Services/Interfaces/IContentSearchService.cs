using Examine;

namespace SampleFramework.Services.Interfaces
{
    public interface IContentSearchService
    {
        ISearchResults SearchTransactions(string searchText, string category);

        ISearchResults SearchTransactions(string searchText);

        ISearchResults SearchNode(string alias);
    }
}
