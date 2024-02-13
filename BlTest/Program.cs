using BO;
using Dal;
using DalApi;
using DO;

namespace BlTest;

internal class Program
{
    static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

    static void Main(string[] args)
    {
        try
        {
            Console.Write("Would you like to create Initial data? (Y/N)");
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input");
            if (ans == "Y")
                Initialization.Do();

            //Initialization.Do(s_dalWorker, s_dalTask, s_dalDependency);
            ///// Main menu for selecting an entity type
            Console.WriteLine("Select 1 for Worker, 2 for Task and 0 for exit");
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
                   
                    default: throw new Exception("Number error Enter a number between 0 and 3");
                }
                Console.WriteLine("Select 1 for Worker, 2 for Task, and 0 for exit");
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
                        Console.WriteLine("Enter ID,name, email and cost for worker");
                        BO.Worker worker =new BO.Worker { Id = int.Parse(Console.ReadLine()!), Name = Console.ReadLine()!, Email = Console.ReadLine()!, Level = (BO.Expirience)exprience, Cost = double.Parse(Console.ReadLine()!) };
                        s_bl.Worker.Add(worker);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        Console.WriteLine(s_bl!.Worker.Read(int.Parse(Console.ReadLine()!)));

                    }
                    break;
                case 3:
                    {
                        IEnumerable<BO.Worker?> newWorkers = s_bl.Worker.ReadAll(null);

                        foreach (var worker in newWorkers)
                        {
                            Console.WriteLine(worker);
                        }
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter ID, name, email,level  and payment and cost for worker");
                        BO.Worker worker = new BO.Worker { Id = int.Parse(Console.ReadLine()!), Name = Console.ReadLine()!, Email = Console.ReadLine()!, Level = (BO.Expirience)int.Parse(Console.ReadLine()!), Cost = double.Parse(Console.ReadLine()!) };
                        s_bl!.Worker.Update(worker);
                    }
                    break;
                case 5:
                    {

                        Console.WriteLine("Enter Id for delete");
                        s_bl!.Worker.Delete(int.Parse(Console.ReadLine()!));
                    }
                    break;
                default: throw new Exception("Number error ");
            }
        }
        void menuTask()///// Submenu for Task operations
        {
            Console.WriteLine("To add press 1, to display an object press 2, to display all objects press 3, to update press 4, to delete 5,to update date of start press 6,to tasks with status donepress 7 and to exit the main menu press 0.");
            int choice2 = int.Parse(Console.ReadLine()!);
            switch (choice2)
            {
                case 0:
                    break;
                case 1:
                    {
                        Console.WriteLine("Enter name, idWorker, desciption, date of reqiered, date of start,date of schduled,date of forcast , date of deadline, date of complete, deliverables,remarks and expirience ");
                        BO.Task newTask = new BO.Task { Id = 0,Alias = Console.ReadLine()!,Worker=new BO.WorkerInTask{ Id = int.Parse(Console.ReadLine())}, Description = Console.ReadLine()!
                            ,createdAtDate=DateTime.Now, RequiredEffortTime = TimeSpan.Parse(Console.ReadLine()!),Status = BO.Status.Unscheduled,
                            StartDate = DateTime.Parse(Console.ReadLine()!),ScheduledDate= DateTime.Parse(Console.ReadLine()!),ForeCastDate = DateTime.Parse(Console.ReadLine()!),
                            DeadlineDate = DateTime.Parse(Console.ReadLine()!), CompleteDate = DateTime.Parse(Console.ReadLine()!),
                            Deliverables = Console.ReadLine(),Remarks=Console.ReadLine(), Copmlexity = (BO.Expirience)int.Parse(Console.ReadLine()!) };
                        newTask.Worker.Name = s_bl.Worker.Read(newTask.Worker.Id).Name;
                        Console.WriteLine("Do you want to enter dependencies?");
                        string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input");
                        if (ans == "y"||ans=="Y")
                        {
                            List<TaskInList> tasks = new List<TaskInList>();
                            Console.WriteLine("Enter Id of tasks to stop press -1");
                            int id=int.Parse(Console.ReadLine()!);
                            while(id!=-1)
                            {
                                var task = s_bl.Task.Read(id);
                                tasks.Add( new TaskInList { Id = task.Id, Alias = task.Alias, Description = task.Description, Status = task.Status });
                            }
                            newTask.Dependencies=tasks;
                        }
                        
                        s_bl!.Task.Add(newTask);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter Id");
                        Console.WriteLine(s_bl!.Task.Read(int.Parse(Console.ReadLine()!)));

                    }
                    break;
                case 3:
                    {
                        IEnumerable<BO.TaskInList?> newTask = s_bl!.Task.ReadAll();

                        foreach (var task in newTask)
                        {
                            Console.WriteLine(task);
                        }
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter id, name, desciption, date of reqiered, date of start,date of schduled,date of forcast , date of deadline, date of complete, deliverables,remarks and expirience ");
                        BO.Task newTask = new BO.Task { Id =int.Parse(Console.ReadLine()!), Alias = Console.ReadLine()!, Description = Console.ReadLine()!
                            ,createdAtDate=DateTime.Now, RequiredEffortTime = TimeSpan.Parse(Console.ReadLine()!),
                            StartDate = DateTime.Parse(Console.ReadLine()!),ScheduledDate= DateTime.Parse(Console.ReadLine()!),ForeCastDate = DateTime.Parse(Console.ReadLine()!),
                            DeadlineDate = DateTime.Parse(Console.ReadLine()!), CompleteDate = DateTime.Parse(Console.ReadLine()!),
                            Deliverables = Console.ReadLine(),Remarks=Console.ReadLine(), Copmlexity = (BO.Expirience)int.Parse(Console.ReadLine()!) };
                         s_bl!.Task.Update(newTask);
                    }
                    break;
                case 5:
                    {

                        Console.WriteLine("Enter Id for delete");
                        s_bl!.Task.Delete(int.Parse(Console.ReadLine()!));
                    }
                    break;
                case 6:
                    {
                        Console.WriteLine("Enter id of task and date");
                        int id=int.Parse(Console.ReadLine()!);
                        s_bl.Task.UpdateDate(id, DateTime.Parse(Console.ReadLine()!));
                    }
                    break;
                case 7:
                    {
                        s_bl.Task.TasksWithStatusDone();
                    }
                    break;
                default: throw new Exception("Number error ");
            }
        }
        

    }
}

