using System;
using System.Linq;

namespace _04.Pizza_Calories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = string.Join("", Console.ReadLine().Skip(6));
            Pizza pizza;
            try
            {
                pizza = new Pizza(pizzaName);
            }
            catch (ArgumentException c)
            {
                Console.WriteLine(c.Message);
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END") return;
                }
            }
            string[] doughArgs = string.Join("", Console.ReadLine().Skip(6))
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                pizza.Dough = new Dough
                    (doughArgs[0], 
                    doughArgs[1],
                    double.Parse(doughArgs[2]));
            }
            catch (ArgumentException c)
            {
                Console.WriteLine(c.Message);
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END") return;
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    Console.WriteLine(pizza);
                    return;
                }

                string[] toppingArgs = string.Join("", input.Skip(8))
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    pizza.AddTopping(new Topping
                        (toppingArgs[0],
                        double.Parse(toppingArgs[1])));
                }
                catch (ArgumentException c)
                {
                    Console.WriteLine(c.Message);
                    while (true)
                    {
                        string input1 = Console.ReadLine();
                        if (input1 == "END") return;
                    }
                }
            }
        }
    }
}
