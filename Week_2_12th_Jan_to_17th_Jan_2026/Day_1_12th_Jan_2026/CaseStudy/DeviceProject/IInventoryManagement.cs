using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal interface IInventoryManagement
    {
        void CheckStock();
        void AddStock(int quantity);
        void RemoveStock(int quantity);
        bool IsInStock();
        int GetAvailablePorts();
        int GetFinalPrice();
    }
}
