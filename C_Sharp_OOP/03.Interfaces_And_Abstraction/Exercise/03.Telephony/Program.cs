using System;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                if (smartphone.ValidNumber(number) == true)
                {
                    smartphone.Call(number);
                }
                else if (stationaryPhone.ValidNumber(number) == true)
                {
                    stationaryPhone.Call(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
            foreach (var url in urls)
            {
                if (smartphone.ValidUrl(url) == true)
                {
                    smartphone.Browse(url);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
