using System;

namespace _01.Class_Box_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}{Environment.NewLine}" +
                    $"Lateral Surface Area - {box.LateralSurfaceArea():f2}{Environment.NewLine}" +
                    $"Volume - {box.Volume():f2}");
            }
            catch (ArgumentException c)
            {
                Console.WriteLine(c.Message);
            }

        }
    }
}
