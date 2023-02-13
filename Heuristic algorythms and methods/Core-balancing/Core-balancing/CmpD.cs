namespace Core_balancing;

public class CmpD
{
    public static int Sum(List<int> a)
    {
        var ans = 0;
        foreach (var i in a)
        {
            ans += i;
        }
        return ans;
    }
    static void Print(List<int> c)
    {
        foreach (var i in c)
        {
            Console.Write(i);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
    public static CMPDivideResult Divide(List<int> data)
    {
        var result = new CMPDivideResult();
        var fA = new List<int>();
        var sA = new List<int>();
        foreach (var d in data)
        {
            if (Sum(fA) > Sum(sA))
            {
                sA.Add(d);
            }
            else
            {
                fA.Add(d);
            }
        }
        result.nums1 = fA;
        result.nums2 = sA;
        return result;
    }
    public class CMPDivideResult
    {
        public List<int> nums1 = new List<int>();
        public List<int> nums2 = new List<int>();
    }
}
