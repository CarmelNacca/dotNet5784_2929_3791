
namespace Dal;

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

internal class TaskImplementation : ITask
{
    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="item">The task to create.</param>
    /// <returns>The ID of the newly created task.</returns>
    public int Create(Task item)
    {
        int id = DataSource.Config.NextTaskId;
        Task copy = item with { Id = id };
        DataSource.Tasks.Add(copy);
        return id;
    }

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to delete.</param>
    public void Delete(int id)
    {
        Task? task1 = Read(id);
        if (task1 is null)
            throw new DalDoesNotExistException($"Task with ID={id} not exists");
        DataSource.Tasks.Remove(task1);
    }

    /// <summary>
    /// Reads a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to read.</param>
    /// <returns>The task with the specified ID, or null if not found.</returns>
    public Task? Read(int id)
    {
        return DataSource.Tasks.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Reads all tasks, optionally applying a filter.
    /// </summary>
    /// <param name="filter">An optional filter function to apply.</param>
    /// <returns>A collection of tasks.</returns>
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

    /// <summary>
    /// Updates a task.
    /// </summary>
    /// <param name="item">The task to update.</param>
    public void Update(Task item)
    {
        if (Read(item.Id) is null)
            throw new DalDoesNotExistException($"Task with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Tasks.Add(item);
    }

    /// <summary>
    /// Reads a task based on a filter predicate.
    /// </summary>
    /// <param name="filter">The filter predicate.</param>
    /// <returns>The first task matching the filter predicate, or null if not found.</returns>
    public Task? Read(Func<Task, bool> filter) // stage 2
    {
        return DataSource.Tasks.FirstOrDefault(filter);
    }

    /// <summary>
    /// Resets the list of tasks.
    /// </summary>
    public void Reset()
    {
        DataSource.Tasks.Clear();
    }
}
