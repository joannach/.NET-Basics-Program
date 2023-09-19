namespace LibraryDocumentsStorage.Models
{
    public class Patent : Document
    {
        public string ExpirationDate { get; set; }
        public string UniqueId { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}\nAuthors: {Authors}\nDate Published: {DatePublished}\nExpiration Date: {ExpirationDate}\nUnique ID: {UniqueId}");
        }
    }
}
