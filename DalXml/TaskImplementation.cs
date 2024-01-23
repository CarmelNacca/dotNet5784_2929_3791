

using DalApi;
using System.Data.Common;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal;

internal class TaskImplementation:ITask
{
    readonly string s_tasks_xml = "tasks";
   

    public int Create(DO.Task item)
    {
      

        //    int id = DataSource.Config.NextTaskId;
        //    Task copy = item with { Id = id };
        //    DataSource.Tasks.Add(copy);
        //    return id;
        //}
    }


    public void Delete(int id)
    {
       
    }

    public DO.Task? Read(int id)
    {
       

    }

    public DO.Task? Read(Func<DO.Task, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(DO.Task item)
    {
        throw new NotImplementedException();
    }
}
