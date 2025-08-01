using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Provides extension methods for math calculations.
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// Rounds the number to the nearest multiple of the specified value.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="nearest">The nearest multiple to round to.</param>
        /// <returns>The rounded number.</returns>
        public static int RoundToNearest(this int value, int nearest)
            => (int)(Math.Round((double)value / nearest) * nearest);

        /// <summary>
        /// Determines whether the number is even.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is even; otherwise, false.</returns>
        public static bool IsEven(this int number) => number % 2 == 0;

        /// <summary>
        /// Determines whether the number is odd.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is odd; otherwise, false.</returns>
        public static bool IsOdd(this int number) => number % 2 != 0;

        /// <summary>
        /// Determines whether the number is a prime number.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is prime; otherwise, false.</returns>
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Calculates the factorial of a number using iteration.
        /// </summary>
        /// <param name="number">The non-negative integer to calculate the factorial of.</param>
        /// <returns>The factorial value as a long.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the number is negative.</exception>
        public static long Factorial(this int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Factorial is not defined for negative numbers.");

            long result = 1;
            for (int i = 2; i <= number; i++)
                result *= i;

            return result;
        }

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two integers using the Euclidean algorithm.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of the two integers.</returns>
        public static int GCD(this int a, int b)
        {
            while (b != 0) (a, b) = (b, a % b);
            return a;
        }
      
        /// <summary>
        /// Calculates the least common multiple (LCM) of two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The least common multiple of the two integers.</returns>
        public static int LCM(this int a, int b)
        {
            return (a * b) / a.GCD(b);
        }
    }
}