using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public class PatentCache : DocumentsCache
    {
        public PatentCache(TimeSpan cacheDuration)
            : base(cacheDuration)
        { }

        public override bool CanCache(Document document)
        {
            return document is Patent;
        }

        public override TimeSpan GetCacheDuration()
        {
            return this.CacheDuration;
        }
    }
}
