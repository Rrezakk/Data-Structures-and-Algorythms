namespace Core_balancing;

public static class CmpG
{
    public static List<List<int>> Calc(List<int> data, int coresN)
    {
        var cores = new List<Core>(coresN);
        //generation
        for (var i = 0; i < coresN; i++)
        {
            var task = data.FirstOrDefault(-1);
            if (task!=-1)
            {
                data.RemoveAt(0);
                cores.Add(new Core(task));
            }
            else
            {
                cores.Add(new Core());
            }
            Console.WriteLine("------------------------------------");
            cores.Print();
        }
        
        foreach (var d in data)
        {
            var core = cores.MinPowerIndex();
            cores[core].AddTask(d);
            Console.WriteLine("------------------------------------");
            cores.Print();
        }
        return cores.Select(x => x.GetTasks()).ToList();
    }
    public class Core
    {
        public int Power =0;
        private readonly List<int> _tasks = new List<int>();
        public void AddTask(int task)
        {
            _tasks.Add(task);
            Power += task;
        }
        public List<int> GetTasks() => this._tasks;
        public Core()
        {
            
        }
        public Core(int firstTask)
        {
            AddTask(firstTask);
        }
    }
}
