namespace LibraryApp.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; }

        // Is the book available to borrow?
        public bool IsAvailable { get; set; }

        // Extended practice property
        public string BorrowerName { get; set; }
    }
}