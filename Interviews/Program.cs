using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interviews
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
                        ReplaceRepeats rr = new ReplaceRepeats("abc");
                        Console.WriteLine(rr.Execute());
                        rr.StringToUpdate = "aabbccc";
                        Console.WriteLine(rr.Execute());
                        rr.StringToUpdate = "aabbbbccccaaaa";
                        Console.WriteLine(rr.Execute());
                        break;
                    default:
                        break;
                }
            }
            Environment.Exit(0);
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
