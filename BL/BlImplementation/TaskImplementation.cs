

using BlApi;
using BO;
using DalApi;
using System.Xml.Linq;
;

namespace BlImplementation
{
    internal class TaskImplementation : BlApi.ITask
    {
        private DalApi.IDal _dal = Factory.Get;

        public int Add(BO.Task boTask)
        {
            DO.Task doTask = new DO.Task(boTask.Id, boTask.Worker!.Id, boTask.Alias, boTask.Description, false, boTask.createdAtDate, boTask.RequiredEffortTime,
                 boTask.StartDate, boTask.ScheduledDate, boTask.DeadlineDate, boTask.CompleteDate, boTask.Deliverables,boTask.Remarks,(DO.Expirience)boTask.Copmlexity);
            try
            {
                int idTask =_dal.Task.Create(doTask);
                
                return idTask;
            }
            catch (DO.DalAlreadyExistException ex)
            {
                throw new BO.BlAlreadyExistsException($"Task with ID={boTask.Id} already exists", ex);
            }

        }

       
        private  BO.Task doTaskToBoTask(DO.Task? doTask)
        {
         var work = _dal.Worker.Read(t=>t.Id==doTask!.Worker);

            return new BO.Task()
            {


                Id = doTask!.Id,

                Description = doTask.Description!,
                Alias = doTask.Name!,
                createdAtDate = doTask.createdAtDate,
                RequiredEffortTime = doTask.RequiredEffortTime,
                StartDate = doTask.StartDate,
                ScheduledDate = doTask.ScheduledDate,
                DeadlineDate = doTask.DeadlineDate,
                CompleteDate = doTask.CompleteDate,
                Deliverables = doTask.Deliverables,
                Worker = work is null ? null : new BO.WorkerInTask
                {
                    Id = work!.Id,
                    Name = work.Name!
                }
            };
        }




        public IEnumerable<BO.Task> ReadAll(Func<BO.Task, bool>? filter = null)
        {
            return from DO.Task doTask in _dal.Task.ReadAll()
                   let task = doTaskToBoTask(doTask)
                   where filter is null ? true : filter(task)
                   select task;
        }
        

        public void Update(BO.Task item)
        {
            throw new NotImplementedException();
        }

       

        public void Schedule()
        {
            throw new NotImplementedException();
        }



        public BO.Task? TaskNow(int id)
        {
            BO.Task? task =Read(id,true);
            return task;
        }
        public BO.Task? Read(int id, bool taskNow = false)//מוכן
        {
            if (taskNow)
            {
                bool HelpTaskNow(DO.Task task)
                {
                    return (id == doTaskToBoTask(task).Worker.Id);
                }
                return doTaskToBoTask(_dal.Task.Read(HelpTaskNow));
            }
            else
            {
                DO.Task? doTask = _dal.Task.Read(id);
                if (doTask == null)
                    throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist");
                return doTaskToBoTask(doTask);
            }
        }

    }
}
    
