namespace LibraryManagementSystem
{
   
    public interface IBook
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Category { get; set; }
        int Price { get; set; }
    }

    public interface ILibrarySystem
    {
        void AddBook(IBook book, int quantity);
        void RemoveBook(IBook book, int quantity);
        int CalculateTotal();
        List<(string, int)> CategoryTotalPrice();
        List<(string, int, int)> BooksInfo();
        List<(string, string, int)> CategoryAndAuthorWithCount();
    }

    public class Book : IBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }

    public class LibrarySystem : ILibrarySystem
    {
        private Dictionary<int, (IBook book, int quantity)> books =
            new Dictionary<int, (IBook, int)>();

        public void AddBook(IBook book, int quantity)
        {
            if (books.ContainsKey(book.Id))
                books[book.Id] = (book, books[book.Id].quantity + quantity);
            else
                books.Add(book.Id, (book, quantity));
        }

        public void RemoveBook(IBook book, int quantity)
        {
            if (!books.ContainsKey(book.Id))
                return;

            int currentQty = books[book.Id].quantity - quantity;

            if (currentQty <= 0)
                books.Remove(book.Id);
            else
                books[book.Id] = (book, currentQty);
        }

        public int CalculateTotal()
        {
            return books.Values.Sum(x => x.book.Price * x.quantity);
        }

        public List<(string, int)> CategoryTotalPrice()
        {
            return books.Values
                .GroupBy(x => x.book.Category)
                .Select(g => (g.Key, g.Sum(x => x.book.Price * x.quantity)))
                .ToList();
        }

        public List<(string, int, int)> BooksInfo()
        {
            return books.Values
                .Select(x => (x.book.Title, x.quantity, x.book.Price))
                .ToList();
        }

        public List<(string, string, int)> CategoryAndAuthorWithCount()
        {
            return books.Values
                .GroupBy(x => new { x.book.Category, x.book.Author })
                .Select(g => (g.Key.Category, g.Key.Author, g.Sum(x => x.quantity)))
                .ToList();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            ILibrarySystem librarySystem = new LibrarySystem();

            int bCount = Convert.ToInt32(Console.ReadLine().Trim());

            for (int i = 1; i <= bCount; i++)
            {
                var a = Console.ReadLine().Trim().Split(" ");
                IBook e = new Book();
                e.Id = Convert.ToInt32(a[0]);
                e.Title = a[1];
                e.Author = a[2];
                e.Category = a[3];
                e.Price = Convert.ToInt32(a[4]);
                librarySystem.AddBook(e, Convert.ToInt32(a[5]));
            }

            Console.WriteLine("Book Info:");
            var booksInfo = librarySystem.BooksInfo();
            foreach (var (title, quantity, price) in booksInfo.OrderBy(a => a.Item1))
                Console.WriteLine($"Book Name:{title}, Quantity:{quantity}, Price:{price}");

            Console.WriteLine("Category Total Price:");
            var categoryTotalPrice = librarySystem.CategoryTotalPrice();
            foreach (var (category, totalPrice) in categoryTotalPrice.OrderBy(a => a.Item1))
                Console.WriteLine($"Category:{category}, Total Price:{totalPrice}");

            Console.WriteLine("Category And Author With Count:");
            var categoryAndAuthorWithCount = librarySystem.CategoryAndAuthorWithCount();
            foreach (var (category, author, count) in categoryAndAuthorWithCount.OrderBy(a => a.Item1))
                Console.WriteLine($"Category:{category}, Author:{author}, Count:{count}");

            int total = librarySystem.CalculateTotal();
            Console.WriteLine($"Total Price: {total}");
        }
    }
}