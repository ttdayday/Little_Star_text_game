using System;
using System.Collections.Generic;

namespace Little_Star_text_game
{
    public class Inventory
    {
        private List<InventoryItem> items;

        public Inventory()
        {
            items = new List<InventoryItem>();
        }

        public void Add(InventoryItem item)
        {
            items.Add(item);
            Console.WriteLine($"You added {item.Name} to your inventory.");
        }

        public void DisplayInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                Console.WriteLine("You have the following items in your inventory:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
        }

        public InventoryItem? FindItem(string name)
        {
            return items.Find(i => i.Name.ToLower() == name.ToLower());
        }

        public void RemoveItem(InventoryItem item)
        {
            items.Remove(item);
        }
    }
}
