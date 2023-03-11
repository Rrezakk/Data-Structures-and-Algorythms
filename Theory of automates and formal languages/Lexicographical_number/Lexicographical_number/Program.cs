using Lexicographical_number;
using Lexicographical_number_lib;
using System.Text.RegularExpressions;

Console.WriteLine("Lexicographical number calculations:");
Main();
string GetAlphabetUserInput()
{
    var alphabet = "";
    while (true)
    {
        Console.WriteLine($"Enter alphabet: ");
        alphabet = Console.ReadLine();
        if (string.IsNullOrEmpty(alphabet))
        {
            Console.WriteLine("String must be non-null and non-empty");
        }
        else if (!AlphabetChecks.CheckUnique(alphabet))
        {
            Console.WriteLine($"Alphabet characters must be unique");
        }
        else
        {
            break;
        }
    }
    return alphabet;
}
string GetWordUserInput(string alphabet)
{
    var word = "";
    while (true)
    {
        Console.WriteLine($"Enter word: ");
        word = Console.ReadLine();
        if (!AlphabetChecks.CheckWordFromThisAlphabet(alphabet, word))
        {
            Console.WriteLine($"Word must be constructed from alphabet characters!");
        }
        else
        {
            break;
        }
    }
    return word;
}
int GetLgNumberUserInput()
{
    var num = 0;
    while (true)
    {
        Console.WriteLine($"Enter l-g number: ");
        var n = Console.ReadLine();
        if (int.TryParse(n, out num))
        {
            break;
        }
        else
        {
            Console.WriteLine($"Try again!");
        }
    }
    return num;
}
void Main()
{
    var alphabet = GetAlphabetUserInput();
    while (true)
    {
        Console.WriteLine($"Options: ");
        Console.WriteLine($"1: Get word's number");
        Console.WriteLine($"2: Get word by number");
        Console.WriteLine($"3: Regex table");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine($"LG number is: {CalculateNumber(alphabet)}");
                break;
            case "2":
                Console.WriteLine($"Word is: {CalculateWord(alphabet)}");
                break;
            case "3":
                Console.Write($"Enter words count: ");
                var rowsStr = Console.ReadLine();
                if (int.TryParse(rowsStr,out var rows))
                {
                    var x = alphabet.ToList();
                    var mean = x.Select(c=>c-48).ToList();
                    var sequences = SubsequenceGenerator.GenerateBinary(rows,mean);
                    var regex = @"\d*00\d*";
                    foreach (var sequence in sequences)
                    {
                        if (Regex.IsMatch(sequence, regex))
                        {
                            Console.WriteLine($"Regex match: {sequence} -> lg num: {LgCalculator.CalculateNumber(alphabet,sequence,false)}");
                        }
                    }
                    Console.WriteLine($"Of total {sequences.Count} sequences");
                }
                break;
            default:
                Console.WriteLine("wrong option");
                break;
        }
       
    }
    int CalculateNumber(string alphabet)
    {
        var word = GetWordUserInput(alphabet);
        return LgCalculator.CalculateNumber(alphabet,word);
    }

    string CalculateWord(string alphabet)
    {
        var num = GetLgNumberUserInput();
        return LgCalculator.CalculateWord(alphabet,num);
    }
}
