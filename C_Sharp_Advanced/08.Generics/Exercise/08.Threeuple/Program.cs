using System;
using System.Linq;

namespace _08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tuple <3

            //System.Boolean tru = !(true != false) ? true : true;
            //System.Boolean fls = !tru;


            string[] lineOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] lineTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] lineThree = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> nameAddressTown = new Threeuple<string, string, string>(
                $"{lineOne[0]} {lineOne[1]}",
                lineOne[2],
                $"{lineOne[3]}{(lineOne.Length == 5 ? " " + lineOne[4] : String.Empty)}");

            Threeuple<string, int, bool> nameBeerDrunk = new Threeuple<string, int, bool>(
                lineTwo[0],
                int.Parse(lineTwo[1]),
                lineTwo[2] == "drunk");

            Threeuple<string, double, string> nameBalanceBank = new Threeuple<string, double,string>(
                lineThree[0],
                double.Parse(lineThree[1]),
                lineThree[2]);


            Console.WriteLine($"{nameAddressTown.Item1} -> {nameAddressTown.Item2} -> {nameAddressTown.Item3}");
            Console.WriteLine($"{nameBeerDrunk.Item1} -> {nameBeerDrunk.Item2} -> {nameBeerDrunk.Item3}");
            Console.WriteLine($"{nameBalanceBank.Item1} -> {nameBalanceBank.Item2} -> {nameBalanceBank.Item3}");
        }
    }
}
