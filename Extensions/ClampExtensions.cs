namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for clamping numeric values within a specified range.
    /// </summary>
    public static class ClampExtensions
    {
        /// <summary>
        /// Clamps an integer value between a minimum and maximum value.
        /// </summary>
        /// <param name="value">The integer value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>The clamped integer value within the specified range.</returns>
        public static int Clamp(this int value, int min, int max)
        {
            if (min > max)
                throw new ArgumentException("min cannot be greater than max.");
            return Math.Min(Math.Max(value, min), max);
        }

        /// <summary>
        /// Clamps a double value between a minimum and maximum value.
        /// </summary>
        /// <param name="value">The double value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>The clamped double value within the specified range.</returns>
        public static double Clamp(this double value, double min, double max)
        {
            if (min > max)
                throw new ArgumentException("min cannot be greater than max.");
            return Math.Min(Math.Max(value, min), max);
        }
    }
}
