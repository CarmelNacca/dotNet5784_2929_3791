

using BlApi;
using BO;

namespace BlImplementation
{
    internal class WorkerImplementation : IWorker
    {
        private DalApi.IDal dal = Factory.Get;
        public int Create(BO.Worker boWorker)
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level, boWorker.Email, boWorker.Name);
            try
            {
                
                int id = dal.Worker.Create(doWorker);

                return id;
            }
            catch (DO.DalAlreadyExistException ex)
            {
                throw new BO.BlAlreadyExistsException($"Worker with ID={boWorker.Id} already exists", ex);
            }

        }
    
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BO.Worker? Read(int id)
        {

            DO.Worker? doWorker = dal.Worker.Read(id);
            if (doWorker == null)
                throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist");

            return new BO.Worker()
            {
                Id = id,
              Cost = doWorker.Cost,
              Name = doWorker.Name,
             Level=  (BO.Expirience) doWorker.Level,
              Email = doWorker.Email,

            };
        }

        public Worker? Read(Func<Worker, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Worker> ReadAll(Func<Worker, bool>? filter = null)
        {
            throw new NotImplementedException(); 
    }

        public void Update(Worker item)
        {
            throw new NotImplementedException();
        }
    }
}
