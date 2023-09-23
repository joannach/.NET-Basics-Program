using LibraryDocumentsStorage.Caching;
using LibraryDocumentsStorage.Serachers;
using Document = LibraryDocumentsStorage.Models.Document;

namespace LibraryDocumentsStorage.Services
{
    public class MemoryStorage : IDocumentStorage
    {
        private Dictionary<string, Document> documents = new Dictionary<string, Document>();
        private ICache cache;
        private List<ISearch> documentsSearch;
        private List<DocumentsCache> documentsCache;

        public MemoryStorage(ICache cache)
        {
            this.cache = cache;
            InitializeSearchStrategies();
        }

        private void InitializeSearchStrategies()
        {
            documentsSearch = new List<ISearch>
            {
                new PatentSearch(),
                new BookSearch(),
                new LocalizedBookSearch(),
                new MagazineSearch()
            };
        }

        public Document? GetDocument(string number)
        {
            var document = cache.GetDocument(number);
            if (document != null)
                return document;

            if (documents.ContainsKey(number))
            {
                document = documents[number];
                DocumentsCache cache = documentsCache.FirstOrDefault(strategy => strategy.CanCache(document));

                if (cache != null)
                {
                    cache.Add(number, document, cache.GetCacheDuration());
                }

                return document;
            }
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
                foreach (var strategy in documentsSearch)
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
            return documentsSearch;
        }

        public void LoadDocumentCache(List<DocumentsCache> cacheSettings)
        {
            this.documentsCache = cacheSettings;
        }
    }
}
