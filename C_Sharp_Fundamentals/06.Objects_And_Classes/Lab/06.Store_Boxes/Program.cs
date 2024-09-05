using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal Price 
        { 
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Box> boxesList = new List<Box>();

            while (input[0] != "end")
            {
                boxesList.Add(new Box
                {
                    SerialNumber = int.Parse(input[0]),
                    Item = new Item
                    {
                        Name = input[1],
                        Price = decimal.Parse(input[3])
                    },
                    ItemQuantity = int.Parse(input[2]),
                });

                input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            List<Box> boxesSortedByPrice = boxesList
                .OrderByDescending(box => box.Price)
                .ToList();


            foreach (Box box in boxesSortedByPrice)
            {
                Console.WriteLine($"{box.SerialNumber}\n" +
                    $"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}\n" +
                    $"-- ${box.Price:f2}");
            }
        }
    }
}
