using LibraryDocumentsStorage.Models;
using LibraryDocumentsStorage.Serachers;

namespace LibraryDocumentsStorage.Services
{
    public interface IDocumentStorage
    {
        Document? GetDocument(string number);
        void AddDocument(string number, Document document);
        List<Document> SearchDocuments(string searchTerm);
        List<ISearch> GetSearchStrategies();
    }
}
