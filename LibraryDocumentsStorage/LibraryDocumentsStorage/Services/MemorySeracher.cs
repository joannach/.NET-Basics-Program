using LibraryDocumentsStorage.Serachers;
using Document = LibraryDocumentsStorage.Models.Document;

namespace LibraryDocumentsStorage.Services
{
    public class MemoryStorage : IDocumentStorage
    {
        private Dictionary<string, Document> documents = new Dictionary<string, Document>();
        private List<ISearch> searchStrategies = new List<ISearch>
        {
            new PatentSearch(),
            new BookSearch(),
            new LocalizedBookSearch(),
            new MagazineSearch()
        };

        public Document? GetDocument(string number)
        {
            if (documents.ContainsKey(number))
                return documents[number];
            else
                return null;
        }

        public void AddDocument(string number, Document document)
        {
            documents[number] = document;
        }

        public List<Document> SearchDocuments(string searchTerm)
        {
            List<Document> results = new List<Document>();
            foreach (var document in documents.Values)
            {
                foreach (var strategy in searchStrategies)
                {
                    if (strategy.IsMatch(document, searchTerm))
                    {
                        results.Add(document);
                        break;
                    }
                }
            }
            return results;
        }

        public List<ISearch> GetSearchStrategies()
        {
            return searchStrategies;
        }
    }
}
