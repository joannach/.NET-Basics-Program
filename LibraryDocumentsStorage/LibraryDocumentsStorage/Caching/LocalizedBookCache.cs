using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public class LocalizedBookCache : DocumentsCache
    {
        public LocalizedBookCache(TimeSpan cacheDuration)
            : base(cacheDuration)
        { }

        public override bool CanCache(Document document)
        {
            return document is LocalizedBook;
        }

        public override TimeSpan GetCacheDuration()
        {
            return this.CacheDuration;
        }
    }
}
