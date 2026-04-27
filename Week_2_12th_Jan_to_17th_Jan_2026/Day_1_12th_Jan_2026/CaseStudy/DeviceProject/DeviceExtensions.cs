using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal static class DeviceExtensions
    {
        public static bool IsPremium(this Device device)
        {
            return device.price > 50000;
        }

        public static void PrintQuickInfo(this Device device)
        {
            Console.WriteLine(device.brand + " " + device.model + " - " + device.price);
        }
    }
}
