using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            var primes = Primes4(400000);
            //foreach (var item in primes)
            //{
            //    Debug.WriteLine(item);
            //}
            Debug.WriteLine("Count:" + primes.Count());
            Debug.WriteLine(DateTime.Now - start);
        }

        public static IEnumerable<int> PotentialPrimes(int count)
        {
            yield return 2;
            yield return 3;
            int k = 1;
            while (k < count)
            {
                yield return 6 * k - 1;
                yield return 6 * k + 1;
                k++;
            }
        }

        public static IEnumerable<int> Primes4(int count)
        {
            var memoized = new List<int>();
            var primes = PotentialPrimes(count).Where(x =>
            {
                var sqrt = Math.Sqrt(x);
                return !memoized
                            .TakeWhile(y => y <= sqrt)
                            .Any(y => x % y == 0);
            });
            foreach (var prime in primes)
            {
                yield return prime;
                memoized.Add(prime);
            }
        }

        public static IEnumerable<int> Primes3(int count)
        {
            var memoized = new List<int>();
            return PotentialPrimes(count).Where(x =>
            {
                var sqrt = Math.Sqrt(x);
                return !PotentialPrimes(count)
                            .TakeWhile(y => y <= sqrt)
                            .Any(y => x % y == 0);
            });
	    }

        public static IEnumerable<int> Primes2(int count)
        {
            var ints = Enumerable.Range(2, count - 1);
            return ints.Where(x =>
            {
                var sqrt = Math.Sqrt(x);
                return !ints
                            .TakeWhile(y => y <= sqrt)
                            .Any(y => x % y == 0);
            });
        }

        public static IEnumerable<int> Primes1(int count)
        {
            var ints = Enumerable.Range(2, count - 1);
            return ints.Where(x => !ints
                            .TakeWhile(y => y <= Math.Sqrt(x))
                            .Any(y => x % y == 0));
        }

    }
}
