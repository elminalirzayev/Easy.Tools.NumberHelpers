using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Tools.NumberHelpers.Extensions
{
    /// <summary>
    /// Extension methods for converting numbers to words in various languages, including currency formatting.
    /// </summary>
    public static class NumberToWordsExtensions
    {
        private static readonly Dictionary<string, (string Currency, string SubCurrency)> DefaultCurrencyNames = new()
        {
            ["en"] = ("dollar", "cent"),
            ["tr"] = ("Türk Lirası", "kuruş"),
            ["az"] = ("manat", "qəpik"),
            ["ru"] = ("рубль", "копейка")
        };

        private static readonly Dictionary<(string Lang, string Country), (string Currency, string SubCurrency)> CountryCurrencyNames =
     new Dictionary<(string Lang, string Country), (string Currency, string SubCurrency)>
             {
                { ("en", "US"), ("US dollar", "cent") },
                { ("en", "GB"), ("pound sterling", "penny") },
                { ("en", "CA"), ("Canadian dollar", "cent") },
                { ("en", "EU"), ("euro", "cent") },
                { ("tr", "TR"), ("Türk Lirası", "kuruş") },
                { ("az", "AZ"), ("manat", "qəpik") },
                { ("ru", "RU"), ("рубль", "копейка") },
             };

        /// <summary>
        /// Converts a decimal amount to its word representation in the specified language, including currency and sub-currency names.
        /// </summary>
        /// <param name="amount">The decimal amount to convert.</param>
        /// <param name="languageCode">The language code (default is "en").</param>
        /// <param name="countryCode">The country code (optional, used to get specific currency names).</param>
        /// <param name="currencyName">Custom currency name (optional).</param>
        /// <param name="subCurrencyName">Custom sub-currency name (optional).</param>
        /// <returns>The word representation of the amount in the specified language, formatted as currency.</returns>

        public static string ToWordsCurrency(this decimal amount, string languageCode = "en", string? countryCode = null,
            string? currencyName = null, string? subCurrencyName = null)
        {
            languageCode = languageCode.ToLower();
            countryCode = countryCode?.ToUpper();

            (string Currency, string SubCurrency) names;

            if (countryCode != null && CountryCurrencyNames.TryGetValue((languageCode, countryCode), out var countryNames))
            {
                names = countryNames;
            }
            else if (DefaultCurrencyNames.TryGetValue(languageCode, out var defaultNames))
            {
                names = defaultNames;
            }
            else
            {
                names = DefaultCurrencyNames["en"];
            }

            currencyName ??= names.Currency;
            subCurrencyName ??= names.SubCurrency;

            int whole = (int)Math.Floor(amount);
            int fraction = (int)((amount - whole) * 100);

            var wholeWords = whole.ToWords(languageCode);
            var fractionWords = fraction.ToWords(languageCode);

            if (fraction == 0)
                return $"{wholeWords} {currencyName}";

            return $"{wholeWords} {currencyName} {fractionWords} {subCurrencyName}";
        }



        private static readonly Dictionary<string, Dictionary<int, string>> LanguageMaps = new()
        {
            ["en"] = new Dictionary<int, string>
        {
            {0, "zero"}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"},
            {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"},
            {10, "ten"}, {11, "eleven"}, {12, "twelve"}, {13, "thirteen"},
            {14, "fourteen"}, {15, "fifteen"}, {16, "sixteen"},
            {17, "seventeen"}, {18, "eighteen"}, {19, "nineteen"},
            {20, "twenty"}, {30, "thirty"}, {40, "forty"}, {50, "fifty"},
            {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety"},
            {100, "hundred"}
        },
            ["tr"] = new Dictionary<int, string>
        {
            {0, "sıfır"}, {1, "bir"}, {2, "iki"}, {3, "üç"}, {4, "dört"},
            {5, "beş"}, {6, "altı"}, {7, "yedi"}, {8, "sekiz"}, {9, "dokuz"},
            {10, "on"}, {11, "on bir"}, {12, "on iki"}, {13, "on üç"},
            {14, "on dört"}, {15, "on beş"}, {16, "on altı"},
            {17, "on yedi"}, {18, "on sekiz"}, {19, "on dokuz"},
            {20, "yirmi"}, {30, "otuz"}, {40, "kırk"}, {50, "elli"},
            {60, "altmış"}, {70, "yetmiş"}, {80, "seksen"}, {90, "doksan"},
            {100, "yüz"}
        },
            ["az"] = new Dictionary<int, string>
        {
            {0, "sıfır"}, {1, "bir"}, {2, "iki"}, {3, "üç"}, {4, "dörd"},
            {5, "beş"}, {6, "altı"}, {7, "yeddi"}, {8, "səkkiz"}, {9, "doqquz"},
            {10, "on"}, {11, "on bir"}, {12, "on iki"}, {13, "on üç"},
            {14, "on dörd"}, {15, "on beş"}, {16, "on altı"},
            {17, "on yeddi"}, {18, "on səkkiz"}, {19, "on doqquz"},
            {20, "iyirmi"}, {30, "otuz"}, {40, "qırx"}, {50, "əlli"},
            {60, "altmış"}, {70, "yetmiş"}, {80, "səksən"}, {90, "doxsan"},
            {100, "yüz"}
        },
            ["ru"] = new Dictionary<int, string>
        {
            {0, "ноль"}, {1, "один"}, {2, "два"}, {3, "три"}, {4, "четыре"},
            {5, "пять"}, {6, "шесть"}, {7, "семь"}, {8, "восемь"}, {9, "девять"},
            {10, "десять"}, {11, "одиннадцать"}, {12, "двенадцать"}, {13, "тринадцать"},
            {14, "четырнадцать"}, {15, "пятнадцать"}, {16, "шестнадцать"},
            {17, "семнадцать"}, {18, "восемнадцать"}, {19, "девятнадцать"},
            {20, "двадцать"}, {30, "тридцать"}, {40, "сорок"}, {50, "пятьдесят"},
            {60, "шестьдесят"}, {70, "семьдесят"}, {80, "восемьдесят"}, {90, "девяносто"},
            {100, "сто"}, {200, "двести"}, {300, "триста"}, {400, "четыреста"},
            {500, "пятьсот"}, {600, "шестьсот"}, {700, "семьсот"},
            {800, "восемьсот"}, {900, "девятьсот"}
        }
        };

        private static readonly Dictionary<string, List<(long Value, string Singular, string Plural1, string Plural2)>> ScaleNumbers = new()
        {
            ["en"] = new()
        {
            (1_000_000_000_000, "trillion", "trillions", "trillions"),
            (1_000_000_000, "billion", "billions", "billions"),
            (1_000_000, "million", "millions", "millions"),
            (1_000, "thousand", "thousands", "thousands"),
            (100, "hundred", "hundreds", "hundreds")
        },
            ["tr"] = new()
        {
            (1_000_000_000_000, "trilyon", "trilyon", "trilyon"),
            (1_000_000_000, "milyar", "milyar", "milyar"),
            (1_000_000, "milyon", "milyon", "milyon"),
            (1_000, "bin", "bin", "bin"),
            (100, "yüz", "yüz", "yüz")
        },
            ["az"] = new()
        {
            (1_000_000_000_000, "trilyon", "trilyon", "trilyon"),
            (1_000_000_000, "milyard", "milyard", "milyard"),
            (1_000_000, "milyon", "milyon", "milyon"),
            (1_000, "min", "min", "min"),
            (100, "yüz", "yüz", "yüz")
        },
            ["ru"] = new()
        {
            (1_000_000_000_000, "триллион", "триллиона", "триллионов"),
            (1_000_000_000, "миллиард", "миллиарда", "миллиардов"),
            (1_000_000, "миллион", "миллиона", "миллионов"),
            (1_000, "тысяча", "тысячи", "тысяч"),
            (100, "сто", "ста", "ста")
        }
        };

        /// <summary>
        /// Converts a long number to its word representation in the specified language.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <param name="lang">The language code (default is "en").</param>
        /// <returns>The word representation of the number.</returns>
        public static string ToWords(this long number, string lang = "en")
        {
            lang = lang.ToLower();
            if (!LanguageMaps.ContainsKey(lang))
                lang = "en";

            if (number == 0)
                return LanguageMaps[lang][0];

            if (number < 0)
                return lang switch
                {
                    "tr" => "eksi " + ToWords(-number, lang),
                    "az" => "mənfi " + ToWords(-number, lang),
                    "ru" => "минус " + ToWords(-number, lang),
                    _ => "minus " + ToWords(-number, lang)
                };

            return ConvertNumberToWords(number, lang);
        }

        /// <summary>
        /// Converts an integer to its word representation in the specified language.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <param name="lang">The language code (default is "en").</param>
        /// <returns>The word representation of the number.</returns>
        public static string ToWords(this int number, string lang = "en") =>
             ((long)number).ToWords(lang);

        /// <summary>
        /// Converts a short number to its word representation in the specified language.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <param name="lang">The language code (default is "en").</param>
        /// <returns>The word representation of the number.</returns>
        public static string ToWords(this short number, string lang = "en") =>
            ((long)number).ToWords(lang);

        /// <summary>
        /// Converts a byte number to its word representation in the specified language.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <param name="lang">The language code (default is "en").</param>
        /// <returns>The word representation of the number.</returns>
        public static string ToWords(this byte number, string lang = "en") =>
            ((long)number).ToWords(lang);

        /// <summary>
        /// Converts a float number to its word representation in the specified language.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <param name="lang">The language code (default is "en").</param>
        /// <returns>The word representation of the number.</returns>
        public static string ToWords(this float number, string lang = "en") =>
        ((long)number).ToWords(lang);

        private static string ConvertNumberToWords(long number, string lang)
        {
            if (number < 21)
            {
                return LanguageMaps[lang].ContainsKey((int)number) ? LanguageMaps[lang][(int)number] : number.ToString();
            }

            if (number < 100)
            {
                int tens = (int)(number / 10) * 10;
                int ones = (int)(number % 10);
                var map = LanguageMaps[lang];
                if (lang == "tr" || lang == "az")
                    return ones == 0 ? map[tens] : map[tens] + " " + map[ones];
                else
                    return ones == 0 ? map[tens] : map[tens] + "-" + map[ones];
            }

            foreach (var scale in ScaleNumbers[lang])
            {
                if (number >= scale.Value)
                {
                    long scaleCount = number / scale.Value;
                    long remainder = number % scale.Value;

                    string scaleWord = GetScaleWord(scale, scaleCount, lang);

                    string prefix = ConvertNumberToWords(scaleCount, lang) + " " + scaleWord;

                    if (remainder == 0)
                        return prefix;
                    else
                        return prefix + " " + ConvertNumberToWords(remainder, lang);
                }
            }

            return number.ToString();
        }

        private static string GetScaleWord((long Value, string Singular, string Plural1, string Plural2) scale, long count, string lang)
        {
            if (lang == "ru")
            {
                long n = count % 100;
                if (n > 10 && n < 20)
                    return scale.Plural2;
                n = count % 10;
                if (n == 1)
                    return scale.Singular;
                if (n >= 2 && n <= 4)
                    return scale.Plural1;
                return scale.Plural2;
            }
            return scale.Singular;
        }
    }

}
