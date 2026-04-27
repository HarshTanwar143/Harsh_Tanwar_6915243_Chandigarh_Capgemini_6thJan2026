using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject
{
    internal class InventoryManager<T>
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public List<T> GetAllItems()
        {
            return items;
        }

        public int Count()
        {
            return items.Count;
        }
    }
}
