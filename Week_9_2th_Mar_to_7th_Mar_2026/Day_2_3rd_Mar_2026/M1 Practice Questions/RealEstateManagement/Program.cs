namespace RealEstateManagement
{
    public class RealEstateListing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
    }

    public class RealEstateManager
    {
        private List<RealEstateListing> listings = new List<RealEstateListing>();

        public void AddListing(RealEstateListing listing)
        {
            var existing = listings.FirstOrDefault(x => x.Id == listing.Id);
            if (existing == null)
                listings.Add(listing);
        }

        public void RemoveListing(int id)
        {
            var listing = listings.FirstOrDefault(x => x.Id == id);
            if (listing != null)
                listings.Remove(listing);
        }

        public void UpdateListing(int id, decimal newPrice, int newArea)
        {
            var listing = listings.FirstOrDefault(x => x.Id == id);
            if (listing != null)
            {
                listing.Price = newPrice;
                listing.Area = newArea;
            }
        }

        public List<RealEstateListing> GetListingsByLocation(string location)
        {
            return listings.Where(x => x.Location == location).ToList();
        }

        public List<RealEstateListing> GetListingsAbovePrice(decimal price)
        {
            return listings.Where(x => x.Price > price).ToList();
        }

        public decimal GetAveragePrice()
        {
            if (listings.Count == 0)
                return 0;
            return listings.Average(x => x.Price);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            RealEstateManager manager = new RealEstateManager();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                manager.AddListing(new RealEstateListing
                {
                    Id = Convert.ToInt32(input[0]),
                    Title = input[1],
                    Location = input[2],
                    Price = Convert.ToDecimal(input[3]),
                    Area = Convert.ToInt32(input[4])
                });
            }

            string location = Console.ReadLine();
            decimal priceFilter = Convert.ToDecimal(Console.ReadLine());

            var byLocation = manager.GetListingsByLocation(location);
            var abovePrice = manager.GetListingsAbovePrice(priceFilter);

            Console.WriteLine("Listings by Location:");
            foreach (var l in byLocation)
                Console.WriteLine(l.Title);

            Console.WriteLine("Listings Above Price:");
            foreach (var l in abovePrice)
                Console.WriteLine(l.Title);

            Console.WriteLine("Average Price: " + manager.GetAveragePrice());
        }
    }
}
