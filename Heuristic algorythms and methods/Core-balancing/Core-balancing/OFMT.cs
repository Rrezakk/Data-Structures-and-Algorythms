namespace Core_balancing;

public class OFMT
{
    public static List<List<int>> Calc(int n,List<int> data,int iterations)
    {
        var r = CmpG.Calc(data,2);
        List<List<int>> result;
        var result2 = new List<List<int>>{r[0],r[1]};
        var ctr = 1;
        m:;
        if (ctr >= iterations)
            goto en;
        result = new List<List<int>>(result2);
        foreach (var divide in result.Select(d => CmpG.Calc(d,2)))
        {
            result2.Add(divide[0]);
            result2.Add(divide[1]);
        }
        result2.RemoveAt(0);
        result2.RemoveAt(0);
        ctr++;
        goto m;
        en:;
        result = new List<List<int>>(result2);
        return result;
    }
}
