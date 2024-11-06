using System;

class Program
{
    static void Main()
    {
        string text = "The common type system\r\nIt's important to understand two fundamental points about the type system in .NET:\r\n\r\nIt supports the principle of inheritance. Types can derive from other types, called base types. The derived type inherits (with some restrictions) the methods, properties, and other members of the base type. The base type can in turn derive from some other type, in which case the derived type inherits the members of both base types in its inheritance hierarchy. All types, including built-in numeric types such as System.Int32 (C# keyword: int), derive ultimately from a single base type, which is System.Object (C# keyword: object). This unified type hierarchy is called the Common Type System (CTS). For more information about inheritance in C#, see Inheritance.\r\nEach type in the CTS is defined as either a value type or a reference type. These types include all custom types in the .NET class library and also your own user-defined types. Types that you define by using the struct keyword are value types; all the built-in numeric types are structs. Types that you define by using the class or record keyword are reference types. Reference types and value types have different compile-time rules, and different run-time behavior.\r\nThe following illustration shows the relationship between value types and reference types in the CTS"; // Indsæt din tekst her
        string wordToFind = "Type";

        int count = CountOccurrences(text, wordToFind);

        Console.WriteLine($"Ordet '{wordToFind}' vises {count} gange i teksten.");
    }

    static int CountOccurrences(string text, string word)
    {
        int count = 0;
        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string w in words)
        {
            if (string.Equals(w, word, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        return count;
    }
}
