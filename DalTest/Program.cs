namespace DalTest;
using Dal;
using DalApi;
using DO;

internal class Program
{
    /// <summary>
    /// The structure of the main program and the main menu includes methods that display a submenu for each entity
    /// </summary>

    //private static IWorker? s_dalWorker = new WorkerImplementation();
    //private static ITask? s_dalTask = new TaskImplementation();
    //private static IDependency? s_dalDependency = new DependencyImplementation();
    static readonly IDal s_dal = new DalList(); //stage 2
    static void Main(string[] args)
    {
        try
        {
            ///  Initializing the data using the Initialization class
             Initialization.Do(s_dal); //stage 2
            //Initialization.Do(s_dalWorker, s_dalTask, s_dalDependency);
            ///// Main menu for selecting an entity type
            Console.WriteLine("Select 1 for Worker, 2 for Task, 3 for Dependency and 0 for exit");
            int choice = int.Parse(Console.ReadLine()!);
            while (choice != 0)
            {
            switch (choice)
            {
                case 1:
                    {
                        menuWorker();
                    }
                    break;
                case 2:
                    {
                        menuTask();
                    }
                    break;
                case 3:
                    {
                        menuDependency();
                    }
                    break;
                default: throw new Exception("Number error Enter a number between 0 and 3");
            }
                Console.WriteLine("Select 1 for Worker, 2 for Task, 3 for Dependency and 0 for exit");
                choice = int.Parse(Console.ReadLine()!);
            }
        }
        catch (Exception ex) { Console.WriteLine(ex); };


        void menuWorker()///// Submenu for Worker operations
        {
            Console.WriteLine("To add press 1, to display an object press 2, to display all objects press 3, to update press 4, to delete 5 and to exit the main menu press 0.");
            int choice2 = int.Parse(Console.ReadLine()!);
            switch (choice2)
            {
                case 0:
                    break;
                case 1:
                    {
                        Console.WriteLine("Enter an employee role for contractor 0, for handyman 1, for painters 2, for architect 3, for interior designer 4.");
                        int exprience = int.Parse(Console.ReadLine()!);
                        if (exprience > 4 || exprience < 0)
                            throw new Exception("Number error Enter a number between 0 and 3");
                        Console.WriteLine("Enter ID, payment, name and email address for worker");
                        s_dal!.Worker.Create(new Worker(int.Parse(Console.ReadLine()!), double.Parse(Console.ReadLine()!), (DO.Expirience)exprience, Console.ReadLine()!, Console.ReadLine()!));
                        
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        Console.WriteLine(s_dal!.Worker.Read(int.Parse(Console.ReadLine()!)));

                    }
                    break;
                case 3:
                    {
                        List<Worker> newWorkers = s_dal.Worker.ReadAll();

                        foreach (var worker in newWorkers)
                        {
                            Console.WriteLine(worker);
                        }
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter ID, payment,level, name and email address for worker");
                        Worker newWorker = new Worker(int.Parse(Console.ReadLine()!), double.Parse(Console.ReadLine()!), (DO.Expirience)int.Parse(Console.ReadLine()!), Console.ReadLine()!, Console.ReadLine()!);
                        s_dal!.Worker.Update(newWorker);
                    }
                    break;
                case 5:
                    {

                        Console.WriteLine("Enter Id for delete");
                        s_dal!.Worker.Delete(int.Parse(Console.ReadLine()!));
                    }
                    break;
                default: throw new Exception("Number error ");
            }
        }
        void menuTask()///// Submenu for Task operations
        {
            Console.WriteLine("To add press 1, to display an object press 2, to display all objects press 3, to update press 4, to delete 5 and to exit the main menu press 0.");
            int choice2 = int.Parse(Console.ReadLine()!);
            switch (choice2)
            {
                case 0:
                    break;
                case 1:
                    {
                        Console.WriteLine("Enter Worker's Id, name, desciption, date of reqiered, date of start,date of schduled, date of deadline, date of complete, deliverables and expirience ");
                        DO.Task newTask = new DO.Task(0, int.Parse(Console.ReadLine()!), Console.ReadLine()!, Console.ReadLine()!, false, DateTime.Now, DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), Console.ReadLine(), (Expirience)int.Parse(Console.ReadLine()!));
                        s_dal!.Task.Create(newTask);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        Console.WriteLine(s_dal!.Task.Read(int.Parse(Console.ReadLine()!)));

                    }
                    break;
                case 3:
                    {
                        List<DO.Task> newTask = s_dal!.Task.ReadAll();

                        foreach (var task in newTask)
                        {
                            Console.WriteLine(task);
                        }
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter Id, Worker's Id, name, desciption, date of reqiered, date of start,date of schduled, date of deadline, date of complete, deliverables and expirience ");
                        DO.Task newTask = new DO.Task(int.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!), Console.ReadLine()!, Console.ReadLine()!, false, DateTime.Now, DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), DateTime.Parse(Console.ReadLine()!), Console.ReadLine(), (Expirience)int.Parse(Console.ReadLine()!));
                        s_dal!.Task.Update(newTask);
                    }
                    break;
                case 5:
                    {

                        Console.WriteLine("Enter Id for delete");
                        s_dal!.Task.Delete(int.Parse(Console.ReadLine()!));
                    }
                    break;
                default: throw new Exception("Number error ");
            }
        }
            void menuDependency()///// Submenu for Dependency operations
        {
                Console.WriteLine("To add press 1, to display an object press 2, to display all objects press 3, to update press 4, to delete 5 and to exit the main menu press 0.");
                int choice2 = int.Parse(Console.ReadLine()!);
                switch (choice2)
                {
                    case 0:
                        break;
                    case 1:
                        {
                           
                        Console.WriteLine("Enter task's Id and Id number of a task that needs to be executed first ");
                        int taskId = int.Parse(Console.ReadLine()!);
                        int DependencyId = int.Parse(Console.ReadLine()!);
                        Dependency newDependency = new Dependency(0,taskId ,DependencyId);
                            s_dal.Dependency.Create(newDependency);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter Id");
                            Console.WriteLine(s_dal.Dependency.Read(int.Parse(Console.ReadLine()!)));

                        }
                        break;
                    case 3:
                        {
                            List<Dependency> newDependency = s_dal.Dependency.ReadAll();

                            foreach (var dependency in newDependency)
                            {
                                Console.WriteLine(dependency);
                            }
                        }
                        break;
                    case 4:
                        {
                        Console.WriteLine("Enter Id, task's Id and Id number of a task that needs to be executed first ");
                        int Id = int.Parse(Console.ReadLine()!);
                        int taskId = int.Parse(Console.ReadLine()!);
                        int DependencyId = int.Parse(Console.ReadLine()!);
                        Dependency newDependency = new Dependency(Id, taskId, DependencyId);
                        s_dal.Dependency.Update(newDependency);
                        }
                        break;
                    case 5:
                        {

                            Console.WriteLine("Enter Id for delete");
                            s_dal.Dependency.Delete(int.Parse(Console.ReadLine()!));
                        }
                        break;
                    default: throw new Exception("Number error ");
                }
            }

        }
    }



