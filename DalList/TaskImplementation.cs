
namespace Dal;

using DalApi;
using DO;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    /// <summary>
    /// Implementation of CRUD methods
    /// <returns></returns>
    public int Create(Task item)
    {
        int id = DataSource.Config.NextTaskId;
        Task copy = item with { Id = id };
        DataSource.Tasks.Add(copy); 
        return id;
    }


    public void Delete(int id)
    {
        Task? task1 = Read(id);
        if (task1 is null)
            throw new Exception($"Task with ID={id} not exists");
        DataSource.Tasks.Remove(task1);
    }

    public Task? Read(int id)
    {
        return DataSource.Tasks.Find(x => x.Id == id);
    }

    public List<Task> ReadAll()
    {
        return new List<Task>(DataSource.Tasks);
    }

    public void Update(Task item)
    {

        if (Read(item.Id) is null)
            throw new Exception($"Task with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Tasks.Add(item);
    }
}
