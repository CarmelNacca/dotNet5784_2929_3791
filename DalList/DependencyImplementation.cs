

namespace Dal;

using DalApi;
using DO;

using System.Collections.Generic;

public class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        int id = DataSource.Config.NextDependencyId;
        Dependency copy = item with { Id = id };
        DataSource.Dependencies.Add(copy);
        return id;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Dependency? Read(int id)
    {
        Dependency? dependency1 = null;
        for (int i = 0; i < DataSource.Dependencies.Count; i++)
        {
            if (DataSource.Dependencies[i].Id == id)
            { 
                dependency1 = DataSource.Dependencies[i];
                break;
            }
        }
        return dependency1;
    }

    public List<IDependency> ReadAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Dependency item)
    {
        if (Read(item.Id) is not null)
            throw new Exception($"Dependency with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Dependencies.Add(item);
    }
}
