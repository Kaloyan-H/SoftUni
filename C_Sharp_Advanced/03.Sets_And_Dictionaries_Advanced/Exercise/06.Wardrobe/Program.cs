using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> colorThenClothing = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];

                string[] clothing = SubArray(tokens, 1, tokens.Length - 1);

                if (!colorThenClothing.ContainsKey(color))
                {
                    colorThenClothing.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothing)
                {
                    if (!colorThenClothing[color].ContainsKey(item))
                    {
                        colorThenClothing[color].Add(item, 0);
                    }

                    colorThenClothing[color][item]++;
                }
            }

            string[] seekedItems = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string seekedColor = seekedItems[0];
            string seekedItem = seekedItems[1];

            foreach (var color in colorThenClothing.Keys)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var item in colorThenClothing[color].Keys)
                {
                    if (color == seekedColor && item == seekedItem)
                    {
                        Console.WriteLine($"* {item} - {colorThenClothing[color][item]} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item} - {colorThenClothing[color][item]}");
                    }
                }
            }
        }

        static string[] SubArray(string[] array, int startIndex, int endIndex)
        {
            List<string> subArray = new List<string>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                subArray.Add(array[i]);
            }

            return subArray.ToArray();
        }
    }
}
