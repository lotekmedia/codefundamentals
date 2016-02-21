using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var selection = String.Empty;
            while (selection != "q")
            {
                Console.WriteLine("1 - Permutations");
                Console.WriteLine("2 - String Replace");
                Console.WriteLine("3 - Replace Repeats");
                Console.WriteLine("Q - Quit");

                selection = Console.ReadLine().ToLower();

                switch (selection)
                {
                    case "1":
                        Console.WriteLine(IsPermutation("a", "a")); //True
                        Console.WriteLine(IsPermutation("asd", "dsa"));//True
                        Console.WriteLine(IsPermutation("abb", "bbb"));//False
                        Console.WriteLine(IsPermutation("abc", "abcd"));//False
                        break;
                    case "2":
                        Console.WriteLine(ReplaceString("My John Smith"));
                        break;
                    case "3":
                        Console.WriteLine(ReplaceRepeats("abc"));
                        Console.WriteLine(ReplaceRepeats("aabbccc"));
                        Console.WriteLine(ReplaceRepeats("aabbbbccccaaaa"));
                        break;
                    default:
                        break;
                }
            }
        }

        private static string ReplaceRepeats(string StringToUpdate)
        {
            if (countCompression(StringToUpdate) >= StringToUpdate.Length)
            {
                return StringToUpdate;
            }
            int currentCount = 1;
            char currentChar = StringToUpdate[0];
            StringBuilder sb = new StringBuilder();
            sb.Append(currentChar);
            for (int i = 1; i < StringToUpdate.Length; i++)
            {
                if (currentChar == StringToUpdate[i])
                {
                    currentCount++;
                }
                else
                {
                    sb.Append(currentCount);
                    currentChar = StringToUpdate[i];
                    sb.Append(currentChar);
                    currentCount = 1;
                }
            }
            sb.Append(currentCount);
            return sb.ToString();
        }

        private static int countCompression(string StringToUpdate)
        {
            if (String.IsNullOrEmpty(StringToUpdate))
            {
                return 0;
            }
            int size = 0;
            int count = 1;
            char last = StringToUpdate[0];
            for (int i = 1; i < StringToUpdate.Length; i++)
            {
                if (StringToUpdate[i] == last)
                {
                    count++;
                }
                else
                {
                    last = StringToUpdate[i];
                    size += 1 + count.ToString().Length;
                    count = 1;
                }
            }
            size += 1 + count.ToString().Length;
            return size;
        }

        private static string ReplaceString(string StringToReplace)
        {
            return StringToReplace.Replace(" ", "%20");
        }

        private static bool IsPermutation(string FirstString, string SecondString)
        {
            bool isPermutation = true;

            if (String.IsNullOrEmpty(FirstString) || String.IsNullOrEmpty(SecondString) || FirstString.Length != SecondString.Length)
            {
                return false;
            }
            int curLength = 0;
            while (isPermutation && curLength < FirstString.Length)
            {
                if (!SecondString.Contains(FirstString[curLength]))
                {
                    isPermutation = false;
                }
                curLength++;
            }

            return isPermutation;
        }
    }
}
