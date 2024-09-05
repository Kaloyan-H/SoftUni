using System;

namespace _01.Advertisement_Message
{
    class RandomAdvertisement
    {
        private string[] Phrases =
        {
            "Excellent product.",
            "Such a great product.",
            "I always use that product.",
            "Best product of its category.",
            "Exceptional product.",
            "I can't live without this product."
        };

        private string[] Events =
        {
            "Now I feel good.",
            "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.",
            "Try it yourself, I am very satisfied.",
            "I feel great!"
        };

        private string[] Authors =
        {
            "Diana", 
            "Petya", 
            "Stella", 
            "Elena", 
            "Katya", 
            "Iva", 
            "Annie", 
            "Eva"
        };

        private string[] Cities =
        {
            "Burgas", 
            "Sofia", 
            "Plovdiv", 
            "Varna", 
            "Ruse"
        };

        private Random rng = new Random();

        public RandomAdvertisement()
        {
            this.Phrase = Phrases[rng.Next(0, Phrases.Length)];
            this.Event = Events[rng.Next(0, Events.Length)];
            this.Author = Authors[rng.Next(0, Authors.Length)];
            this.City = Cities[rng.Next(0, Cities.Length)];
        }

        public string Phrase { get; }
        public string Event { get; }
        public string Author { get; }
        public string City { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            RandomAdvertisement[] advertisements = new RandomAdvertisement[numberOfMessages];

            for (int i = 0; i < advertisements.Length; i++)
            {
                advertisements[i] = new RandomAdvertisement();
            }

            foreach (var advertisement in advertisements)
            {
                Console.WriteLine($"{advertisement.Phrase} {advertisement.Event} {advertisement.Author} - {advertisement.City}.");
            }
        }
    }
}
