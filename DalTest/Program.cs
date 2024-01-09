using Dal;
using DalApi;
using DO;

namespace DalTest;

public class Program
{
    
    private static IWorker? s_dalWorker = new WorkerImplementation(); 
    private static ITask? s_dalTask = new TaskImplementation(); 
    private static IDependency? s_dalDependency = new DependencyImplementation();
    static void Main(string[] args)
    {
        try 
        {
            Initialization.Do(s_dalWorker, s_dalTask, s_dalDependency);
            Console.WriteLine("Select 1 for Worker, 2 for Task, 3 for Dependency and 0 for exit");
            int choice=int.Parse(Console.ReadLine()!);
            switch (choice) 
            {
                case 0:
                    { 

                    }
                    break;
                case 1:                    Console.WriteLine("To add press 1, to display an object press 2, to display all objects press 3, to update press 4, to delete 5 and to exit the main menu press 0.");
                    int choice2=int.Parse(Console.ReadLine() !);
                    switch (choice2)
                        {
                            case 0:
                                break;
                            case 1:
                            {
                                Console.WriteLine("Enter an employee role for contractor 0, for handyman 1, for painters 2, for architect 3, for interior designer 4.");
                                int exprience=int.Parse(Console.ReadLine() !);
                                if(exprience>4||exprience<0)
                                    throw new Exception("Number error Enter a number between 0 and 3");
                                Console.WriteLine("Enter ID, payment, name and email address for worker");
                                Worker newWorker = new Worker(int.Parse(Console.ReadLine()!), double.Parse(Console.ReadLine()!), (DO.Expirience)exprience, Console.ReadLine()!, Console.ReadLine()!);
                                s_dalWorker!.Create(newWorker);
                            }
                                break;
                            case 2:
                            {
                                Console.WriteLine("Enter Id");
                                Console.WriteLine( s_dalWorker!.Read(int.Parse(Console.ReadLine()!)));

                            }
                            break;
                            case 3:
                            {
                                List<Worker> newWorkers =s_dalWorker!.ReadAll();

                                foreach (var worker in newWorkers)
                                {
                                    Console.WriteLine(worker); 
                                }
                            }
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            default: throw new Exception("Number error Enter a number between 0 and 3");
                        }

                    break;
                case 2:
                    break;
                case 3:
                    break;
                default: throw new Exception("Number error Enter a number between 0 and 3");
            }

        }
        catch (Exception ex) { };

   
    }
}
