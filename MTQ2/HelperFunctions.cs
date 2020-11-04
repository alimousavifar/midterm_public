using System;
using System.Collections.Generic;

namespace MTQ2
{
    public class HelperFunctions
    {


      /**
      * Finds a value within the supplied vector of integers
      * @param data array to search
      * @param val value to find
      * @return the index of the FIRST occurrence of the value val in data
      *         or -1 if not found
      */
        //===================================================================
        // TODO: Fix bugs in BinarySearch
        //===================================================================
        public static int BinarySearch(int[] data, int val) {

            int min = 0;
            int max = data.Length; // one beyond the top




            while (min<max) {
                int mid = (min + max - 1) / 2;
                int v = data[mid];
                // find first occurrence
                if (v == val && (mid == 0 || data[mid - 1] < val)) {
                    return (int) mid;
                } else if (val <= v) {
                    max = mid;
                } else
                {
                    min = mid + 1;
                }
            }

            if (data[min] != val)
            {
                return -2;
            }
            return (int)min;
        }

        //===================================================================
        // TODO: Write specification for GeneratePrimes
        //===================================================================
        public static List<int> GeneratePrimes(int n)
        {


            // There's no need to decipher the contents of this code,
            // just test some inputs/ outputs.

            // Modified sieve of eratosthenes
            // https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes


            // tight upper bound on number of primes, from Piere Dusart
            // used to pre-allocate memory for efficiency
            double logp = Math.Log(n);
            double maxLength = Math.Ceiling((n) / logp * (1.0 + 1.2762 / logp));
            List<int> primes = new List<int>(Convert.ToInt32(maxLength));
            primes.Add(2);  // first prime

            // details of prime range
            int sieve_min = 3;
            double sieveHalfMin = sieve_min / 2;
            double maxHalfPrime = n / 2;

            // compute prime sieve in blocks of up to 2^16
            double maxSieveSize = Math.Pow(2, 16);  // 2^16
            double sieveSize = maxSieveSize;
            if (maxHalfPrime > 0)
            {
                sieveSize = Math.Min(sieveSize, maxHalfPrime - sieveHalfMin + 1);
            }
            bool[] sieve = new bool[Convert.ToInt32(sieveSize)];

            // go through blocks
            while (sieveHalfMin <= maxHalfPrime)
            {
                for (int i = 0; i < sieve.Length; i++) { sieve[i] = false; }

                // mark all previous prime multiples
                int primeSize = primes.Count;
                for (int i = 1; i < primeSize; ++i)
                {
                    int p = primes[i];
                    int hp = p / 2;  // half-prime

                    // first multiple of prime in sieve
                    int hk = Math.Max(hp, (Convert.ToInt32(sieveHalfMin) + hp) / p);
                    int j = hk * p + hp - Convert.ToInt32(sieveHalfMin);
                    if (hp * (p + 1) > sieveHalfMin + Convert.ToInt32(sieveSize))
                    {
                        // outside of sieve block
                        break;
                    }
                    // mark off multiples as not prime
                    while (j < sieveSize)
                    {
                        sieve[j] = true;
                        j += p;
                    }
                }

                //loop through sieve to find next prime
                for (int i = 0; i < sieveSize; ++i)
                {
                    if (!sieve[i])
                    {
                        int hp = i + Convert.ToInt32(sieveHalfMin);
                        int p = 2 * hp + 1;
                        primes.Add((int)p);

                        int j = i + (2 * hp + 1) * hp;
                        while (j < sieveSize)
                        {
                            sieve[j] = true;
                            j += p;
                        }
                    }
                }

                // advance to next block
                sieveHalfMin += sieveSize;
                // next size
                sieveSize = maxSieveSize;
                if (maxHalfPrime > 0)
                {
                    sieveSize = Math.Min(sieveSize, maxHalfPrime - sieveHalfMin + 1);
                }
            }

            // if we went too far, knock off primes from the end
            List<int> indecies = new List<int>();
            foreach (var prime in primes)
            {
                if (prime >= n) {
                    indecies.Add(primes.IndexOf(prime));
                }
            }
            foreach (var index in indecies)
            {
                primes.RemoveAt(index);
            }

            return primes;

        }

        /**
         * Checks if a positive integer is prime
         * @param n integer to check, must satisfy 0 < n <= 2^31-1
         * @return true if number is prime, false otherwise
         */

        //===================================================================
        // TODO: Fix bugs in IsPrime
        //===================================================================
        public static bool IsPrime(int n)
        {

            // even number, obviously not prime
            if ((n % 2) == 0)
            {
                return false;
            }

            // default list of primes
            int limit = 46341;
            int[] primes = GeneratePrimes(limit).ToArray();

            // if it is within the bounds of the primes array,
            //    search for it
            if (n < limit)
            {
                int idx = BinarySearch(primes, n);
                return idx != -1;
            }

            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] * primes[i] > n)
                {
                    return true;
                }
                else if ((n % primes[i]) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
