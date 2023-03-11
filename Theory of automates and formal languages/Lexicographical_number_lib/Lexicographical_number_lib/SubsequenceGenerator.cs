namespace Lexicographical_number_lib;

public class SubsequenceGenerator
{
    public static List<string> GenerateBinary( int length,List<int> nums)
    {
        var values1 = new[] { 0,1 };
        var result = GetAllCombinations(nums,length);
        return result.Select(x => string.Join("", x.ToList())).ToList();
    }
    static IEnumerable< IEnumerable< T > > GetAllCombinations< T >(IEnumerable< T > list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });
 
        return GetAllCombinations(list, length - 1)
            .SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
    }
    static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }
}
