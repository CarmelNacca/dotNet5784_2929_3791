

using DalApi;
using DO;
using System.Threading.Tasks;

namespace Dal;

internal class WorkerImplementation:IWorker
{
    /// <summary>
    /// Implementation of CRUD methods according to method number 1 for XML files
    /// </summary>
    readonly string s_workers_xml = "workers";

    public int Create(Worker item)
    {
        List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
        if (Read(item.Id) is not null)
            throw new DalAlreadyExistException($"Worker with ID={item.Id} already exists");
        workers.Add(item);
        XMLTools.SaveListToXMLSerializer(workers, s_workers_xml);
        return item.Id;
    }

    public void Delete(int id)
    {
        List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
        Worker? worker1 = Read(id);
        if (worker1 is null)
            throw new DalDoesNotExistException($"Worker with ID={id} not exists");
        workers.Remove(worker1);
        XMLTools.SaveListToXMLSerializer(workers, s_workers_xml);
    }

    public Worker? Read(int id)
    {
        List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
        return workers.FirstOrDefault(x => x.Id == id);
    }

    public Worker? Read(Func<Worker, bool> filter)
    {
        List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
        return workers.FirstOrDefault(filter);
    }

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

    public void Update(Worker item)
    {
        List<Worker> workers = XMLTools.LoadListFromXMLSerializer<Worker>(s_workers_xml);
        if(workers.RemoveAll(it=>it.Id == item.Id)==0)
            throw new DalDoesNotExistException($"Worker with ID={item.Id} not exists");
        workers.Add(item) ;
        XMLTools.SaveListToXMLSerializer(workers,s_workers_xml);
    }
}
