using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Serachers
{
    public class LocalizedBookSearch : ISearch
    {
        public bool IsMatch(Document document, string searchTerm)
        {
            return document is LocalizedBook localizedBook && (localizedBook.Title.Contains(searchTerm) || localizedBook.ISBN.Contains(searchTerm) || localizedBook.Authors.Contains(searchTerm));
        }

        public void DisplayInfo(Document document)
        {
            LocalizedBook localizedBook = (LocalizedBook)document;
            Console.WriteLine($"Type: Localized Book, Title: {localizedBook.Title}, Date Published: {localizedBook.DatePublished}, ISBN: {localizedBook.ISBN}, Number of Pages: {localizedBook.NumberOfPages}, Original Publisher: {localizedBook.OriginalPublisher}, Country of Localization: {localizedBook.CountryOfLocalization}, Local Publisher: {localizedBook.LocalPublisher}");
        }
    }
}
