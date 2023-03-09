using System.Drawing;
using System.Text;

namespace Sheduling;

public class Minimax
{
    private const int Threads = 3;
    private const int Tasks = 4;
    private const int MinWeight = 1;
    private const int MaxWeight = 5;
    public static void Do()
    {
        var rows = Minimax.CreateRows(Tasks, Threads, MinWeight, MaxWeight);
        Panties.PrintMatrix(rows);
        rows.Sort((a,b)=>b.TotalLoad-a.TotalLoad);
        Panties.PrintMatrix(rows);
        var rp = ProcessRows(rows);
        Panties.PrintMatrixH(rp);
    }
    private static List<Row> ProcessRows(List<Row> rows)
    {
        var result = new List<Row>();
        foreach (var row in rows)
        {
            var r = new Row();
            var ind = row.Elems.IndexOf(row.Elems.Min());
            for (var i = 0; i < row.Elems.Count; i++)
            {
                r.Elems.Add(i == ind? row.Elems[i]:0);
            }
            result.Add(r);
        }
        return result;
    }
    private static List<Row> CreateRows(int rows,int threads, int min, int max)
    {
        var result = new List<Row>();
        for (var i = 0; i < rows; i++)
        {
            result.Add(Minimax.CreateRandomRow(threads,min,max));
        }
        return result;
    }
    private static Row CreateRandomRow(int n,int min,int max)
    {
        var row = new Row();
        for (var i = 0; i < n; i++)
        {
            row.Elems.Add(Random.Shared.Next(min,max+1));
        }
        return row;
    }
}
public class Panties
{
    public static void PrintMatrix(List<Row> matrix)
    {
        Console.WriteLine("-----------Matrix:----------------------");
        foreach (var row in matrix)
        {
            var sb = new StringBuilder();
            foreach (var element in row.Elems)
            {
                sb.Append($"{element,4}");
            }
            Console.Write(sb.ToString());
            Console.WriteLine($"{row.TotalLoad,4}",Color.Aqua);
        }
        Console.WriteLine("----------------------------------------");
    }
    public static void PrintMatrixH(List<Row> matrix)
    {
        var sb = new StringBuilder();
        Console.WriteLine("-----------Matrix:----------------------");
        foreach (var row in matrix)
        {
            foreach (var element in row.Elems)
            {
                sb.Append($"{element,4}");
            }
            Console.WriteLine(sb.ToString());
            sb.Clear();
        }
        for (var i = 0; i < matrix[0].Elems.Count; i++)
        {
            var acc = matrix.Sum(t => t.Elems[i]);
            sb.Append($"{acc,4}");
        }
        Console.WriteLine(sb.ToString(),Color.Aqua);
        Console.WriteLine("----------------------------------------");
    }
}
public class Row
{
    public Row(List<int> elems)
    {
        this.Elems = elems;
    }
    public Row()
    {
        
    }
    public readonly List<int> Elems = new();
    public int TotalLoad => Elems.Sum();

}
