using LibraryDocumentsStorage.Caching;
using LibraryDocumentsStorage.Models;
using Newtonsoft.Json;

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

        public List<DocumentsCache> LoadCacheSettings()
        {
                string json = File.ReadAllText("cacheSettings.json");
                List<CacheSettings> settings = JsonConvert.DeserializeObject<List<CacheSettings>>(json);

                if (settings == null || !settings.Any())
                    throw new Exception();

            List<DocumentsCache> cachesSettings = new List<DocumentsCache>();

            foreach (var setting in settings)
            {
                TimeSpan cacheDuration = TimeSpan.FromMinutes(setting.CacheDurationMinutes);

                switch (setting.DocumentType)
                {
                    case "Patent":
                        cachesSettings.Add(new PatentCache(cacheDuration));
                        break;
                    case "Book":
                        cachesSettings.Add(new BookCache(cacheDuration));
                        break;
                    case "LocalizedBook":
                        cachesSettings.Add(new BookCache(cacheDuration));
                        break;
                    case "Magazine":
                        cachesSettings.Add(new BookCache(cacheDuration));
                        break;
                    default:
                        throw new ArgumentException($"Unsupported document type: {setting.DocumentType}");
                } 
            }

            return cachesSettings;
        }
    }
}
