using System;
using System.Collections.Generic;

namespace MissingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 6, 3, 4, 2 };
            List<int> output = new List<int>();

            Array.Sort(input);
            foreach (int item in input)
            {
                Console.Write(item + " ");
            }
            int len = input[input.Length - 1];
            for (int i = 0; i < len; i++)
            {
                if (Array.IndexOf(input, i) < 0)
                {
                    output.Add(i);

                }
            }
            Console.WriteLine();
            foreach (var item in output)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
