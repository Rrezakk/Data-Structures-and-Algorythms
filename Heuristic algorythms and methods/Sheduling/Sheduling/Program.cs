using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using Console = Colorful.Console;

namespace Sheduling;

class Program
{
    public static void Main()
    {
        var matrix = new int[,]
        {
            {15,6,9},
            {8,11,7},
            {12,14,11}
        };//GenerateMatrix(3, 3, 6, 15);
        Program.PrintMatrix(matrix,out var fi,out var si);
        Program.PreSortFiSi(ref fi, ref si);
        Program.PrintArr(si, "I");
        Program.PrintArr(fi, "J");
        mark:;
        Console.WriteLine("Sorting _5_");
        Program.SortSiFi5(matrix,ref si,ref fi);
        Program.PrintArr(si, "I");
        Program.PrintArr(fi, "J");
        Console.WriteLine($"Searching for k's in J");
        FindKInJAndReplace(matrix, ref si, ref fi,out bool was);
        Program.PrintArr(si, "I");
        Program.PrintArr(fi, "J");
        Program.SortSiFi5(matrix,ref si,ref fi);
        Console.WriteLine($"End: ");
        Program.PrintArr(si, "I");
        Program.PrintArr(fi, "J");
        PrintResults(matrix, si, fi);
    }
    public static void PrintResults(int[,] matrix,int[] I,int[] J)
    {
        var acc = new int[I.Length];
        Console.Write("(");
        for (int i = 0; i < I.Length; i++)
        {
            acc[i] = matrix[I[i] - 1, J[i] - 1];
            Console.Write($"{acc[i]}   ");
        }
        Console.Write(")");
        Console.Write($" -> {acc.ToList().Max()}");

        Console.WriteLine();
    }
    public static void FindKInJAndReplace(int[,] matrix, ref int[] I, ref int[] J,out bool was)
    {
        was = false;
        for (var k = 1; k < J.Length; k++)
        {
            var p1 = matrix[I[0]-1, J[k]-1];
            var p2 = matrix[I[0]-1, J[0]-1];
            var p3 = matrix[I[k]-1, J[1]-1];
            var p4 = matrix[I[0]-1, J[0]-1];
            var statement = p1 < p2 && p3 < p4;
            Console.WriteLine($"{p1} <? {p2} {p3} <? {p4} -> {statement}");
            if (!statement) continue;
            (J[0], J[k]) = (J[k], J[0]);
            Console.WriteLine($"Swapping {J[0]} and {J[k]} in J");
            was = true;
            return;
        }
    }
    public static void SortSiFi5(int[,] matrix,ref int[] I, ref int[] J)
    {
        var sr = new (int, int, int)[I.Length];
        for (int i = 0; i < sr.Length; i++)
        {
            sr[i] = (matrix[I[i]-1,J[i]-1],I[i],J[i]);
            Console.WriteLine($"{sr[i].Item1} {sr[i].Item2} {sr[i].Item3}");
        }
        Sorting.gnomeSortWorks(ref sr);
        I = sr.Select(x => x.Item2).Reverse().ToArray();
        J = sr.Select(x => x.Item3).Reverse().ToArray();
    }
    
    public static int[,] GenerateMatrix(int x,int y,int min,int max)
    {
        var matrix = new int[x, y];
        matrix.Initialize();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = Random.Shared.Next(min, max + 1);
            }
        }
        return matrix;
    }
    public static void PrintMatrix(int[,] matrix,out int[] coll,out int[] row)
    {
        var x = matrix.GetLength(0);
        var y = matrix.GetLength(1);
        
        coll = new int[y];
        row = new int[x];
        Console.WriteLine("-------------------------------------");
        for (int i = 0; i < coll.Length; i++)
        {
            Console.Write($"{$"p{i+1}",4}");
        }
        Console.WriteLine($" {"fi",4}");
        for (int i = 0; i < x; i++)
        {
            var acc = 0;
            for (int j = 0; j < y; j++)
            {
                Console.Write($"{matrix[i,j],4}");
                acc += matrix[i, j];
                if (j == y-1)
                {
                    Console.Write($" | {acc}");
                    row[i] = acc;
                }
            }
            Console.WriteLine();
        }
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                coll[i] += matrix[j, i];

            }
        }
        for (int i = 0; i < coll.Length; i++)
        {
            Console.Write($"{"--",4}");
        }
        Console.WriteLine();
        for (int i = 0; i < coll.Length; i++)
        {
            Console.Write($"{coll[i],4}");
        }
        Console.WriteLine();
        Console.WriteLine("-------------------------------------");
    }
    public static void PreSort(ref int[] fi)
    {
        var middle = new (int, int)[fi.Length];
        for (int i = 0; i < fi.Length; i++)
        {
            middle[i] = ((i,fi[i]));
        }
        Sorting.gnomeSortTuples(ref middle);
        fi = middle.Select(x => x.Item1+1).Reverse().ToArray();
    }
    public static void PreSortFiSi(ref int[] fi, ref int[] si)
    {
        PreSort(ref fi);
        PreSort(ref si);
    }
    public static void PrintArr(int[] arr, string name)
    {
        Console.Write($"{name}: ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i],4}");
        }
        Console.WriteLine();
    }
}