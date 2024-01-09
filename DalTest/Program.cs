using Dal;
using DalApi;
using DO;

namespace DalTest;





public class Program
{
    /// <summary>
    /// The structure of the main program and the main menu includes methods that display a submenu for each entity
    /// </summary>

    private static IWorker? s_dalWorker = new WorkerImplementation();
    private static ITask? s_dalTask = new TaskImplementation();
    private static IDependency? s_dalDependency = new DependencyImplementation();
    static void Main(string[] args)
    {
        try
        {
            Initialization.Do(s_dalWorker, s_dalTask, s_dalDependency);
            Console.WriteLine("Select 1 for Worker, 2 for Task, 3 for Dependency and 0 for exit");
            int choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 0:
                    {

                    }
                    break;
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

        }
        catch (Exception ex) { Console.WriteLine(ex); };


        void menuWorker()
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
                        Worker newWorker = new Worker(int.Parse(Console.ReadLine()!), double.Parse(Console.ReadLine()!), (DO.Expirience)exprience, Console.ReadLine()!, Console.ReadLine()!);
                        s_dalWorker!.Create(newWorker);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        Console.WriteLine(s_dalWorker!.Read(int.Parse(Console.ReadLine()!)));

                    }
                    break;
                case 3:
                    {
                        List<Worker> newWorkers = s_dalWorker!.ReadAll();

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
                        s_dalWorker!.Update(newWorker);
                    }
                    break;
                case 5:
                    {

                        Console.WriteLine("Enter Id for delete");
                        s_dalWorker!.Delete(int.Parse(Console.ReadLine()!));
                    }
                    break;
                default: throw new Exception("Number error ");
            }
        }
        void menuTask()
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
                        s_dalTask!.Create(newTask);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        Console.WriteLine(s_dalTask!.Read(int.Parse(Console.ReadLine()!)));

                    }
                    break;
                case 3:
                    {
                        List<DO.Task> newTask = s_dalTask!.ReadAll();

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
                        s_dalTask!.Update(newTask);
                    }
                    break;
                case 5:
                    {

                        Console.WriteLine("Enter Id for delete");
                        s_dalTask!.Delete(int.Parse(Console.ReadLine()!));
                    }
                    break;
                default: throw new Exception("Number error ");
            }
        }
            void menuDependency()
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
                            Dependency newDependency = new Dependency(0, int.Parse(Console.ReadLine()!) ,int.Parse(Console.ReadLine()!));
                            s_dalDependency!.Create(newDependency);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter Id");
                            Console.WriteLine(s_dalDependency!.Read(int.Parse(Console.ReadLine()!)));

                        }
                        break;
                    case 3:
                        {
                            List<Dependency> newDependency = s_dalDependency!.ReadAll();

                            foreach (var dependency in newDependency)
                            {
                                Console.WriteLine(dependency);
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter Id, task's Id and Id number of a task that needs to be executed first ");
                            Dependency newDependency = new Dependency(int.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!));
                            s_dalDependency!.Update(newDependency);
                        }
                        break;
                    case 5:
                        {

                            Console.WriteLine("Enter Id for delete");
                            s_dalDependency!.Delete(int.Parse(Console.ReadLine()!));
                        }
                        break;
                    default: throw new Exception("Number error ");
                }
            }

        }
    }



