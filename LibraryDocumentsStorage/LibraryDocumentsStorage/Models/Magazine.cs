using System.Xml;

namespace LibraryDocumentsStorage.Models
{
    public class Magazine : Document
    {
        public string Publisher { get; set; }
        public int ReleaseNumber { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}\nAuthors: {Authors}\nDate Published: {DatePublished}\nPublisher: {Publisher}\nRelease number: {ReleaseNumber}");
        }
    }
}
