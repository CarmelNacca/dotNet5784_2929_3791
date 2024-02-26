using BO;
namespace BlImplementation;

internal class WorkerImplementation : BlApi.IWorker
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    private bool IsValidEmail(string email)//Email integrity check
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false; // suggested by @TK-421
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
    public int Add(BO.Worker boWorker)//Add an employee
    {
        if (boWorker.Id >= 0 && boWorker.Name != "" && boWorker.Cost > 0 && IsValidEmail(boWorker.Email))
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level,boWorker.Name ,  boWorker.Email);
            try
            {

                int id = _dal.Worker.Create(doWorker);

                return id;
            }
            catch (DO.DalAlreadyExistException ex)
            {
                throw new BO.BlAlreadyExistsException($"Worker with ID={boWorker.Id} already exists", ex);
            }
        }
        else
        {
            throw new BO.BlInvalidData("The data is incorrect");
        }
    }
   
    public void Delete(int id)//Deleting an employee
    {
        try
        {
            Read(id);
        }
        catch (DO.DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist",ex);
        }

        if (Read(id)!.Task == null)
        {
          _dal.Worker.Delete(id);
        }
        else
        {
            throw new BO.BlWorkerInMiddleOfTask("Cannot delete because the worker is in the middle of a task");
        }

    }

    public BO.Worker? Read(int id)//Displaying employee details
    {
        try { 
        DO.Worker? doWorker = _dal.Worker.Read(id);
            var boWorker= doWorkerToBoWorker(doWorker);
            return boWorker;
        }
        catch (DO.DalDoesNotExistException ex) 
        { 
            throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist",ex);
        }
       


    }

    private BO.Worker doWorkerToBoWorker(DO.Worker? doWorker/*,bool flag=true*/)//Converting an employee from DO to BO
    {
        
        
        var boWorker= new BO.Worker
        {
            Id = doWorker!.Id,
            Cost = doWorker.Cost,
            Name = doWorker.Name!,
            Level = (BO.Expirience)doWorker.Level,
            Email = doWorker.Email!
        };
        //if(flag)
        //    {
        //    DO.Task task = _dal.Task.Read(t => t.Worker == doWorker!.Id)!;
        //    boWorker.Task = new TaskInWorker { Id = task.Id, Alias = task.Name }; 
        //    }
        return boWorker;
    }

    public IEnumerable<BO.Worker> ReadAll(Func<BO.Worker, bool>? filter = null)//Displaying the details of all employees
    {
        return (from DO.Worker doWorker in _dal.Worker.ReadAll()
               let worker = doWorkerToBoWorker(doWorker)
               where filter is null ? true : filter(worker)
               select worker).OrderByDescending(Worker => Worker.Name);
    }
    //public TaskInWorker TaskNow(int id)
    //{
    //    try
    //    { 
    //        Read(id);
    //        try
    //        {
    //            TaskInWorker task = Read(id).Task;
    //            return task!;
    //        }
    //        catch (DO.DalDoesNotExistException ex)
    //        {
    //            throw new BO.BlDoesNotExistException($"The worker does not have a task", ex); //($"The worker does not have a task", ex);
    //        }
    //    }
    //    catch (DO.DalDoesNotExistException ex)
    //    {
    //        throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist", ex);
    //    }

        

    //}
    public void Update(BO.Worker boWorker)//Update worker
    {
        if (boWorker.Id >= 0 && boWorker.Name != "" && boWorker.Cost > 0 && IsValidEmail(boWorker.Email))
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level, boWorker.Name, boWorker.Email);
            try
            {
                _dal.Worker.Update(doWorker);

            }

            catch (DO.DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Worker with ID={boWorker.Id} does Not exist", ex);
            }
        }
        else
        {
            throw new BO.BlInvalidData("The data is incorrect");
        }
    }
   
}         

