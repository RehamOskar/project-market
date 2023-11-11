using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarket1
{
   
  

    class Program
    {
        static Dictionary<string, double> items = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. Delete item");
                Console.WriteLine("3. Calculate total");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        CalculateTotal();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddItem()
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter item price: ");
            double itemPrice;
            if (double.TryParse(Console.ReadLine(), out itemPrice))
            {
                items[itemName] = itemPrice;
                Console.WriteLine("Item added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid price. Please try again.");
            }
        }

        static void DeleteItem()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items to delete.");
                return;
            }

            Console.WriteLine("Items:");
            int index = 1;
            foreach (var item in items)
            {
                Console.WriteLine($"{index}. {item.Key} - Price: {item.Value}");
                index++;
            }

            Console.Write("Enter the index of the item to delete: ");
            int itemIndex;
            if (int.TryParse(Console.ReadLine(), out itemIndex) && itemIndex > 0 && itemIndex <= items.Count)
            {
                string deletedItem = items.Keys.ElementAt(itemIndex - 1);
                items.Remove(deletedItem);
                Console.WriteLine($"Item '{deletedItem}' deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid index. Please try again.");
            }
        }

        static void CalculateTotal()
        {
            double total = 0;

            if (items.Count == 0)
            {
                Console.WriteLine("No items added yet.");
                return;
            }

            Console.WriteLine("Items:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key} - Price: {item.Value}");
                total += item.Value;
            }

            Console.WriteLine($"Total: {total}");
        }
    }

}
