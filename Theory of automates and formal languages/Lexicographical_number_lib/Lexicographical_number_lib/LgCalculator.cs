using System.Text;

namespace Lexicographical_number_lib;

public static class LgCalculator
{
    private static int Prefix( int position,int wordPower, int alphabetPower)
    {
        return (int)Math.Pow(alphabetPower, wordPower - position);
    }
    public static int CalculateNumber(string alphabet,string word)
    {
        if (string.IsNullOrEmpty(word))
            return 0;//empty word has 0 number
        var acc = 0;
        var wlen = word.Length;
        var alen = alphabet.Length;
        for (var i = 0; i < wlen; i++)
        {
            var c = word[i];
            var alphabetPosition = alphabet.IndexOf(c)+1;
            var wordPosition = i + 1;
            var num = LgCalculator.Prefix(wordPosition, wlen, alen)
                      * alphabetPosition;
            acc += num;
            Console.WriteLine($"alphabetPosition: {alphabetPosition} wordPosition: {wordPosition}");
            Console.WriteLine($"for {c} num is {num}");
        }
        return acc;
    }
    private static (int, int) Divide(int num,int alphabetPower)
    {
        var smth = num % alphabetPower;
        if (smth == 0)
        {
            return (num / alphabetPower - 1, alphabetPower);
        }
        else
        {
            return (num / alphabetPower, smth);
        }
    }
    public static string CalculateWord(string alphabet,int lgNum)
    {
        var sb = new StringBuilder();
        while (lgNum>0)
        {
            var (i, j) = Divide(lgNum, alphabet.Length);
            Console.WriteLine($"Iter: {i} * {alphabet.Length} + {j}");
            sb.Append(alphabet[j-1]);
            lgNum = i;
        }
        return sb.ToString();
    }
}
