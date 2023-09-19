namespace LibraryDocumentsStorage.Models
{
    public class Book : Document
    {
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}\nTitle: {Title}\nAuthors: {Authors}\nNumber of Pages: {NumberOfPages}\nPublisher: {Publisher}\nDate Published: {DatePublished}");
        }
    }
}
