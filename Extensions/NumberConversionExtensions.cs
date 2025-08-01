using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for converting numbers to and from Roman numerals 
    /// </summary>
    public static class NumberConversionExtensions
    {
        /// <summary>
        /// Converts an integer to its Roman numeral representation.
        /// </summary>
        /// <param name="number">The number to convert (must be between 1 and 3999).</param>
        /// <returns>The Roman numeral representation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when number is not in the range 1 to 3999.</exception>
        public static string ToRoman(this int number)
        {
            if (number < 1 || number > 3999)
                throw new ArgumentOutOfRangeException(nameof(number), "Roman numerals are supported for values between 1 and 3999.");

            var map = new[] {
          (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
          (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
          (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
      };

            var result = "";
            foreach (var (value, symbol) in map)
            {
                while (number >= value)
                {
                    result += symbol;
                    number -= value;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a Roman numeral string to its integer representation.
        /// </summary>
        /// <param name="roman">The Roman numeral string.</param>
        /// <returns>The equivalent integer value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when the input string is not a valid Roman numeral.</exception>
        public static int FromRoman(this string roman)
        {
            if (string.IsNullOrWhiteSpace(roman))
                throw new ArgumentNullException(nameof(roman));

            var map = new Dictionary<char, int> {
          {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
          {'C', 100}, {'D', 500}, {'M', 1000}
      };

            int total = 0;
            int prev = 0;

            foreach (var c in roman.ToUpper())
            {
                if (!map.TryGetValue(c, out int value))
                    throw new ArgumentException("Invalid Roman numeral", nameof(roman));

                total += value > prev ? value - 2 * prev : value;
                prev = value;
            }

            return total;
        }

    }
}
