
namespace Dal;

using DalApi;
using DO;
using System.Collections.Generic;
using System.Threading.Tasks;

public class WorkerImplementation : IWorker
{
    public int Create(Worker item)
    {
        if (Read(item.Id) is not null)
            throw new Exception($"Worker with ID={item.Id} already exists");
        DataSource.Workers.Add(item);
        return item.Id;
    }


    public void Delete(int id)
    {
        Worker? worker1 =Read(id);
        if (worker1 is null)
            throw new Exception($"Worker with ID={id} not exists");
        DataSource.Workers.Remove(worker1);

    }

    public Worker? Read(int id)
    {
        Worker? worker1 = null;
        for (int i = 0; i < DataSource.Workers.Count; i++)
        {
            if (DataSource.Workers[i].Id == id)
            { 
                worker1 = DataSource.Workers[i];
                break;
            }
        }
        return worker1;
    }

    public List<Worker> ReadAll()
    {
        return new List<Worker>(DataSource.Workers);
    }

    public void Update(Worker item)
    {
        if (Read(item.Id) is null)
            throw new Exception($"Worker with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Workers.Add(item);
    }
}

