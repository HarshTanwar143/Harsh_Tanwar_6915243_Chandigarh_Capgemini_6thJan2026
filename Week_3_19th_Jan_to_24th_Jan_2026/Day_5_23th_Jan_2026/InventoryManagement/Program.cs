namespace InventoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            inventory.AddBook(new Book { Title = "Above all don't wobble", Price = 500, Stock = 10 });
            inventory.AddBook(new Book { Title = "100 years of solitude", Price = 300, Stock = 0 });
            inventory.AddBook(new Book { Title = "one boat and three man", Price = 700, Stock = 5 });

            Console.WriteLine("All Books:");
            inventory.DisplayBooks();

            Console.WriteLine("\nBooks cheaper than 600:");
            var cheapBooks = inventory.GetBooksCheaperThan(600);
            cheapBooks.ForEach(b => Console.WriteLine(b.Title));

            inventory.IncreasePriceByPercentage(10);
            Console.WriteLine("\nAfter 10% price increase:");
            inventory.DisplayBooks();

            inventory.RemoveOutOfStockBooks();
            Console.WriteLine("\nAfter removing out-of-stock books:");
            inventory.DisplayBooks();
        }
    }
}
