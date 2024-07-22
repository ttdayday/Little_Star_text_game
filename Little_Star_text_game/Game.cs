using System;
using System.Collections.Generic;

namespace Little_Star_text_game
{
    public class Game
    {
        public Inventory Inventory { get; private set; }
        private List<GameObject> gameObjects;
        private bool timeStarted;

        public Game()
        {
            Inventory = new Inventory();
            gameObjects = new List<GameObject>
            {
                new FlowerPot()
            };
            timeStarted = false;
        }

        public void Run()
        {
            bool running = true;
            Console.WriteLine("Welcome to the game! Type 'exit' to quit.");
            Console.WriteLine("In front of the old house, you see a flower pot.");

            while (running)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (input == null)
                {
                    continue; // If the input is null, skip to the next iteration
                }

                string command = input.Trim().ToLower();

                if (command == "exit")
                {
                    running = false;
                }
                else if (command == "open the inventory")
                {
                    Inventory.DisplayInventory();
                }
                else if (command.StartsWith("click"))
                {
                    string objectName = Utils.RemoveArticles(command.Substring(6).Trim());
                    ClickObject(objectName);
                }
                else if (command.StartsWith("combine"))
                {
                    string itemsToCombine = command.Substring(8).Trim();
                    CombineItems(itemsToCombine);
                }
                else
                {
                    Console.WriteLine("Invalid command. Try 'click [object]' or 'open the inventory'.");
                }
            }
        }

        private void ClickObject(string objectName)
        {
            GameObject? obj = gameObjects.Find(o => o.Name.ToLower() == objectName);

            if (obj == null)
            {
                Console.WriteLine($"There is no {objectName} here.");
                return;
            }

            obj.Interact(this);
        }

        private void CombineItems(string itemsToCombine)
        {
            string[] items = itemsToCombine.Split("and");
            if (items.Length != 2)
            {
                Console.WriteLine("You need to combine exactly two items.");
                return;
            }

            InventoryItem? item1 = Inventory.FindItem(items[0].Trim());
            InventoryItem? item2 = Inventory.FindItem(items[1].Trim());

            if (item1 == null || item2 == null)
            {
                Console.WriteLine("One or both items not found in inventory.");
                return;
            }

            if (item1.Name == "clock" && item2.Name == "clock arms" || item1.Name == "clock arms" && item2.Name == "clock")
            {
                Inventory.RemoveItem(item1);
                Inventory.RemoveItem(item2);
                Inventory.Add(new InventoryItem("fixed clock", "A clock with arms, now it can tell time."));
                Console.WriteLine("You combined the clock and clock arms to make a fixed clock. Time starts to move again.");
                timeStarted = true;
            }
            else
            {
                Console.WriteLine("These items cannot be combined.");
            }
        }

        public void AddGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public void RemoveGameObject(GameObject obj)
        {
            gameObjects.Remove(obj);
        }
    }
}
