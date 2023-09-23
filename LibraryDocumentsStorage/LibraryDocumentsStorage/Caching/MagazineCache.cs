using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public class MagazineCache : DocumentsCache
    {
        public MagazineCache(TimeSpan cacheDuration)
            : base(cacheDuration)
        { }

        public override bool CanCache(Document document)
        {
            return document is Magazine;
        }

        public override TimeSpan GetCacheDuration()
        {
            return this.CacheDuration;
        }
    }
}
