using BO;
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
      public int Add(BO.Worker boWorker);
      public void Delete(int id);

        public BO.Worker? Read(int id);


        public IEnumerable<BO.Worker> ReadAll(Func<BO.Worker, bool>? filter = null);//v


        public void Update(BO.Worker item);
        //public TaskInWorker TaskNow(int id);
    }
}
