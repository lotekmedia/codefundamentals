using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNACount
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = new string(args[0].Distinct().ToArray());
            Console.WriteLine(s);
            // 'A', 'C', 'G', and 'T' 
            Console.Write(args[0].Count(x => x == 'A'));
            Console.Write(' ');
            Console.Write(args[0].Count(x => x == 'C'));
            Console.Write(' ');
            Console.Write(args[0].Count(x => x == 'G'));
            Console.Write(' ');
            Console.Write(args[0].Count(x => x == 'T'));
            Console.ReadLine();
        }
        
    }
}
