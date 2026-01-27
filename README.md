[![Build & Test](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/build.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/build.yml)
[![Build & Release](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/release.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/release.yml)
[![Build & Nuget Publish](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/nuget.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/actions/workflows/nuget.yml)
[![Release](https://img.shields.io/github/v/release/elminalirzayev/Easy.Tools.NumberHelpers)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/releases)
[![License](https://img.shields.io/github/license/elminalirzayev/Easy.Tools.NumberHelpers)](https://github.com/elminalirzayev/Easy.Tools.NumberHelpers/blob/master/LICENSE.txt)
[![NuGet](https://img.shields.io/nuget/v/Easy.Tools.NumberHelpers.svg)](https://www.nuget.org/packages/Easy.Tools.NumberHelpers)

# Easy.Tools.NumberHelpers

A comprehensive .NET library providing extension methods for advanced mathematical operations, number conversions, formatting, and banking-grade number-to-words transformation.

## Features

- **Number to Words:** Convert numbers to text in **English (en)**, **Turkish (tr)**, **Azerbaijani (az)**, and **Russian (ru)**.
- **Banking Mode:** Supports strict financial formatting (e.g., "Bir Yüz" vs "Yüz") for checks/invoices.
- **Math Utilities:** `GCD`, `LCM`, `Factorial`, `IsPrime`, `RoundToNearest`.
- **Roman Numerals:** High-performance conversion to/from Roman numerals (1-3999).
- **Percentages:** Easily calculate `PercentageOf`, `IncreaseByPercent`, etc.
- **Formatting:** Convert bytes to readable file sizes (`1.5 MB`) and numbers to metric (`1.2k`).
- **Precision Math:** Safe floating-point comparisons (`IsApproximately`).
- **Clamping:** Restrict numbers within a specific range easily.

## Installation

Install via NuGet Package Manager:

```bash
Install-Package Easy.Tools.NumberHelpers
```

Or via .NET CLI:

```bash
dotnet add package Easy.Tools.NumberHelpers
```


## Usage Examples

### 1. Number to Words (Currency & Banking)

Supports **USD, EUR, GBP, TRY, AZN, RUB** and custom currencies.

```csharp
using Easy.Tools.NumberHelpers.Extensions;

decimal amount = 1250.75m;

// Default English
// Output: "one thousand two hundred fifty dollar seventy-five cent"
Console.WriteLine(amount.ToWordsCurrency("en"));

// Turkish Banking Mode (Strict)
// Output: "bir bin iki yüz elli Türk Lirası yetmiş beş kuruş"
Console.WriteLine(amount.ToWordsCurrency("tr", isBankingMode: true));

// Normal Grammar
// Output: "bin iki yüz elli Türk Lirası yetmiş beş kuruş"
Console.WriteLine(amount.ToWordsCurrency("tr", isBankingMode: false));
```
### 2. File Size & Formatting

```csharp
long bytes = 10485760;
Console.WriteLine(bytes.ToFileSize()); // Output: "10 MB"

long views = 1500;
Console.WriteLine(views.ToMetric());   // Output: "1.5k"

int rank = 1;
Console.WriteLine(rank.ToOrdinal());   // Output: "1st"
```

### 3. Math & Logic

```csharp
int n = 7;
bool isPrime = n.IsPrime(); // true
long factorial = n.Factorial(); // 5040

int a = 12, b = 18;
int gcd = a.GCD(b); // 6
int lcm = a.LCM(b); // 36

double val = 0.1 + 0.2;
bool isEqual = val.IsApproximately(0.3); // true (solves floating point error)
```

### 4. Roman Numerals

```csharp
int year = 2024;
string roman = year.ToRoman(); // "MMXXIV"

int number = "MMXXIV".FromRoman(); // 2024
```

### 5. Percentage & Clamping

```csharp
double price = 100;
double newPrice = price.IncreaseByPercent(18); // 118

int input = 500;
int clamped = input.Clamp(0, 100); // 100 (Restricts value between min and max)
```

---

## Contributing

Contributions and suggestions are welcome. Please open an issue or submit a pull request.

---

## License

This project is licensed under the MIT License.

---

© 2025 Elmin Alirzayev / Easy Code Tools