using Lexicographical_number;

Console.WriteLine("Lexicographical number calculations:");
Main();


string GetAlphabet()
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
string GetWord(string alphabet)
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
void Main()
{
    var alphabet = GetAlphabet();
    while (true)
    {
        Console.WriteLine($"Options: ");
        Console.WriteLine($"1: Get word's number");
        Console.WriteLine($"2: Get word by number");
        var input = Console.ReadLine();
        try
        {
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
        catch (Exception e)
        {
            Console.WriteLine("wrong option");
        }
    }
}
int CalculateNumber(string alphabet)
{
    var word = GetWord(alphabet);
    if (string.IsNullOrEmpty(word))
        return 0;//empty word has 0 number
    
    throw new NotImplementedException();
}
string CalculateWord(string s)
{
    throw new NotImplementedException();
}