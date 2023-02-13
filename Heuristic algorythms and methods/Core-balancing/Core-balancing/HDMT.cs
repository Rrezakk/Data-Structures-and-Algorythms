namespace Core_balancing;

public class HDMT
{
    public static List<List<int>> Calc(List<int> data)
    {
        var duo = CmpG.Calc(data, 2);
        var result = new List<List<int>>();
        foreach (var d in duo)
        {
            result.AddRange(CmpG.Calc(d,2));
            result.Print();
        }
        return result;
    }
}
