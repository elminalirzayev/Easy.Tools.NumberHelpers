using System;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for formatting numbers into human-readable strings.
    /// </summary>
    public static class FormatExtensions
    {
        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        /// <summary>
        /// Converts a byte count into a human-readable file size string (e.g., "1.5 MB").
        /// </summary>
        /// <param name="value">The size in bytes.</param>
        /// <param name="decimalPlaces">The number of decimal places to show. Default is 1.</param>
        /// <returns>Formatted string representing the file size.</returns>
        public static string ToFileSize(this long value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + ToFileSize(-value, decimalPlaces); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // log10(1024) is approx 3.0103. 
            // Finding the magnitude (index in SizeSuffixes array).
            int mag = (int)Math.Log(value, 1024);

            // Adjust the value to the unit
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // Determine correct rounding format
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        /// <summary>
        /// Converts a large number into a metric abbreviation (e.g., 1500 -> "1.5k", 1000000 -> "1M").
        /// </summary>
        /// <param name="value">The number to format.</param>
        /// <returns>The formatted string.</returns>
        public static string ToMetric(this long value)
        {
            if (value < 1000) return value.ToString();

            if (value < 10000)
                return String.Format("{0:#,.##}k", value - 5);

            if (value < 100000)
                return String.Format("{0:#,.#}k", value - 50);

            if (value < 1000000)
                return String.Format("{0:#,.}k", value - 500);

            if (value < 10000000)
                return String.Format("{0:#,,.##}M", value - 5000);

            if (value < 100000000)
                return String.Format("{0:#,,.#}M", value - 50000);

            if (value < 1000000000)
                return String.Format("{0:#,,.}M", value - 500000);

            return String.Format("{0:#,,,.##}B", value - 5000000);
        }


        /// <summary>
        /// Converts an integer to an ordinal string based on language rules.
        /// <para>EN: 1st, 2nd, 3rd, 4th...</para>
        /// <para>TR: 1., 2., 3. (Standard dot notation)</para>
        /// <para>AZ: 1-ci, 2-ci, 3-cü, 4-cü (Vowel harmony rules)</para>
        /// <para>RU: 1-й, 2-й, 3-й (Standard masculine abbreviation)</para>
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <param name="lang">Language code ("en", "tr", "az", "ru"). Default is "en".</param>
        /// <returns>Ordinal string.</returns>
        public static string ToOrdinal(this int number, string lang = "en")
        {
            if (number <= 0) return number.ToString();

            lang = lang.ToLower();

            return lang switch
            {
                "tr" => $"{number}.",
                "ru" => $"{number}-й",
                "az" => GetAzerbaijaniOrdinal(number),
                _ => GetEnglishOrdinal(number)
            };
        }

        /// <summary>
        /// Handles English ordinal rules (st, nd, rd, th).
        /// </summary>
        private static string GetEnglishOrdinal(int number)
        {
            switch (number % 100)
            {
                case 11:
                case 12:
                case 13:
                    return number + "th";
            }

            return (number % 10) switch
            {
                1 => number + "st",
                2 => number + "nd",
                3 => number + "rd",
                _ => number + "th"
            };
        }

        /// <summary>
        /// Handles Azerbaijani ordinal suffixes based on vowel harmony (4-way harmony).
        /// Suffixes: -ci, -cı, -cü, -cu
        /// </summary>
        private static string GetAzerbaijaniOrdinal(int number)
        {
            int lastDigit = number % 10;

            string suffix = "ci"; // (Default)

            if (lastDigit != 0)
            {
                suffix = lastDigit switch
                {
                    1 or 2 or 5 or 7 or 8 => "ci", // bir, iki, beş, yeddi, səkkiz (i, e, ə -> i)
                    3 or 4 => "cü",                // üç, dörd (ü, ö -> ü)
                    6 => "cı",                     // altı (ı -> ı)
                    9 => "cu",                     // doqquz (u -> u)
                    _ => "ci"
                };
            }
            else
            {
                int lastTwoDigits = number % 100;

                if (lastTwoDigits == 10 || lastTwoDigits == 30)
                    suffix = "cu"; // on, otuz -> u
                else if (lastTwoDigits == 20 || lastTwoDigits == 50 || lastTwoDigits == 70 || lastTwoDigits == 80)
                    suffix = "ci"; // iyirmi, əlli, yetmiş, səksən -> i/ə
                else if (lastTwoDigits == 40 || lastTwoDigits == 60 || lastTwoDigits == 90)
                    suffix = "cı"; // qırx, altmış, doxsan -> ı/a
                else if (lastTwoDigits == 0) // 100, 200, 1000  vs.
                {
                    // Yüz (100) -> cü
                    // Min (1000) -> ci
                    // Milyon (1.000.000) -> cu
                    // Milyard (1.000.000.000) -> cı



                    if ((number / 100) % 10 != 0) // Sonunda 'yüz' (hundred) varsa
                        suffix = "cü";
                    else // Min, Milyon vs.
                        suffix = "ci"; // check later
                }
            }

            return $"{number}-{suffix}";
        }
    }
}