using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{/// <summary>
/// task
/// </summary>
    public interface ITask
    {
       // public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null);
        public int Add(BO.Task item);
        public void Update(BO.Task item);
        //public void TaskToWorker(Tuple<int, string> item);
        public IEnumerable<BO.TaskInList> ReadAll(Func<BO.TaskInList, bool>? filter = null);
        
        public BO.Task? Read(int id, bool taskNow = false);

        public void Delete(int id);

        public void UpdateDate(int id, DateTime date);
        public void TasksWithStatusDone();
    }
}
