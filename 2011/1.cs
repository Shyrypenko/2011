using System;

class Program
{
    static void Main()
    {
        Func<string, string, bool> containsWord = (text, word) => text.Contains(word, StringComparison.OrdinalIgnoreCase);

        string text = "This is a sample text to test the lambda.";
        string wordToCheck = "sample";

        Console.WriteLine($"Does the text contain the word '{wordToCheck}'? {containsWord(text, wordToCheck)}");
    }
}