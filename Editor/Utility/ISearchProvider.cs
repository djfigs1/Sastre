using System.Threading.Tasks;

namespace Sastre.Editor.Utility
{
    public interface ISearchProvider
    {
        public Task<ISearchResult[]> Search(string query);
    }
}