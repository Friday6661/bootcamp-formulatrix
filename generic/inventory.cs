using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLib
{
    class Inventory<T>
    {
        private List<T> _items; // define variabel

        // define constructor
        public Inventory()
        {
            _items = new List<T>();
        }

        public string AddItem(T item)
        {
            _items.Add(item);
            return "Item " + item.ToString() + " added to inventory";
        }

        public string RemoveItem(T item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                return "Item " + item.ToString() + " removed from inventory";
            }
            else
            {
                return "Item " + item.ToString() + " is not in inventory";
            }
        }

        public string DisplayItems()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Items in Inventory: ");
            foreach (T item in _items)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}