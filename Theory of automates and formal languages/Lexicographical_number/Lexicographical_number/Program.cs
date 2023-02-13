using Lexicographical_number;
using Lexicographical_number_lib;

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
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine($"LG number is: {CalculateNumber(alphabet)}");
                break;
            case "2":
                Console.WriteLine($"Word is: {CalculateWord(alphabet)}");
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
