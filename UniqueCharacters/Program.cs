using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine(IsUnique("abb"));
            DateTime end = DateTime.Now;
            Console.WriteLine(end - start);
            Console.ReadLine();
        }

        private static bool IsUnique(string stringToValidate)
        {
            //empty string or length of 1
            Console.WriteLine(stringToValidate);
            if (stringToValidate == null || stringToValidate.Length < 2)
            {
                return true;
            }
            List<char> existingCharacters = new List<char>();
            bool isUnique = true;
            var i = 0;
            while (i < stringToValidate.Length && isUnique)
            {
                if (existingCharacters.Contains(stringToValidate[i]))
                {
                    isUnique = false;
                }
                else
                {
                    existingCharacters.Add(stringToValidate[i]);
                }
                i++;
            }
            return isUnique;
        }
    }
}
