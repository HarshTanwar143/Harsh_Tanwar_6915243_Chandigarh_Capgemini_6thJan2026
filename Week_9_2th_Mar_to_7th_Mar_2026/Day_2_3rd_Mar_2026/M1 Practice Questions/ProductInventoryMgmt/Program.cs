namespace ProductInventoryMgmt
{
    public interface IProduct
    {
        string Name { get; set; }
        string Category { get; set; }
        int Stock { get; set; }
        int Price { get; set; }
    }

    public interface IInventory
    {
        void AddProduct(IProduct product);
        void RemoveProduct(IProduct product);
        int CalculateTotalValue();
        List<IProduct> GetProductsByCategory(string category);
        List<IProduct> SearchProductsByName(string name);
        List<(string, int)> GetProductsByCategoryWithCount();
        List<(string, List<IProduct>)> GetAllProductsByCategory();
    }

    public class Product : IProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }

    public class Inventory : IInventory
    {
        private List<IProduct> products = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            products.Remove(product);
        }

        public int CalculateTotalValue()
        {
            return products.Sum(p => p.Price * p.Stock);
        }

        public List<IProduct> GetProductsByCategory(string category)
        {
            return products.Where(p => p.Category == category).ToList();
        }

        public List<IProduct> SearchProductsByName(string name)
        {
            return products.Where(p => p.Name.Contains(name)).ToList();
        }

        public List<(string, int)> GetProductsByCategoryWithCount()
        {
            return products
                .GroupBy(p => p.Category)
                .Select(g => (g.Key, g.Count()))
                .ToList();
        }

        public List<(string, List<IProduct>)> GetAllProductsByCategory()
        {
            return products
                .GroupBy(p => p.Category)
                .Select(g => (g.Key, g.ToList()))
                .ToList();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            IInventory inventory = new Inventory();

            int pCount = Convert.ToInt32(Console.ReadLine().Trim());

            for (int i = 1; i <= pCount; i++)
            {
                var a = Console.ReadLine().Trim().Split(" ");
                Product e = new Product();
                e.Name = a[0];
                e.Category = a[1];
                e.Stock = Convert.ToInt32(a[2]);
                e.Price = Convert.ToInt32(a[3]);
                inventory.AddProduct(e);
            }

            var b = Console.ReadLine().Trim().Split(" ");
            var randomCategoryName = b[0];
            var randomProductName = b[1];
            string productName = b[2];

            var getProductsByCategory = inventory.GetProductsByCategory(randomCategoryName);
            Console.WriteLine($"{randomCategoryName}:");
            foreach (var product in getProductsByCategory.OrderBy(a => a.Name))
                Console.WriteLine($"Product Name:{product.Name} Category:{product.Category}");

            var searchProductsByName = inventory.SearchProductsByName(randomProductName);
            Console.WriteLine($"{randomProductName}:");
            foreach (var product in searchProductsByName.OrderBy(a => a.Name))
                Console.WriteLine($"Product Name:{product.Name} Category:{product.Category}");

            Console.WriteLine("Total Value:$" + inventory.CalculateTotalValue());

            var getProductsByCategoryWithCount = inventory.GetProductsByCategoryWithCount();
            foreach (var item in getProductsByCategoryWithCount.OrderBy(a => a.Item1))
                Console.WriteLine($"{item.Item1}:{item.Item2}");

            var getAllProductsByCategory = inventory.GetAllProductsByCategory();
            foreach (var item in getAllProductsByCategory.OrderBy(a => a.Item1))
            {
                Console.WriteLine($"{item.Item1}:");
                foreach (var item2 in item.Item2)
                    Console.WriteLine($"Product Name:{item2.Name} Price:{item2.Price}");
            }

            var productsToDelete = inventory.SearchProductsByName(productName);
            foreach (var product in productsToDelete)
                inventory.RemoveProduct(product);

            Console.WriteLine("New Total Value:$" + inventory.CalculateTotalValue());
        }
    }
}
