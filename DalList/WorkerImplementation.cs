

namespace Dal;

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

internal class WorkerImplementation : IWorker
{
    /// <summary>
    /// Creates a new worker.
    /// </summary>
    /// <param name="item">The worker to create.</param>
    /// <returns>The ID of the newly created worker.</returns>
    public int Create(Worker item)
    {
        if (Read(item.Id) is not null)
            throw new DalAlreadyExistException($"Worker with ID={item.Id} already exists");
        DataSource.Workers.Add(item);
        return item.Id;
    }

    /// <summary>
    /// Deletes a worker by ID.
    /// </summary>
    /// <param name="id">The ID of the worker to delete.</param>
    public void Delete(int id)
    {
        Worker? worker1 = Read(id);
        if (worker1 is null)
            throw new DalDoesNotExistException($"Worker with ID={id} not exists");
        DataSource.Workers.Remove(worker1);
    }

    /// <summary>
    /// Reads a worker by ID.
    /// </summary>
    /// <param name="id">The ID of the worker to read.</param>
    /// <returns>The worker with the specified ID.</returns>
    public Worker Read(int id)
    {
        try
        {
            return DataSource.Workers.FirstOrDefault(x => x.Id == id)!;
        }
        catch (Exception)
        {
            throw new DO.DalDoesNotExistException($"Worker with ID={id} not exists");
        }
    }

    /// <summary>
    /// Reads all workers, optionally applying a filter.
    /// </summary>
    /// <param name="filter">An optional filter function to apply.</param>
    /// <returns>A collection of workers.</returns>
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

    /// <summary>
    /// Updates a worker.
    /// </summary>
    /// <param name="item">The worker to update.</param>
    public void Update(Worker item)
    {
        if (Read(item.Id) is null)
            throw new DalDoesNotExistException($"Worker with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Workers.Add(item);
    }

    /// <summary>
    /// Reads a worker based on a filter predicate.
    /// </summary>
    /// <param name="filter">The filter predicate.</param>
    /// <returns>The first worker matching the filter predicate, or null if not found.</returns>
    public Worker? Read(Func<Worker, bool> filter) // stage 2
    {
        return DataSource.Workers.FirstOrDefault(filter);
    }

    /// <summary>
    /// Resets the list of workers.
    /// </summary>
    public void Reset()
    {
        DataSource.Workers.Clear();
    }
}
