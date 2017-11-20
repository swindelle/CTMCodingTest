namespace PrimeTester
{
    public interface IPrimeTestable
    {
        /// <summary>
        /// Tests whether a number is prime
        /// </summary>
        /// <param name="value">number to test</param>
        /// <returns>true if prime</returns>
        bool IsPrime(int value);
    }
}
