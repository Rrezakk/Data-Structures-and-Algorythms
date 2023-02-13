using Core_balancing;

var r = new Random();
const int processors = 4;
const int tasks = 11;
const int min = 10;
const int max = 20;

var a = Generate(tasks, min, max);
Console.WriteLine(string.Join(' ',a));
a.Sort();
a.Reverse();
Console.WriteLine(string.Join(' ',a));
var hd = new List<int>(a);
var of = new List<int>(a);


Console.WriteLine("CMP: ");
Console.WriteLine(string.Join(' ',a));
var result = CmpG.Calc(a, processors);
result.Print();

Console.WriteLine("HDMT: ");
Console.WriteLine(string.Join(' ',hd));
var hdmtResult = HDMT.Calc(hd);
hdmtResult.Print();

Console.WriteLine("OFMT: ");
Console.WriteLine(string.Join(' ',of));
var iterations = GetPow(processors);
var res = OFMT.Calc(processors, of, iterations);
res.Print();


List<int> Generate(int m, int min, int max)
{
    var result = new List<int>();
    for (var i = 0; i < m; i++)
    {
        result.Add(r.Next(min, max));
    }
    return result;
}
int GetPow(int n)
{
    var ctr = 0;
    while (n != 1)
    {
        n /= 2;
        ctr++;
    }
    return ctr;
}

