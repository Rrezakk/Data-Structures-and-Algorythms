namespace Sheduling;

public class Sorting
{
    public static void gnomeSortWorks(ref (int, int,int)[] a)
    {
        var i = 1;
        var j = 2;

        while (i < a.Length)
        {
            if (a[i - 1].Item1 <= a[i].Item1)
            {
                i = j;
                j++;
            }
            else
            {
                (a[i - 1], a[i]) = (a[i], a[i - 1]);//swap
                i -= 1;
                if (i != 0) continue;
                i = 1;
                j = 2;
            }
        }
    }
    public static void gnomeSortTuples(ref (int, int)[] a)
    {
        var i = 1;
        var j = 2;

        while (i < a.Length)
        {
            if (a[i - 1].Item2 <= a[i].Item2)
            {
                i = j;
                j++;
            }
            else
            {
                (a[i - 1], a[i]) = (a[i], a[i - 1]);//swap
                i -= 1;
                if (i != 0) continue;
                i = 1;
                j = 2;
            }
        }
    }
    public static void gnomeSort(ref int[] a,ref int[] I,ref int[] J)
    {
        var i = 1;
        var j = 2;

        while (i < a.Length)
        {
            if (a[i - 1] <= a[i])
            {
                i = j;
                j++;
            }
            else
            {
                (a[i - 1], a[i]) = (a[i], a[i - 1]);//swap
                i -= 1;
                if (i != 0) continue;
                i = 1;
                j = 2;
            }
        }
    }
}
