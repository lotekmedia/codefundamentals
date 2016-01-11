using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;

            //SumSquare(100);
            //GetSmallestMultiple(20);
            //GetPalindrome(100,999);
            //GetPrimeFactors(600851475143);
            //FibonacciSum(4000000);
            //Multiples3and5(1000);
            //CountOccurences(args[0]);

            Debug.WriteLine(DateTime.Now - start);
        }

        private static void SumSquare(int count)
        {
            double sumsq = 0;
            double sqsum = 0;

            for (double i = 1; i <= count; i++)
            {
                sumsq += Math.Pow(i,2);
                sqsum += i;
            }
            sqsum = Math.Pow(sqsum,2);
            Debug.WriteLine(sqsum - sumsq);
        }

        private static void GetSmallestMultiple(int count)
        {
            var found = false;
            var num = 100;
            var result = 100;
            while (!found)
            {
                for (int i = 2; i <= count; i++)
                {
                   if (num % i != 0){
                       break;
                   }
                   else if (i == count)
                   {
                       result = num;
                       found = true;
                   }
                }
                num++;
            }
            Debug.WriteLine(result);
        }


        private static void GetPalindrome(int low, int high)
        {
            var final = 0;
            for(var i=high; i>low; i--)
            {
                for(var j=high; j>low; j--)
                {
                    var mul = j*i;
                    if(isPalin(mul)){
                        if (mul > final)
                        {
                            final = mul;
                        }
                    }
                }
            }
            Debug.WriteLine(final);            
        }

        private static bool isPalin(int i)
        {
            var irev = i.ToString().ToCharArray();
            Array.Reverse(irev);
            var iresult = new string(irev);
            return i.ToString() == iresult;
        }

        private static void GetPrimeFactors(long num)
        {
            var factors = GetFactors(num);
            for (int i = 0; i < factors.ToList().Count(); i++)
            {
                Debug.WriteLine(factors.ToList()[i]);
            }
            //factors.ToList().ForEach(Console.WriteLine);
        }

        private static IEnumerable<long> GetFactors(long input)
        {
            long max = Convert.ToInt64(Math.Sqrt(input));
            long first = Primes(max)
                .TakeWhile(x => x <= Math.Sqrt(input))
                .FirstOrDefault(x => input % x == 0);
            return first == 0
                    ? new[] { input }
                    : new[] { first }.Concat(GetFactors(input / first));
        }

        /* Begin Primes */
        public static IEnumerable<long> PotentialPrimes()
        {
            yield return 2;
            yield return 3;
            long k = 1;
            while (k > 0)
            {
                yield return 6 * k - 1;
                yield return 6 * k + 1;
                k++;
            }
        }

        public static IEnumerable<long> Primes(long count)
        {
            var memoized = new List<long>();
            long sqrt = 1;
            var primes = PotentialPrimes().Where(x =>
            {
                sqrt = GetSqrtCeiling(x, sqrt);
                return !memoized
                            .TakeWhile(y => y <= sqrt)
                            .Any(y => x % y == 0);
            });

            var current = 1;
            foreach (long prime in primes)
            {
                //Get x number prime
                if (current == count)
                {
                    Debug.WriteLine(prime);
                    yield return prime;
                    break;
                }
                current++;
                //end get x number prime
                yield return prime;
                memoized.Add(prime);
            }
        }

        private static long GetSqrtCeiling(long value, long start)
        {
            while (start * start < value)
            {
                start++;
            }
            return start;
        }
        /* End Prime */

        private static void FibonacciSum(int p)
        {
            var result = 0;
            var a = 1;
            var b = 2;
            var tmp = 0;
            Debug.Write(a);
            while (a < p && b < p)
            {
                tmp = b;
                b = a + b;
                a = tmp;
                if (a % 2 == 0)
                {
                    result += a;
                }
                Debug.Write(',');
                Debug.Write(a);
            }
            Debug.WriteLine(' ');
            Debug.WriteLine(result);
        }

        public static void Multiples3and5(int limit)
        {
            var result = 0;
            for (int i = 0; i < limit; i++)
            {
                if (i % 5 == 0 || i % 3 == 0)
                {
                    result += i;
                }
            }
            Debug.WriteLine(result);
        }

        public static void CountOccurences(string input)
        {
            Debug.Write(input.Count(c => c == 'A'));
            Debug.Write(' ');
            Debug.Write(input.Count(c => c == 'C'));
            Debug.Write(' ');
            Debug.Write(input.Count(c => c == 'G'));
            Debug.Write(' ');
            Debug.Write(input.Count(c => c == 'T'));
        }
    }
}
