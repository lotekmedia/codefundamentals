using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Multiples(1000));

            Fibonacci(4000000);
            Console.ReadLine();
        }

        public static void Fibonacci(int upper)
        {
            int a = 1;
            int b = 2;
            int result = 0;
            while (a < upper && b < upper)
            {
                int temp = a;
                a = b;
                b = temp + b;
                if (a % 2 == 0)
                {
                    result += a;
                }
            }
            Console.WriteLine(result);
        }

        public static int Multiples(int count){
            
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            return result;
        }
    }
}
