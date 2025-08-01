[![Build & Test](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/build.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/build.yml)
[![Build & Release](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/release.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/release.yml)
[![Build & Nuget Publish](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/nuget.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/nuget.yml)
[![Release](https://img.shields.io/github/v/release/elminalirzayev/Easy.Tools.NumberHelpers)](https://github.com/elminalirzayev/auc-automaticly-usb-copier/releases)
[![License](https://img.shields.io/github/license/elminalirzayev/Easy.Tools.NumberHelpers)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/blob/master/LICENSE.txt)

# Easy.Tools.NumberHelpers

**Easy.Tools.NumberHelpers** is a .NET library that provides a rich set of extension methods for numeric operations. This package helps with common number manipulations such as clamping, rounding, percent calculations, and converting numbers to words in multiple languages.

---

## Installation

Install via NuGet:

```
dotnet add package Easy.Tools.NumberHelpers
```

Or via NuGet Package Manager:

```
Install-Package Easy.Tools.NumberHelpers
```

---

## Features

- Clamp values to a given range
- Calculate percentages
- Increase or decrease values by percentage
- Convert numbers to words in different languages
- Currency-aware number to word conversion (e.g., USD, EUR, TRY)
- Multilingual support (English, Turkish, Azerbaijani, Russian, and more)

---

## Supported Languages in `ToWords()`

- English (`en`)
- Turkish (`tr`)
- Azerbaijani (`az`)
- Russian (`ru`)
- More coming soon...

Currency names are mapped based on `(language, country)` and can be overridden as needed.

---

## Available Extensions

### General

```csharp
int number = 125;
number.Clamp(0, 100); // 100

double percent = 25.0;
100.0.PercentageOf(400);        // 25
100.0.IncreaseByPercent(10);    // 110
100.0.DecreaseByPercent(10);    // 90
```

### Number to Words

```csharp
123.ToWords("en"); // one hundred twenty-three
123.ToWords("tr"); // yüz yirmi üç
-45.ToWords("az"); // mənfi qırx beş
```

### Currency Words

```csharp
decimal amount = 1234.56m;
amount.ToCurrencyWords("en", "US"); // one thousand two hundred thirty-four US dollars and fifty-six cents
amount.ToCurrencyWords("tr", "TR"); // bin iki yüz otuz dört Türk Lirası ve elli altı kuruş
```

---

## License

MIT License.

---

© 2025 Elmin Alirzayev / Easy Code Tools
