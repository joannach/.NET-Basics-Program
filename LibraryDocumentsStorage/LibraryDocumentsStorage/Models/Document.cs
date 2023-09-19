namespace LibraryDocumentsStorage.Models
{
    public abstract class Document
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string DatePublished { get; set; }
        public abstract void DisplayInfo();
    }
}
