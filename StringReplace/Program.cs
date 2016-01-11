using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            //AAAACCCGGT
            var result = String.Empty;
            var input = args[0];
            for (int i = input.Length-1; i >= 0; i--)
            {
                switch (input[i])
                {
                    case 'A':
                        result += 'T';
                        break;
                    case 'T':
                        result += 'A';
                        break;
                    case 'G':
                        result += 'C';
                        break;
                    case 'C':
                        result += 'G';
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
