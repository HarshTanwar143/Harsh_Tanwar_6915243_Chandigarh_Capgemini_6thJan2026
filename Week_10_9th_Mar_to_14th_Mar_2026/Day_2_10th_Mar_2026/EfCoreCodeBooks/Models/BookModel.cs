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
    }
}
