using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public class BookCache : DocumentsCache
    {
        public BookCache(TimeSpan cacheDuration)
            : base(cacheDuration)
        {}

        public override bool CanCache(Document document)
        {
            return document is Book;
        }

        public override TimeSpan GetCacheDuration()
        {
            return this.CacheDuration;
        }
    }
}
