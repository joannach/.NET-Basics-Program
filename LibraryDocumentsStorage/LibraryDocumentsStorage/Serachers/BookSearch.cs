using LibraryDocumentsStorage.Models;

namespace LibraryDocumentsStorage.Serachers
{
    public class BookSearch : ISearch
    {
        public bool IsMatch(Document document, string searchTerm)
        {
            return document is Book book && (book.Title.Contains(searchTerm) || book.ISBN.Contains(searchTerm) || book.Authors.Contains(searchTerm));
        }

        public void DisplayInfo(Document document)
        {
            Book book = (Book)document;
            Console.WriteLine($"Type: Book, Title: {book.Title}, Date Published: {book.DatePublished}, ISBN: {book.ISBN}, Number of Pages: {book.NumberOfPages}, Publisher: {book.Publisher}, Authors: {string.Join(", ", book.Authors)}");
        }
    }
}
