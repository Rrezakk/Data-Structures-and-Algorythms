namespace Lexicographical_number;

public static class AlphabetChecks
{
    public static bool CheckUnique(string alphabet)
    {
        var set = new HashSet<char>();
        foreach (var c in alphabet)
        {
            if (!set.Add(c))
                return false;
        }
        return true;
    }
    public static bool CheckWordFromThisAlphabet(string alphabet, string word)
    {
        return word.All(c => (alphabet.Contains(c)));
    }
}
