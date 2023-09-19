using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Serachers
{
    public interface ISearch
    {
        bool IsMatch(Document document, string searchTerm);
        void DisplayInfo(Document document);
    }
}
