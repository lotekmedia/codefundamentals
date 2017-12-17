using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
{
    class CustomData : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            CustomData dataToComp = obj as CustomData;
            if (dataToComp != null)
            {
                return this.StartedDate.CompareTo(dataToComp.StartedDate);
            }
            else
            {
                throw new ArgumentException("Not CustomData Type");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an unsorted array of string elements
            string[] unsorted = { "z", "e", "x", "c", "m", "q", "a", "b", "j", "q", "a", "z", "r", "r"};

            List<CustomData> unsortedList = new List<CustomData>();

            unsortedList.Add(new CustomData() { Id = 4, Name = "John", StartedDate = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0)) });
            unsortedList.Add(new CustomData() { Id = 3, Name = "Mark", StartedDate = DateTime.Now.Subtract(new TimeSpan(8, 0, 0, 0)) });
            unsortedList.Add(new CustomData() { Id = 1, Name = "Chris", StartedDate = DateTime.Now.Subtract(new TimeSpan(92, 0, 0, 0)) });
            unsortedList.Add(new CustomData() { Id = 2, Name = "Steve", StartedDate = DateTime.Now.Subtract(new TimeSpan(21, 0, 0, 0)) });
            unsortedList.Add(new CustomData() { Id = 5, Name = "Dominick", StartedDate = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0)) });

            CustomData[] unsortedArray = unsortedList.ToArray();

            for (int i = 0; i < unsortedArray.Length; i++)
            {
                Console.Write(unsortedArray[i].StartedDate.ToShortDateString() + " ");
            }
            Console.WriteLine();

            // Sort the array
            Quicksort(unsortedArray, 0, unsortedArray.Length - 1);

            for (int i = 0; i < unsortedArray.Length; i++)
            {
                Console.Write(unsortedArray[i].StartedDate.ToShortDateString() + " ");
            }

            // Print the unsorted array
            //for (int i = 0; i < unsorted.Length; i++)
            //{
            //    Console.Write(unsorted[i] + " ");
            //}

            //Console.WriteLine();
            // Sort the array
            //Quicksort(unsorted, 0, unsorted.Length - 1);

            // Print the sorted array
            //for (int i = 0; i < unsorted.Length; i++)
            //{
            //    Console.Write(unsorted[i] + " ");
            //}

            Console.WriteLine();

            Console.ReadLine();
        }

        public static void Quicksort(IComparable[] elements, int left, int right)
        {
            int leftTree = left, rightTree = right;
            IComparable pivot = elements[(left + right) / 2];

            while (leftTree <= rightTree)
            {
                while (elements[leftTree].CompareTo(pivot) < 0)
                {
                    leftTree++;
                }

                while (elements[rightTree].CompareTo(pivot) > 0)
                {
                    rightTree--;
                }

                if (leftTree <= rightTree)
                {
                    // Swap
                    if (leftTree != rightTree)
                    {
                        IComparable tmp = elements[leftTree];
                        elements[leftTree] = elements[rightTree];
                        elements[rightTree] = tmp;
                    }

                    leftTree++;
                    rightTree--;
                }
            }

            // Recursive calls
            if (left < rightTree)
            {
                Quicksort(elements, left, rightTree);
            }

            if (leftTree < right)
            {
                Quicksort(elements, leftTree, right);
            }
        }

    }
}