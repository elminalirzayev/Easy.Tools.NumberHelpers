using System;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for percentage-based calculations.
    /// </summary>
    public static class PercentageExtensions
    {
        /// <summary>
        /// Calculates what percentage the current value is of a total value.
        /// </summary>
        /// <param name="value">The part value.</param>
        /// <param name="total">The total value.</param>
        /// <returns>The percentage that <paramref name="value"/> is of <paramref name="total"/>.</returns>
        /// <exception cref="DivideByZeroException">Thrown when total is zero.</exception>
        public static double PercentageOf(this double value, double total)
        {
            if (total == 0)
                throw new DivideByZeroException("Total value cannot be zero.");

            return (value / total) * 100;
        }

        /// <summary>
        /// Increases the current value by a given percentage.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <param name="percent">The percentage to increase by.</param>
        /// <returns>The increased value.</returns>
        public static double IncreaseByPercent(this double value, double percent)
        {
            return value * (1 + (percent / 100));
        }

        /// <summary>
        /// Decreases the current value by a given percentage.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <param name="percent">The percentage to decrease by.</param>
        /// <returns>The decreased value.</returns>
        public static double DecreaseByPercent(this double value, double percent)
        {
            return value * (1 - (percent / 100));
        }
    }
}