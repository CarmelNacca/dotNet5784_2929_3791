using BO;
namespace BlImplementation
{
    internal class WorkerImplementation : BlApi.IWorker
    {
        private DalApi.IDal _dal = Factory.Get;
        public int Add(BO.Worker boWorker)
        {
            DO.Worker doWorker = new DO.Worker
       (boWorker.Id, boWorker.Cost, (DO.Expirience)(int)boWorker.Level, boWorker.Email, boWorker.Name);
            try
            {

                int id = _dal.Worker.Create(doWorker);

                return id;
            }
            catch (DO.DalAlreadyExistException ex)
            {
                throw new BO.BlAlreadyExistsException($"Worker with ID={boWorker.Id} already exists", ex);
            }

        }

        public void Delete(int id)
        {
            _dal.Worker.Delete(id);
        }

        public BO.Worker? Read(int id)
        {
           
            DO.Worker? doWorker = _dal.Worker.Read(id);
            if (doWorker == null)
                throw new BO.BlDoesNotExistException($"Worker with ID={id} does Not exist");
            return doWorkerToBoWorker(doWorker);
           

        } 

        private static Worker doWorkerToBoWorker(DO.Worker? doWorker) =>
        new BO.Worker()
        {
            Id = doWorker.Id,
            Cost = doWorker.Cost,
            Name = doWorker.Name,
            Level = (BO.Expirience)doWorker.Level,
            Email = doWorker.Email,
        };

        public IEnumerable<Worker> ReadAll(Func<Worker, bool>? filter = null, bool withEmptyTasks = false)
        {
            return from DO.Worker doWorker in _dal.Worker.ReadAll()
                   where withEmptyTasks ? !_dal.Task.ReadAll(t => t.Worker == doWorker.Id).Any() : true
                   let worker = doWorkerToBoWorker(doWorker)
                   where filter is null ? true : filter(worker)
                   select worker;
        }
        public TaskInWorker TaskToWorker(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(BO.Worker item,BO.Status status)
        {
            throw new NotImplementedException();
        }
      
        
    }
}
