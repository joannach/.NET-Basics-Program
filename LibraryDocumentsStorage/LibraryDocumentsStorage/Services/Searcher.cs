using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Services
{
    public class Searcher
    {
        private readonly IDocumentStorage storage;

        public Searcher(IDocumentStorage storage)
        {
            this.storage = storage;
        }

        public void SearchDocuments(string searchTerm)
        {
            List<Document> results = storage.SearchDocuments(searchTerm);
            foreach (var result in results)
            {
                foreach (var strategy in storage.GetSearchStrategies())
                {
                    if (strategy.IsMatch(result, searchTerm))
                    {
                        strategy.DisplayInfo(result);
                        break;
                    }
                }
            }
        }
    }
}
