

using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Dal
{
    internal class WorkerImplementation : IWorker
    {
        /// <summary>
        /// Implementation of CRUD methods according to method number 1 for XML files.
        /// </summary>
        readonly string s_workers_xml = "workers";

        /// <summary>
        /// Creates a new worker.
        /// </summary>
        /// <param name="item">The worker to create.</param>
        /// <returns>The ID of the newly created worker.</returns>
        public int Create(Worker item)
        {
            List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
            if (Read(item.Id) is not null)
                throw new DalAlreadyExistException($"Worker with ID={item.Id} already exists");
            workers.Add(item);
            XMLTools.SaveListToXMLSerializer(workers, s_workers_xml);
            return item.Id;
        }

        /// <summary>
        /// Deletes a worker by ID.
        /// </summary>
        /// <param name="id">The ID of the worker to delete.</param>
        public void Delete(int id)
        {
            List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
            Worker? worker1 = Read(id);
            if (worker1 is null)
                throw new DalDoesNotExistException($"Worker with ID={id} not exists");
            workers.Remove(worker1);
            XMLTools.SaveListToXMLSerializer(workers, s_workers_xml);
        }

        /// <summary>
        /// Reads a worker by ID.
        /// </summary>
        /// <param name="id">The ID of the worker to read.</param>
        /// <returns>The worker with the specified ID.</returns>
        public Worker? Read(int id)
        {
            List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
            return workers.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Reads a worker based on a filter predicate.
        /// </summary>
        /// <param name="filter">The filter predicate.</param>
        /// <returns>The first worker matching the filter predicate, or null if not found.</returns>
        public Worker? Read(Func<Worker, bool> filter)
        {
            List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
            return workers.FirstOrDefault(filter);
        }

        /// <summary>
        /// Reads all workers, optionally applying a filter.
        /// </summary>
        /// <param name="filter">An optional filter function to apply.</param>
        /// <returns>A collection of workers.</returns>
        public IEnumerable<Worker?> ReadAll(Func<Worker, bool>? filter = null)
        {
            List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
            if (filter != null)
            {
                return from item in workers
                       where filter(item)
                       select item;
            }
            return from item in workers
                   select item;
        }

        /// <summary>
        /// Updates a worker.
        /// </summary>
        /// <param name="item">The worker to update.</param>
        public void Update(Worker item)
        {
            List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
            if (workers.RemoveAll(it => it.Id == item.Id) == 0)
                throw new DalDoesNotExistException($"Worker with ID={item.Id} not exists");
            workers.Add(item);
            XMLTools.SaveListToXMLSerializer(workers, s_workers_xml);
        }

        /// <summary>
        /// Resets the list of workers.
        /// </summary>
        public void Reset()
        {
            XElement? elemde = XMLTools.LoadListFromXMLElement(s_workers_xml);
            elemde.RemoveAll();
            XMLTools.SaveListToXMLElement(elemde, s_workers_xml);
        }
    }
}
