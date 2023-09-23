using LibraryDocumentsStorage.Caching;
using LibraryDocumentsStorage.Models;
using LibraryDocumentsStorage.Services;

class Program
{
    static void Main()
    {
        ICache cache = new DocumentCache();
        IDocumentStorage storage = new MemoryStorage(cache);
        Searcher searcher = new Searcher(storage);
        storage.LoadDocumentCache(searcher.LoadCacheSettings());

        storage.AddDocument("patent_1", new Patent { Title = "Patent 1", DatePublished = DateTime.Now.ToString(), UniqueId = "P1", ExpirationDate = DateTime.Now.AddYears(10).ToString() });
        storage.AddDocument("book_1", new Book { Title = "Book 1", DatePublished = DateTime.Now.ToString(), ISBN = "123456789", NumberOfPages = 200, Publisher = "Publisher 1", Authors = new List<string> { "Author 2" } });
        storage.AddDocument("magazine_1", new Magazine { Title = "Magazine 1", Publisher = "Publisher 2", ReleaseNumber = 3, DatePublished = DateTime.Now.ToString() });

        searcher.SearchDocuments("Publisher 2");
    }
}