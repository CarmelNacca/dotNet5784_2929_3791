
using DalApi;

namespace BlApi
{
    public interface IBL
    {
        
        public IWorker Worker { get; }
        public ITask Task { get; }
        public void InitializeDB();
        public void ResetDB()
        {

            BlApi.Factory.Get();
            DalApi.IDal s_dal = DalApi.Factory.Get;
            s_dal.Dependency.Reset();
            s_dal.Worker.Reset();
            s_dal.Task.Reset();
            

        }

    }
}
