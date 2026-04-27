using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EfCoreCodeBooks.Models
{
    [Table("tblBooks")]

    public class BookModel
    {
        [Key]
        public int BookId { get; set; }

        public string BookName { get; set; }

        public int BookPrice { get; set; }

        public int BookQuantity { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public int PublishedYear { get; set; }
    }
}
