
namespace Dal;
using DalApi;
using DO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Runtime.InteropServices;



public enum Expirience
{
    Contractor,
    Electrician,
    Handyman,
    Painter,
    Architect,
    InteriorDesigner
}
public static class Initialization
{
    private static IWorker? s_dalWorker;
    private static ITask? s_dalTask;
    private static IDependency? s_dalDependency;

    private static readonly Random s_rand = new();
private static void creatTask()
{
        string[] TaskName = { "Painting walls", "Replacing floors", "Replacing windows", "Replacing doors", "Lighting installation"
                , "Electrical repair", "Kitchen design", "Bathroom design", "Sewage system repair", "Installation of air conditioners"
                , "Installing a heating system in the bathroom", "Renovation of bedrooms", "Installation of an electric boiler", "Installation of a security system", "Installation of an underfloor heating system"
                , "Installation of television systems", "Buying new furniture", "Upgrading the water and electricity system in the garden", "Buying furniture for the yard or patio", "Home organization" };
        for (int i = 0; i < 20; i++)
        {
            Task newTask= new Task(,TaskName[i]);
        }

}
    private static void creatWorker()
    {
        Worker newWorker1 = new(324561245, 150000, 0, "Chaim Cohen", "CH3245@gmail.com");
        Worker newWorker2 = new(322323567, 20000, 1, "Yosef Levi", "Yl322@gmail.com");
        Worker newWorker3 = new(035423456, 5000, 2, "Muchamad Abu Chasan", "muchamad0@gmail.com");
        Worker newWorker4 = new(467893456, 5000, 2, "Muchamad Chabud", "muchamad0000@gmail.com");
        Worker newWorker5 = new(780943567, 15000, 3, "Shlomo Ben Chaim", "Shlomo345@gmail.com");
        Worker newWorker6 = new(345792615, 25000, 4, "Eden Chason", "Eden1212@gmail.com");
        Worker newWorker7 = new(325952589, 20000, 5, "Rut Sharabi", "RS1212@gmail.com");
        int id1 = WorkerImplementation.Create(newWorker1);
    }
 private static void creatDependency() 
{

}
}

