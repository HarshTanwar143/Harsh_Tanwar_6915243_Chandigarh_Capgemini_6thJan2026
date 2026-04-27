using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal class DelegateHandlers
    {
        public static void PriceAlert(string message)
        {
            Console.WriteLine("[Price Alert] " + message);
        }

        public static void StockAlert(string message)
        {
            Console.WriteLine("[Stock Alert] " + message);
        }
    }
}
