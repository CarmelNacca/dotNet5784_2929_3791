
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
            throw new DalDoesNotExistException($"Task with ID={id} not exists");
        DataSource.Tasks.Remove(task1);
    }

    public Task? Read(int id)
    {
        return DataSource.Tasks.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
    {
        if (filter != null)
        {
            return from item in DataSource.Tasks
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Tasks
               select item;


    }
    public void Update(Task item)
    {

        if (Read(item.Id) is null)
            throw new DalDoesNotExistException($"Task with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Tasks.Add(item);
    }
    public Task? Read(Func<Task, bool> filter) // stage 2
    {
        return DataSource.Tasks.FirstOrDefault(filter);
    }
    public void Reset()
    {
        DataSource.Tasks.Clear();
    }
}
