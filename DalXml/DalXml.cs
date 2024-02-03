using DalApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

  sealed internal class DalXml : IDal
{

    public static IDal Instance { get; } = new DalXml();
    private DalXml() { }


    public ITask Task => new TaskImplementation();
        public IWorker Worker => new WorkerImplementation();
        public IDependency Dependency => new DependencyImplementation();
    }

