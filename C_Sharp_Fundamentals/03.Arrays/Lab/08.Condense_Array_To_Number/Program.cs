using System;
using System.Linq;

namespace _08.Condense_Array_To_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = nums.Length - 1; i > 0 ; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    nums[j] += nums[j + 1];
                }
            }

            Console.WriteLine(nums[0]);
        }
    }
}
