namespace DeviceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // INTERFACES, INHERITANCE (DEVICE DETAILS AND SPECIFICATIONS)
            PortableDevices device = new PortableDevices();

            device.setDetails();
            device.SetSpecificDetails();
            device.CheckStock();
            device.UpgradeRam();
            device.AddStock(5);
            device.RemoveStock(2);

            Console.WriteLine("\n\nIs device in stock :: " + device.IsInStock());
            Console.WriteLine("Available ports :: " + device.GetAvailablePorts());
            Console.WriteLine("Current RAM :: " + device.GetRam());
            Console.WriteLine("Category :: " + device.GetCategory());
            Console.WriteLine("Device Type :: " + device.GetDeviceType());
            Console.WriteLine("Final Selling Price :: " + device.GetFinalPrice());
            device.PrintDetails();
            Console.WriteLine("\nTotal number of devices :: " + Device.DeviceCount);


            // ABSTRACT CLASS (WARRANTY FUNCTIONALITY)
            DeviceWarranty warranty = new DeviceWarranty();
            Console.Write("\nEnter warranty years :: ");
            warranty.SetWarranty(int.Parse(Console.ReadLine()));
            Console.Write("Extend warranty (yes/no) :: ");
            string choice = Console.ReadLine();

            if (choice == "yes")
            {
                warranty.ExtendWarranty();
            }

            warranty.PrintWarrantyDetails();

            // GENERIC
            InventoryManager<PortableDevices> inventory = new InventoryManager<PortableDevices>();
            inventory.AddItem(device);

            Console.WriteLine("\n\nTotal devices in inventory :: " + inventory.Count());

            // THREAD
            StockMonitor.Monitor(device);

            // EXTENSION CLASS
            device.PrintQuickInfo();
            Console.WriteLine("Is Premium Device :: " + device.IsPremium());

            // DELEGATES
            DeviceNotifier notifier = new DeviceNotifier();

            notifier.Notify += DelegateHandlers.PriceAlert;
            notifier.Notify += DelegateHandlers.StockAlert;

            if (device.GetFinalPrice() < 30000)
            {
                notifier.Trigger("Device is available at discounted price!");
            }

            if (!device.IsInStock())
            {
                notifier.Trigger("Device is currently out of stock!");
            }


            Console.ReadLine();
        }
    }
}
