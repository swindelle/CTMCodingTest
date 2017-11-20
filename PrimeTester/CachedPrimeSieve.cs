using System;
using System.Collections.Generic;

namespace PrimeTester
{
    public class CachedPrimeSieve : IPrimeTestable
    {
        private List<int> primes = new List<int>() { 2 };
        private int largestPrime = 2;

        public bool IsPrime(int value)
        {
            if (value <= 1)
            {
                return false;
            }
            else if (primes.Contains(value))
            {
                return true;
            }
            else
            {
                // add more primes
                int upperBound = (int)Math.Ceiling(Math.Sqrt(value));
                int lowerBound = largestPrime + 1;
                if (lowerBound <= upperBound)
                {
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        if (checkPrime(i))
                        {
                            primes.Add(i);
                            largestPrime = i;
                        }
                    }
                }
                // check value
                return checkPrime(value);
            }
        }

        private bool checkPrime(int i)
        {
            bool isPrime = true;
            foreach (var p in primes)
            {
                if (i % p == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}
