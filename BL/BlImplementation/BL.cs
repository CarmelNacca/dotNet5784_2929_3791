namespace BlImplementation;

using BlApi;
using Dal;

internal class Bl : IBL
{
    public IWorker Worker =>  new WorkerImplementation();


    public ITask Task =>  new TaskImplementation();
    public void InitializeDB() =>Initialization.Do();



}
