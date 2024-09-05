using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsNum = int.Parse(Console.ReadLine());
            int[] wagonPassangersNum = new int[wagonsNum];
            int passangersSum = 0;

            for (int i = 0; i < wagonPassangersNum.Length; i++)
            {
                wagonPassangersNum[i] = int.Parse(Console.ReadLine());
                passangersSum += wagonPassangersNum[i];
            }

            Console.WriteLine($"{string.Join(" ", wagonPassangersNum)}\n" +
                $"{passangersSum}");
        }
    }
}
