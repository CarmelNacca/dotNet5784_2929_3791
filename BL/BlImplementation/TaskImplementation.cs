

using BlApi;
using BO;
using System.Xml.Linq;

namespace BlImplementation
{
    internal class TaskImplementation : ITask
    {
        private DalApi.IDal dal = Factory.Get;
        public int Create(BO.Task boTask)
        {
            DO.Task doTask = new DO.Task

                (boTask.Id , boTask.Worker, boTask. Name , boTask.Description, boTask. Status, boTask.TaskInList ,boTask.Milestone , boTask.createdAtDate , boTask.RequiredEffortTime,
                boTask.CalculatedEndDate , boTask.StartDate , boTask.ScheduledDate , boTask.DeadlineDate , boTask.CompleteDate, boTask. Deliverables ,boTask.Copmlexity);
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

        public BO.Task? Read(int id)
        {
            throw new NotImplementedException();
        }

        public BO.Task? Read(Func<BO.Task, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null)
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
    }
}
