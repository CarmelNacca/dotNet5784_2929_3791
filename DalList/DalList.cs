
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;

sealed internal class DalList : IDal
{
    public static IDal Instance { get; } = new DalList();
    private DalList() { }



    public ITask Task => new TaskImplementation();
    public IWorker Worker => new WorkerImplementation();
    public IDependency Dependency => new DependencyImplementation();
}