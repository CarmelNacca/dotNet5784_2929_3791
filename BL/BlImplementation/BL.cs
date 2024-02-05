namespace BlImplementation;
using BlApi;
internal class BL : IBL
{
    public IWorker Worker =>  new WorkerImplementation();


    public ITask task =>  new TaskImplementation();

    public IDependency dependency => new DependencyImplementation();
}
