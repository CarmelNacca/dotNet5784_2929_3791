

using BlApi;
using BO;
using DalApi;
using System.Xml.Linq;

namespace BlImplementation
{
    internal class TaskImplementation : ITask
    {
        private DalApi.IDal _dal = Factory.Get;
        public int Create(BO.Task boTask)
        {
            DO.Task doTask = new DO.Task

                (boTask.Id, boTask.Worker, boTask.Name, boTask.Description, boTask.Status, boTask.TaskInList, boTask.Milestone, boTask.createdAtDate, boTask.RequiredEffortTime,
                boTask.CalculatedEndDate, boTask.StartDate, boTask.ScheduledDate, boTask.DeadlineDate, boTask.CompleteDate, boTask.Deliverables, boTask.Copmlexity);
            try
            {
                int idTask = dal.Task.Create(doTask);
                return idTask;
            }
            catch (DO.DalAlreadyExistException ex)
            {
                throw new BO.BlAlreadyExistsException($"Task with ID={boTask.Id} already exists", ex);
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        private static BO.Task doTaskToBoTask(DO.Task? doTask) =>
        new BO.Task()
        {
            Id = doTask.Id,

            Description = doTask.Description,
            Alias = doTask.Name,
            createdAtDate = doTask.createdAtDate,
            RequiredEffortTime = doTask.RequiredEffortTime,
            StartDate = doTask.StartDate,
            ScheduledDate = doTask.ScheduledDate,
            DeadlineDate = doTask.DeadlineDate,
            CompleteDate = doTask.CompleteDate,
            Deliverables = doTask.Deliverables
        };





        public IEnumerable<BO.Task> ReadAll(Func<BO.Task, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(BO.Task item)
        {
            throw new NotImplementedException();
        }

        public void UpdateCalculatedEndDate(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id)
        {
            throw new NotImplementedException();
        }


        private bool HelpTaskNow(DO.Task task)
        {
            return (id == doTaskToBoTask(task).Worker.Id);
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
    
