namespace LibraryDocumentsStorage.Models
{
    public class LocalizedBook : Document
    {
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public string OriginalPublisher { get; set; }
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}\nTitle: {Title}\nAuthors: {Authors}\nNumber of Pages: {NumberOfPages}\nOriginal Publisher: {OriginalPublisher}\nCountry of Localization: {CountryOfLocalization}\nLocal Publisher: {LocalPublisher}\nDate Published: {DatePublished}");
        }
    }
}
