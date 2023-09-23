using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public abstract class DocumentsCache
    {
        protected Dictionary<string, (Document document, DateTime expirationTime)> cache = new Dictionary<string, (Document, DateTime)>();
        protected TimeSpan CacheDuration { get; }

        public DocumentsCache(TimeSpan cacheDuration)
        {
            CacheDuration = cacheDuration;
        }

        public abstract bool CanCache(Document document);
        public abstract TimeSpan GetCacheDuration();

        public void Add(string key, Document document, TimeSpan cacheDuration)
        {
            DateTime expirationTime = DateTime.Now.Add(cacheDuration);
            cache[key] = (document, expirationTime);
        }

        public Document Get(string key)
        {
            if (cache.ContainsKey(key))
            {
                var (document, expirationTime) = cache[key];
                if (expirationTime > DateTime.Now)
                {
                    return document;
                }
                else
                {
                    cache.Remove(key);
                }
            }
            return null;
        }
    }
}
