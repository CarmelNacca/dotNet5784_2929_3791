using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// worker
    /// </summary>
    public interface IWorker
    {
        public int Create(BO.Worker boWorker);
        public void Delete(int id);

        public BO.Worker? Read(int id);


        public IEnumerable<BO.Worker?> ReadAll(Func<BO.Worker, bool>? filter = null);


        public void Update(BO.Worker item);


        public BO.Worker? Read(Func<BO.Worker, bool> filter);
    }
}
