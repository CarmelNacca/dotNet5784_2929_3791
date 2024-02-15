



using BO;

namespace BlImplementation;

internal class TaskImplementation : BlApi.ITask
{
    private DalApi.IDal _dal = Factory.Get;

    public int Add(BO.Task boTask)//Adding a task
    {
        DO.Task doTask = new DO.Task(boTask.Id,null, boTask.Alias, boTask.Description, false, boTask.createdAtDate, boTask.RequiredEffortTime,
             boTask.StartDate, boTask.ScheduledDate, boTask.DeadlineDate, boTask.CompleteDate, boTask.Deliverables, boTask.Remarks, (DO.Expirience)boTask.Copmlexity);

        try
        {
            int idTask = _dal.Task.Create(doTask);
            if (boTask.Dependencies != null)
            {
                for (int i = 0; i < boTask.Dependencies.Count(); i++)
                {
                    DO.Dependency dependency = new DO.Dependency(0, boTask.Dependencies[i].Id, idTask);
                    _dal.Dependency.Create(dependency);
                }
            }
            return idTask;
        }
        catch (DO.DalAlreadyExistException ex)
        {
            throw new BO.BlAlreadyExistsException($"Task with ID={boTask.Id} already exists", ex);
        }

    }


    private BO.Task doTaskToBoTask(DO.Task? doTask)//Converting a task from DO to BO
    {
       
        var task= new BO.Task()
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
            

        }; 
        if(doTask.ScheduledDate == null)
        {
            task.Status=BO.Status.Unscheduled;
        }else if(doTask.StartDate==null)
        {  task.Status=BO.Status.Scheduled; }
        else if(doTask.CompleteDate==null)
            {
            task.Status=BO.Status.OnTrack;
        }
        else { task.Status=BO.Status.Done; }
        //if (flag)
        //{
        //    var work = _dal.Worker.Read(t => t.Id == doTask!.Worker);

        //    task.Worker.Id = work!.Id;
        //     task.Worker.Name = work.Name;
        //    }
        return task;
        }
    

    private TaskInList taskToTaskInList(BO.Task task)//Converting a task from TASK to TASKINLIST
    {
        return new TaskInList() { Id = task.Id, Description = task.Description, Alias = task.Alias, Status = task.Status };
    }


    public IEnumerable<BO.TaskInList> ReadAll(Func<BO.TaskInList, bool>? filter = null)//Displaying all tasks in TASKINLIST
    {
        return from DO.Task doTask in _dal.Task.ReadAll()
               let task = taskToTaskInList(doTaskToBoTask(doTask))
               where filter is null ? true : filter(task)
               select task;
    }


    public void Update(BO.Task item)//task update
    {
        if (item.Id >= 0 && item.Alias != "")
        {
            DO.Task doTask;
            if (item.Worker != null)
            {
                doTask = new DO.Task
                (item.Id, item.Worker.Id, item.Alias, item.Description, false, item.createdAtDate, item.RequiredEffortTime, item.StartDate,
                item.ScheduledDate, item.DeadlineDate, item.CompleteDate, item.Deliverables, item.Remarks, (DO.Expirience)item.Copmlexity);
            }
            else
            {
                doTask = new DO.Task
            (item.Id, null, item.Alias, item.Description, false, item.createdAtDate, item.RequiredEffortTime, item.StartDate,
            item.ScheduledDate, item.DeadlineDate, item.CompleteDate, item.Deliverables, item.Remarks, (DO.Expirience)item.Copmlexity);
            }


            try
            {
                _dal.Task.Update(doTask);
            }

            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Task with ID={item.Id} does Not exist", ex);
            }
        }

        else
        {
            throw new BO.BlInvalidData("The data is incorrect");
        }
    }





    public BO.Task? Read(int id, bool taskNow = false)//Displaying a task in TASKINLIST
    {
        if (taskNow)
        {
            bool HelpTaskNow(DO.Task task)
            {
                return (id == task.Id);
            }
            try
            {
                var task = _dal.Task.Read(HelpTaskNow);
                return doTaskToBoTask(task);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist", ex);
            }
        }
        else
        {
            try
            {
                DO.Task? doTask = _dal.Task.Read(id);
                return doTaskToBoTask(doTask);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist", ex);
            }

        }
    }
    public void Delete(int id)//Deleting a task
    {
        if (BO.Task.StatusProject != BO.StatusProject.execution)
        {
            try
            {
                BO.Task task = Read(id);
                if (task.Dependencies == null)
                {
                    _dal.Worker.Delete(id);
                }
                else
                {
                    throw new BO.BlHavePendingTasks("The task has dependencies");
                }
            }
            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist", ex);
            }
        }
        else
        {
            throw new BO.BlUnableDeleteBecauseProjectIsInProgress("It cannot be deleted because the project is in progress");
        }
    }
    public void UpdateDate(int id, DateTime date)//Update task start date
    {
        try { Read(id); }
        catch (DO.DalDoesNotExistException ex)
        { throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist", ex); }
        bool helpUpdateDate(DO.Dependency dependency)
        {
            if (id == dependency.DependsOnTask)
                return (_dal.Task.Read(id)!.StartDate == null && _dal.Task.Read(id)!.DeadlineDate > date);
            else
                return false;
        }
        if (Read(id).Dependencies != null && _dal.Dependency.ReadAll(helpUpdateDate) == null)
        {
            var task = Read(id);
            task!.StartDate = date;
            Update(task);
        }
    }
    public  void TasksWithStatusDone()//Prints the tasks whose status is DONE
    {
        var grouped = ReadAll().GroupBy(TaskInList => TaskInList.Status == BO.Status.Done);

        foreach (var group in grouped)
        {
            Console.WriteLine($"Tasks with Status done:");

            foreach (var task in group)
            {
                Console.WriteLine($" - {task}");
            }
        }
       
        return;
    }
}
