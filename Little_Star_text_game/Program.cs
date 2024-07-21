using System;
using System.Collections.Generic;

namespace Little_Star_text_game
{
    class Program
    {
        static List<string> inventory = new List<string>();
        static List<string> items = new List<string> { "clock", "screw driver", "clock arm" };


          static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Little Star text game! Type 'exit' to quit.");
            Console.WriteLine("The flower blossomed. In the middle you see a clock. ");

            while (true)
            {
                Console.Write(">");
                string command = Console.ReadLine().Trim().ToLower();

                if (command == "exit")
                {
                    break;
                }
                else if (command.StartsWith("pick up"))
                {
                    string item = RemoveArticles(command.Substring(8).Trim());
                    PickUpItem(item);
                }
                else if (command == "inventory")
                {
                    DisplayInventory();
                }
                else
                {
                    Console.WriteLine("Invalid command. Try 'pick up [item]' or 'inventory'.");
                }


            }

        }

        static void DisplayInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("You have nothing in your inventory.");
            }
            else
            {
                Console.WriteLine("You have:");
                foreach (string item in inventory)
                {
                    Console.WriteLine(item);
                }
            }

        }

        static void PickUpItem(string item)
        {
            if (items.Contains(item))
            {
                inventory.Add(item);
                Console.WriteLine($"You picked up a {item}.");
            }
            else
            {
                Console.WriteLine($"There is no {item} here");
            }
        }


        static string RemoveArticles(string input)
        {
            List<string> articles = new List<string> { "a", "an", "the" };
            List<string> words = input.Split(' ').ToList();
            words.RemoveAll(word => articles.Contains(word));
            return string.Join(" ", words);

        }



    }

}
            //Console.WriteLine("You are a space explorer on a mission to find the Little Star.");
            //Console.WriteLine("You have landed on a planet and you have to find the Little Star