using Easy.Tools.NumberHelpers.Extensions;

long number = 110100021;
decimal amount = 87364883.56M;

// Türkçe (tr)
Console.WriteLine(number.ToWords("tr")); 

// Azərbaycanca (az)
Console.WriteLine(number.ToWords("az")); 

// Russian (ru)
Console.WriteLine(number.ToWords("ru")); 

// English (en)
Console.WriteLine(number.ToWords("en")); 

Console.WriteLine(amount.ToWordsCurrency("en")); // English (en)
Console.WriteLine(amount.ToWordsCurrency("en","gb")); // English (en,gb)
Console.WriteLine(amount.ToWordsCurrency("en","eu")); //  English (en,eu)
Console.WriteLine(amount.ToWordsCurrency("az")); // Azərbaycanca (az)


