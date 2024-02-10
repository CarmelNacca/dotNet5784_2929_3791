using BO;
namespace BlImplementation;

internal class WorkerImplementation : BlApi.IWorker
{
    private DalApi.IDal _dal = Factory.Get;
    private bool IsValidEmail(string email)
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
    public int Add(BO.Worker boWorker)
    {
        if (boWorker.Id >= 0 && boWorker.Name != "" && boWorker.Cost > 0 && IsValidEmail(boWorker.Name))
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level, boWorker.Email, boWorker.Name);
            try
            {

                int id = _dal.Worker.Create(doWorker);

                return id;
            }
            catch (BO.BlAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Worker with ID={boWorker.Id} already exists", ex);
            }
        }
        else
        {
            //הנתונים לא תקינים
        }
    }
   
    public void Delete(int id)
    {
        if (Read(id).Task == null)
        {
            try
            {
                _dal.Worker.Delete(id);
            }
            catch (BO.BlDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist");
            }

        }
        else
        { //חריגה של עובד באמצע משימה
        }

    }

    public BO.Worker? Read(int id)
    {

        DO.Worker? doWorker = _dal.Worker.Read(id);
        if (doWorker == null)
            throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist");
        return doWorkerToBoWorker(doWorker);


    }

    private Worker doWorkerToBoWorker(DO.Worker? doWorker)
    {
        var task = _dal.Task.Read(t => t.Worker == doWorker!.Id);
        return new BO.Worker()
        {
            Id = doWorker!.Id,
            Cost = doWorker.Cost,
            Name = doWorker.Name!,
            Level = (BO.Expirience)doWorker.Level,
            Email = doWorker.Email!,

            Task = task is null ? null : new BO.TaskInWorker
            {
                Id = task.Id,
                Alias = task.Name!
            }
        };
    }

    public IEnumerable<BO.Worker> ReadAll(Func<BO.Worker, bool>? filter = null)
    {
        return from DO.Worker doWorker in _dal.Worker.ReadAll()
               let worker = doWorkerToBoWorker(doWorker)
               where filter is null ? true : filter(worker)
               select worker;
    }
    public TaskInWorker TaskNow(int id)
    {
        TaskInWorker? task = Read(id)!.Task;
        try
        {
            return task!;
        }
        catch (BO.BlDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException($"The worker does not have a task", ex); //($"The worker does not have a task", ex);
        }

    }
    public void Update(BO.Worker boWorker)
    {
        if (boWorker.Id >= 0 && boWorker.Name != "" && boWorker.Cost > 0 && IsValidEmail(boWorker.Name))
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level, boWorker.Email, boWorker.Name);
            try
            {
                _dal.Worker.Update(doWorker);

            }

            catch (BO.BlDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Worker with ID={boWorker.Id} does Not exist", ex);
            }
        }
        else
        {
            //הנתונים לא תקינים
        }
    }

}         

