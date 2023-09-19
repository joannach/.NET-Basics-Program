using LibraryDocumentsStorage.Models;
using LibraryDocumentsStorage.Services;
using System;

class Program
{
    static void Main()
    {
        IDocumentStorage storage = new MemoryStorage();
        Searcher searcher = new Searcher(storage);

        storage.AddDocument("patent_1", new Patent { Title = "Patent 1", Authors = new List<string> { "Author 1" }, DatePublished = DateTime.Now.ToString(), UniqueId = "P1", ExpirationDate = DateTime.Now.AddYears(10).ToString() });
        storage.AddDocument("book_1", new Book { Title = "Book 1", Authors = new List<string> { "Author 2" }, DatePublished = DateTime.Now.ToString(), ISBN = "123456789", NumberOfPages = 200, Publisher = "Publisher 1" });

        searcher.SearchDocuments("Author 1");
    }
}