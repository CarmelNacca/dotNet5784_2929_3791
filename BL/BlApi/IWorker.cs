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
      public int Add(BO.Worker boWorker);//Add an employee
        public void Delete(int id);//Deleting an employee

        public BO.Worker? Read(int id);//Displaying employee details


        public IEnumerable<BO.Worker> ReadAll(Func<BO.Worker, bool>? filter = null);//Displaying the details of all employees


        public void Update(BO.Worker item);//Update worker
        //public TaskInWorker TaskNow(int id);
    }
}
