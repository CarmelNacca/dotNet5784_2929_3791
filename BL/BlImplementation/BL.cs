namespace BlImplementation;
using BlApi;
internal class Bl : IBL
{
    public IWorker Worker =>  new WorkerImplementation();


    public ITask Task =>  new TaskImplementation();

    
}
