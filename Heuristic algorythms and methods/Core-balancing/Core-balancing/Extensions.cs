using System.Drawing;
using System.Text;
using Console = Colorful.Console;

namespace Core_balancing;

public static class Extensions
{
    public static int MinPowerIndex(this List<CmpG.Core> cores)
    {
        var minVal = int.MaxValue;
        var minIndex = -1;
        for (var i = 0; i < cores.Count; i++)
        {
            if (cores[i].Power >= minVal) continue;
            minIndex = i;
            minVal = cores[i].Power;
        }
        return minIndex;
    }
    public static void Print(this IEnumerable<CmpG.Core> cores)
    {
        cores.Select(x => x.GetTasks()).ToList().Print();
    }
    public static void Print(this List<List<int>> cores)
    {
        var lines = cores.Select(x => x.Count).Max();
        var sb = new StringBuilder();
        sb.Append("|");
        for (int i = 0; i < cores.Count; i++)
        {
            sb.Append($"  {i+1}  |");
        }
        Console.WriteLine(sb.ToString());
        sb.Clear();
        for (var i = 0; i < lines; i++)
        {
            sb.Append("|");
            for (var c = 0; c < cores.Count; c++)
            {
                try
                {
                    sb.Append($"{cores[c][i],5}|");
                }
                catch (Exception e)
                {
                    sb.Append($"     |");
                }
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
        sb.Append("|");
        for (var c = 0; c < cores.Count; c++)
        {
            sb.Append($"{cores[c].Sum(),5}|");
        }
        Console.WriteLine(sb.ToString(),Color.Aquamarine);
    }
}
