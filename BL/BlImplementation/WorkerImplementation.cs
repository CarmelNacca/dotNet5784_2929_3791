

using BlApi;
using BO;

namespace BlImplementation
{
    internal class WorkerImplementation : IWorker
    {
        private DalApi.IDal _dal = Factory.Get;
        public int Create(BO.Worker boWorker)
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level, boWorker.Email, boWorker.Name);
            try
            {
                
                int id = _dal.Worker(doWorker);

                return idStud;
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Student with ID={boStudent.Id} already exists", ex);
            }

        }
        private DalApi.IDal _dal = DalApi.Factory.Get;
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Worker? Read(int id)
        {
            throw new NotImplementedException();
        }

        public Worker? Read(Func<Worker, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Worker?> ReadAll(Func<Worker, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Worker item)
        {
            throw new NotImplementedException();
        }
    }
}
