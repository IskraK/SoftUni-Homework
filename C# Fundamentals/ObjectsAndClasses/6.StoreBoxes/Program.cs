using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string line = Console.ReadLine();

            while (line != "end")
            {
                string[] input = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string serialNumber = input[0];
                string item = input[1];
                int quantity = int.Parse(input[2]);
                decimal price = decimal.Parse(input[3]);

                Item currItem = new Item(item, price);
                Box currBox = new Box(serialNumber, currItem, quantity);

                boxes.Add(currBox);
                line = Console.ReadLine();
            }

            List<Box> sortedBox = boxes.OrderBy(x => x.PriceForBox).ToList();
            sortedBox.Reverse();

            foreach (Box box in sortedBox)
            {
                box.ToSpecialFormat();
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceForBox { get; set; }
        public Box(string serialNumber,Item item,int quantity)
        {
            this.SerialNumber = serialNumber;
            this.Item = item.Name;
            this.Quantity = quantity;
            this.PriceForBox = quantity * item.Price;
        }

        internal void ToSpecialFormat()
        {
            Console.WriteLine(this.SerialNumber);
            Console.WriteLine($"-- {this.Item} - ${this.PriceForBox/this.Quantity:F2}: {this.Quantity}");
            Console.WriteLine($"-- ${this.PriceForBox:F2}");
        }
    }
}
