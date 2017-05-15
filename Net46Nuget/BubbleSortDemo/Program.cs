using DotNextPdbDemo;
using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            if (0 == args.Length)
            {
                RunTest();
            }
            else
            {
                int iterations = int.Parse(args[0]);
                for (int i = 0; i < iterations; i++)
                {
                    RunTest();
                }
            }
        }

        private static void RunTest()
        {
            int[] array = { 1, 5, 6, 2, 10, 3, 20, 2 };
            Print(array);
            BubbleSort.Sort(array);
            Print(array);
        }

        private static void Print(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"   {item}");
            }
            Console.WriteLine();
        }
    }
}
