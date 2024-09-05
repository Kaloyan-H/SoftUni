using System;

namespace _02.Vehicles_Extension
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(
                double.Parse(carInput[1]),
                double.Parse(carInput[2]),
                double.Parse(carInput[3]));
            Vehicle truck = new Truck(
                double.Parse(truckInput[1]),
                double.Parse(truckInput[2]),
                double.Parse(truckInput[3]));
            Vehicle bus = new Bus(
                double.Parse(busInput[1]),
                double.Parse(busInput[2]),
                double.Parse(busInput[3]));

            int commandLinesNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandLinesNumber; i++)
            {
                string[] commandInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0].ToLower();
                string vehicle = commandInfo[1].ToLower();
                double value = double.Parse(commandInfo[2]);

                if (command == "driveempty")
                {
                    bus.Drive(value, false);
                }
                else if (command == "drive")
                {
                    if (vehicle == "car") 
                        car.Drive(value, false);
                    else if (vehicle == "truck") 
                        truck.Drive(value, false);
                    else if (vehicle == "bus")
                        bus.Drive(value, true);
                }
                else if (command == "refuel")
                {
                    if (vehicle == "car")
                        car.Refuel(value);
                    else if (vehicle == "truck")
                        truck.Refuel(value);
                    else if (vehicle == "bus")
                        bus.Refuel(value);
                }
            }

            Console.WriteLine($"{car}{Environment.NewLine}" +
                $"{truck}{Environment.NewLine}" +
                $"{bus}");
        }
    }
}
