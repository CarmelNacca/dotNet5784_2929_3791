
namespace Dal;

using DalApi;
using DO;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class WorkerImplementation: IWorker
{
    /// <summary>
    /// Implementation of CRUD methods
    /// <returns></returns>
    public int Create(Worker item)
    {
        if (Read(item.Id) is not null)
            throw new DalAlreadyExistException($"Worker with ID={item.Id} already exists");
        DataSource.Workers.Add(item);
        return item.Id;
    }


    public void Delete(int id)
    {
        Worker? worker1 = Read(id);
        if (worker1 is null)
            throw new DalDoesNotExistException($"Worker with ID={id} not exists");
        DataSource.Workers.Remove(worker1);

    }

    public Worker? Read(int id)
    {
        try { 
        return DataSource.Workers.FirstOrDefault(x => x.Id == id);
        }
        catch(Exception)
        {
            throw new DO.DalDoesNotExistException($"Worker with ID={id} not exists");
        }
    }

    public IEnumerable<Worker?> ReadAll(Func<Worker, bool>? filter = null)
    {
        if (filter != null)
        {
            return from item in DataSource.Workers
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Workers
               select item;


    }

    public void Update(Worker item)
    {
        if (Read(item.Id) is null)
            throw new DalDoesNotExistException($"Worker with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Workers.Add(item);
    }
    public Worker? Read(Func<Worker, bool> filter) // stage 2
    {
        return DataSource.Workers.FirstOrDefault(filter);
    }
    public void Reset()
    {
        DataSource.Workers.Clear();
    }
}

