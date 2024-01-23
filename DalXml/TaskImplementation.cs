

using DalApi;
using DO;
using System.Data.Common;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal;

internal class TaskImplementation:ITask
{/// <summary>
/// Implementation of CRUD methods according to method number 1 for XML files
/// </summary>
    readonly string s_tasks_xml = "tasks";
   

    public int Create(DO.Task item)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
        int nextId = Config.NextTaskId;
        DO.Task copy = item with { Id = nextId };
        tasks.Add(copy);
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
        return nextId;
        
    }


    public void Delete(int id)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
        DO.Task? task1 = Read(id);
        if (task1 is null)
            throw new DalDoesNotExistException($"Task with ID={id} not exists");
        tasks.Remove(task1);
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
    }

    public DO.Task? Read(int id)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
        return tasks.FirstOrDefault(x => x.Id == id);

    }

    public DO.Task? Read(Func<DO.Task, bool> filter)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
        return tasks.FirstOrDefault(filter);
    }

    public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
        if (filter != null)
        {
            return from item in tasks
                   where filter(item)
                   select item;
        }
        return from item in tasks
               select item;
    }

    public void Update(DO.Task item)
    {
        List<DO.Task> tasks = XMLTools.LoadListFromXMLSerializer<DO.Task>(s_tasks_xml);
        if (tasks.RemoveAll(it => it.Id == item.Id) == 0)
            throw new DalDoesNotExistException($"Task with ID={item.Id} not exists");
        tasks.Add(item);
        XMLTools.SaveListToXMLSerializer(tasks, s_tasks_xml);
    }
}
