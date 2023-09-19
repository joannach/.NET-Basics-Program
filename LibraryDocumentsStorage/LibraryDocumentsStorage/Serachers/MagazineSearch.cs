using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Serachers
{
    public class MagazineSearch : ISearch
    {
        public bool IsMatch(Document document, string searchTerm)
        {
            return document is Magazine magazine && (magazine.Title.Contains(searchTerm) || magazine.Publisher.Contains(searchTerm));
        }

        public void DisplayInfo(Document document)
        {
            Magazine magazine = (Magazine)document;
            Console.WriteLine($"Type: Magazine, Title: {magazine.Title}, Publisher: {magazine.Publisher}, Release Number: {magazine.ReleaseNumber}, Date Published: {magazine.DatePublished}");
        }
    }
}
