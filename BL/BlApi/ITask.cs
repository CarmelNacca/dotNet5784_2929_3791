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
        public int Add(BO.Task item);//Adding a task
        public void Update(BO.Task item);//task update
        //public void TaskToWorker(Tuple<int, string> item);
        public IEnumerable<BO.TaskInList> ReadAll(Func<BO.Task, bool>? filter = null);//Displaying all tasks in TASKINLIST

        public BO.Task? Read(int id, bool taskNow = false);//Displaying a task in TASKINLIST

        public void Delete(int id);//Deleting a task

        public void UpdateDate(int id, DateTime date);//Update task start date
        public void TasksWithStatusDone();//Prints the tasks whose status is DONE
        public IEnumerable<BO.TaskInList> TasksWithLevel(BO.ExpiriencePl level);

    }
}
