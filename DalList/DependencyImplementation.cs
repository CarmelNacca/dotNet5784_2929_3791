

namespace Dal;

using DalApi;
using DO;

using System.Collections.Generic;

internal class DependencyImplementation : IDependency
{
    /// <summary>
    /// Implementation of CRUD methods
    /// <returns></returns>
    public int Create(Dependency item)
    {
        int id = DataSource.Config.NextDependencyId;
        Dependency copy = item with { Id = id };
        DataSource.Dependencies.Add(copy);
        return id;
    }

    public void Delete(int id)
    {

        Dependency? dependency1 = Read(id);
        if (dependency1 is null)
            throw new Exception($"Dependency with ID={id} not exists");
        DataSource.Dependencies.Remove(dependency1);
    }

    //public Dependency? Read(int id)
    //{
    //    return DataSource.Dependencies.FirstOrDefault(x => x.Id == id);

    //}

    //public List<Dependency> ReadAll()
    //{
    //    return new List<Dependency>(DataSource.Dependencies);
    //}
    public Dependency? Read(int id)
    {
        return DataSource.Dependencies.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
    {
        if (filter != null)
        {
            return from item in DataSource.Dependencies
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Dependencies
               select item;


    }


    public void Update(Dependency item)
    {
        if (Read(item.Id) is null)
            throw new Exception($"Dependency with ID={item.Id} not exists");
        Delete(item.Id);
        DataSource.Dependencies.Add(item);
    }
}
