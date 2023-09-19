using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Serachers
{
    public class PatentSearch : ISearch
    {
        public bool IsMatch(Document document, string searchTerm)
        {
            return document is Patent patent && (patent.Title.Contains(searchTerm) || patent.UniqueId.Contains(searchTerm));
        }

        public void DisplayInfo(Document document)
        {
            Patent patent = (Patent)document;
            Console.WriteLine($"Type: Patent, Title: {patent.Title}, Date Published: {patent.DatePublished}, Unique Id: {patent.UniqueId}, Expiration Date: {patent.ExpirationDate}");
        }
    }
}
