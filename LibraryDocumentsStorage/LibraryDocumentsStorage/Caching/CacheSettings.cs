using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Caching
{
    public class CacheSettings
    {
        public string DocumentType { get; set; }
        public short CacheDurationMinutes { get; set; }
    }
}
