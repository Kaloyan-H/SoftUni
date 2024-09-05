using System;

namespace _03.Songs
{
    class Song
    {
        public string TypeList { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            Song[] songArray = new Song[numberOfSongs];

            for (int i = 0; i < songArray.Length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);

                songArray[i] = new Song
                {
                    TypeList = input[0],
                    Name = input[1],
                    Time = input[2]
                };
            }

            string selection = Console.ReadLine();

            if (selection == "all")
            {
                for (int i = 0; i < songArray.Length; i++)
                {
                    Console.WriteLine(songArray[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < songArray.Length; i++)
                {
                    if (songArray[i].TypeList == selection)
                    {
                        Console.WriteLine(songArray[i].Name);
                    }
                }
            }
        }
    }
}
