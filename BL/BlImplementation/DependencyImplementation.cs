
using BlApi;
using BO;

namespace BlImplementation
{
    internal class DependencyImplementation :IDependency
    {
        private DalApi.IDal dal = Factory.Get;
        public int Create(Dependency boDependency)
        {
            DO.Dependency doDependency = new DO.Dependency
            (boDependency.Id, boDependency.IdTask, boDependency.DependsOnTask) ;
            try
            {

                int id = dal.Dependency.Create(doDependency);

                return id;
            }
            catch (DO.DalAlreadyExistException ex)
            {
                throw new BO.BlAlreadyExistsException($"Dependency with ID={boDependency.Id} already exists", ex);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        
        
            public BO.Dependency? Read(int id)
            {

                DO.Dependency? doDependency = dal.Dependency.Read(id);
                if (doDependency == null)
                    throw new BO.BlDoesNotExistException($"Dependency with ID={id} does Not exist");

                return new BO.Dependency()
                {
                    Id = id,
                    IdTask= doDependency.IdTask,
                    DependsOnTask= doDependency.DependsOnTask
                   
                };
            }

        

        public Dependency? Read(Func<Dependency, bool> filter)
        {
            throw new NotImplementedException();
        }

        
        public void Update(Dependency item)
        {
            throw new NotImplementedException();
        }
    }
}
