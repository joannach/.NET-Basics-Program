using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public class DocumentCache : ICache
    {
        private Dictionary<string, (Document, DateTime)> cache = new Dictionary<string, (Document, DateTime)>();

        public DocumentCache() { }

        public void Add(string key, Document document, TimeSpan cacheDuration)
        {
            DateTime expirationTime = DateTime.Now.Add(cacheDuration);
            cache[key] = (document, expirationTime);
        }

        public Document? GetDocument(string key)
        {
            if (cache.ContainsKey(key))
            {
                var (document, expirationTime) = cache[key];

                if (expirationTime > DateTime.Now)
                    return document;
                else
                    cache.Remove(key);
            }

            return null;
        }
    }
}
