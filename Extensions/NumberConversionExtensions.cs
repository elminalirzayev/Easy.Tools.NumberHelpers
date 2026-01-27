using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for converting numbers to and from Roman numerals.
    /// </summary>
    public static class NumberConversionExtensions
    {
        // Static mappings for performance (Allocated only once)
        private static readonly (int Value, string Symbol)[] RomanNumerals =
        {
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
            (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
            (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
        };

        private static readonly Dictionary<char, int> RomanToNumberMap = new()
        {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
            {'C', 100}, {'D', 500}, {'M', 1000}
        };

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

            // StringBuilder is much faster than string concatenation in loops
            var sb = new StringBuilder();

            foreach (var (value, symbol) in RomanNumerals)
            {
                while (number >= value)
                {
                    sb.Append(symbol);
                    number -= value;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts a Roman numeral string to its integer representation.
        /// </summary>
        /// <param name="roman">The Roman numeral string.</param>
        /// <returns>The equivalent integer value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when the input string contains invalid characters.</exception>
        public static int FromRoman(this string roman)
        {
            if (string.IsNullOrWhiteSpace(roman))
                throw new ArgumentNullException(nameof(roman));

            int total = 0;
            int prev = 0;

            // ToUpper() ensures case-insensitivity.
            foreach (var c in roman.ToUpper())
            {
                if (!RomanToNumberMap.TryGetValue(c, out int value))
                    throw new ArgumentException($"Invalid Roman character: {c}", nameof(roman));

                // If current value is greater than previous, it means subtraction (e.g., IV: 1 < 5)
                // We added 'prev' in the previous step, so we subtract it twice (undo addition + subtract)
                total += value > prev ? value - 2 * prev : value;
                prev = value;
            }

            return total;
        }
    }
}