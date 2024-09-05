using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(
                double.Parse(carInput[1]),
                double.Parse(carInput[2]));
            Vehicle truck = new Truck(
                double.Parse(truckInput[1]),
                double.Parse(truckInput[2]));

            int commandLinesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandLinesNumber; i++)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0].ToLower();
                string vehicle = commandInfo[1].ToLower();
                double value = double.Parse(commandInfo[2]);

                if (command == "drive")
                {
                    if (vehicle == "car") 
                        car.Drive(value);
                    else if (vehicle == "truck") 
                        truck.Drive(value);
                }
                else if (command == "refuel")
                {
                    if (vehicle == "car")
                        car.Refuel(value);
                    else if (vehicle == "truck")
                        truck.Refuel(value);
                }
            }

            Console.WriteLine($"{car}{Environment.NewLine}" +
                $"{truck}");
        }
    }
}
