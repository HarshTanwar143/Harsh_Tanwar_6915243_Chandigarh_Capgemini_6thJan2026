using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal class StockMonitor
    {
        public static void Monitor(IInventoryManagement device)
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("\n[Thread] Stock Status :: " + (device.IsInStock() ? "Available" : "Out of Stock"));
            });

            thread.Start();
        }
    }
}
