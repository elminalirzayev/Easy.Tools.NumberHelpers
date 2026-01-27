using System;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for safe floating-point comparisons.
    /// </summary>
    public static class FloatingPointExtensions
    {
        /// <summary>
        /// Checks if two double values are approximately equal within a specified tolerance.
        /// Solves floating-point precision issues (e.g., 0.1 + 0.2 == 0.3).
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <param name="tolerance">The tolerance (epsilon). Default is 1e-9.</param>
        /// <returns>True if values are approximately equal; otherwise false.</returns>
        public static bool IsApproximately(this double value, double other, double tolerance = 1e-9)
        {
            return Math.Abs(value - other) < tolerance;
        }

        /// <summary>
        /// Checks if two float values are approximately equal within a specified tolerance.
        /// </summary>
        /// <param name="value">The first value.</param>
        /// <param name="other">The second value.</param>
        /// <param name="tolerance">The tolerance (epsilon). Default is 1e-5f.</param>
        /// <returns>True if values are approximately equal; otherwise false.</returns>
        public static bool IsApproximately(this float value, float other, float tolerance = 1e-5f)
        {
            return Math.Abs(value - other) < tolerance;
        }
    }
}