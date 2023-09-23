using LibraryDocumentsStorage.Models;


namespace LibraryDocumentsStorage.Caching
{
    public interface ICache
    {
        void Add(string key, Document document, TimeSpan cacheDuration);
        Document GetDocument(string key);
    }
}
