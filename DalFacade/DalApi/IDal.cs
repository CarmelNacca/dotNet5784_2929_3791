using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.DalApi
{
    public interface IDal
    {
        IDependency Dependency { get; }
        ITask Task { get; }
        IWorker Worker { get; }

    }
}
