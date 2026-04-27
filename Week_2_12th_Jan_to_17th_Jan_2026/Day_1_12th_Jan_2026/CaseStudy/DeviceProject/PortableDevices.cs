namespace DeviceProject
{
    internal class PortableDevices : Device, DeviceOperationsInterface, IInventoryManagement, IDeviceSpecification
    {
        string category;
        string deviceType;
        bool stock;
        int ram;
        int portNumber;
        int discount;
        int stockCount;

        public void SetSpecificDetails()
        {
            Console.Write("Enter category :: ");
            category = Console.ReadLine();

            Console.Write("Enter device type :: ");
            deviceType = Console.ReadLine();

            Console.Write("Stock available (yes/no) :: ");
            string input = Console.ReadLine();

            if (input == "yes")
            {
                stock = true;

                Console.Write("Enter stock count :: ");
                stockCount = int.Parse(Console.ReadLine());

                Console.Write("Enter port number :: ");
                portNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter RAM :: ");
                ram = int.Parse(Console.ReadLine());

                Console.Write("Enter discount :: ");
                discount = int.Parse(Console.ReadLine());
            }
            else
            {
                stock = false;
            }
        }

        public void UpgradeRam()
        {
            if (!stock) return;

            Console.Write("Upgrade RAM (yes/no) :: ");
            string choice = Console.ReadLine();

            if (choice == "yes")
            {
                Console.Write("Enter new RAM :: ");
                ram = int.Parse(Console.ReadLine());
            }
        }

        public void PrintDetails()
        {
            Console.WriteLine("\nCompany : " + Company);
            Console.WriteLine("Brand : " + brand);
            Console.WriteLine("Model : " + model);
            Console.WriteLine("Price : " + price);

            if (stock)
            {
                Console.WriteLine("Category : " + category);
                Console.WriteLine("Type : " + deviceType);
                Console.WriteLine("RAM : " + ram);
                Console.WriteLine("Ports : " + portNumber);
                Console.WriteLine("Final Price : " + GetFinalPrice());
            }
            else
            {
                Console.WriteLine("No stock available");
            }
        }

        public void CheckStock()
        {
            Console.WriteLine(stock ? "\n\nCongrats!!! Stock available\n\n" : "\n\nSorry!!! Out of stock\n\n");
        }

        public void AddStock(int quantity)
        {
            stockCount += quantity;
            if(stockCount > 0)
            {
                stock = true;
            }
            else
            {
                stock = false;
            }
        }

        public void RemoveStock(int quantity)
        {
            stockCount -= quantity;
            if (stockCount <= 0)
            {
                stockCount = 0;
                stock = false;
            }
        }

        public bool IsInStock()
        {
            return stock;
        }

        public int GetAvailablePorts()
        {
            return portNumber;
        }

        public int GetFinalPrice()
        {
            return price - ((price * discount) / 100);
        }

        public void SetCategory(string category)
        {
            this.category = category;
        }

        public void SetDeviceType(string type)
        {
            deviceType = type;
        }

        public void SetRam(int ram)
        {
            this.ram = ram;
        }

        public int GetRam()
        {
            return ram;
        }

        public string GetDeviceType()
        {
            return deviceType;
        }

        public string GetCategory()
        {
            return category;
        }
    }
}
