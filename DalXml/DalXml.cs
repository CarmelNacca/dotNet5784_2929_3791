using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

  sealed public class DalXml : IDal
    {


        public ITask Task => new TaskImplementation();
        public IWorker Worker => new WorkerImplementation();
        public IDependency Dependency => new DependencyImplementation();
    }

