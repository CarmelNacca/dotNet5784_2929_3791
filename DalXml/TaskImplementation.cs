using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal
{
    internal class TaskImplementation : ITask
    {
        /// <summary>
        /// Implementation of CRUD methods according to method number 1 for XML files.
        /// </summary>
        readonly string s_tasks_xml = "tasks";

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="item">The task to create.</param>
        /// <returns>The ID of the newly created task.</returns>
        public int Create(DO.Task item)
        {
            List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
            int nextId = Config.NextTaskId;
            DO.Task copy = item with { Id = nextId };
            tasks.Add(copy);
            XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
            return nextId;
        }

        /// <summary>
        /// Deletes a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        public void Delete(int id)
        {
            List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
            DO.Task? task1 = Read(id);
            if (task1 is null)
                throw new DalDoesNotExistException($"Task with ID={id} not exists");
            tasks.Remove(task1);
            XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        }

        /// <summary>
        /// Reads a task by ID.
        /// </summary>
        /// <param name="id">The ID of the task to read.</param>
        /// <returns>The task with the specified ID.</returns>
        public DO.Task Read(int id)
        {
            List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
            return tasks.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Reads a task based on a filter predicate.
        /// </summary>
        /// <param name="filter">The filter predicate.</param>
        /// <returns>The first task matching the filter predicate, or null if not found.</returns>
        public DO.Task? Read(Func<DO.Task, bool> filter)
        {
            List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
            return tasks.FirstOrDefault(filter);
        }

        /// <summary>
        /// Reads all tasks, optionally applying a filter.
        /// </summary>
        /// <param name="filter">An optional filter function to apply.</param>
        /// <returns>A collection of tasks.</returns>
        public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null)
        {
            List<DO.Task>? tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
            if (filter != null)
            {
                return from item in tasks
                       where filter(item)
                       select item;
            }
            return from item in tasks
                   select item;
        }

        /// <summary>
        /// Updates a task.
        /// </summary>
        /// <param name="item">The task to update.</param>
        public void Update(DO.Task item)
        {
            List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
            if (tasks.RemoveAll(it => it.Id == item.Id) == 0)
                throw new DalDoesNotExistException($"Task with ID={item.Id} not exists");
            tasks.Add(item);
            XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        }

        /// <summary>
        /// Resets the list of tasks.
        /// </summary>
        public void Reset()
        {
            XElement? element = XMLTools.LoadListFromXMLElement(s_tasks_xml);
            element.RemoveAll();
            XMLTools.SaveListToXMLElement(element, s_tasks_xml);
        }
    }
    
}


