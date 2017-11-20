using System;

namespace PrimeTester
{
    public class UncachedSieve : IPrimeTestable
    {
        public bool IsPrime(int value)
        {
            if (value > 0)
            {
                // create a number line all set to false
                // mark all non-primes true as we find them
                bool[] numbers = new bool[(value + 1)];
                int loopLimit = (int)(Math.Sqrt(value));
                numbers[0] = true;
                numbers[1] = true;

                int m = 0;
                for (int i = 1; i <= loopLimit; i = m)
                {
                    // find the next prime m
                    for (m = i + 1; m <= value; m++)
                    {
                        if (!numbers[m])
                        {
                            break;
                        }
                    }

                    // mark all multiples of m non-prime
                    for (int j = m * 2; j <= value; j += m)
                    {
                        numbers[j] = true;
                    }
                }
                return !numbers[value];
            }
            return false;
        }
    }
}
