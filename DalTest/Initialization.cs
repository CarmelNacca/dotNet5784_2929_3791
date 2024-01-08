
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
            s_dalTask!.Create(new Task(0,TaskName[i]));
        }

}
    private static void creatWorker()
    {
        s_dalWorker!.Create(new Worker(324561245, 150000, (DO.Expirience)0, "Chaim Cohen", "CH3245@gmail.com"));
        s_dalWorker!.Create(new Worker(322323567, 20000, (DO.Expirience)1, "Yosef Levi", "Yl322@gmail.com"));
        s_dalWorker!.Create(new Worker(035423456, 5000, (DO.Expirience)2, "Muchamad Abu Chasan", "muchamad0@gmail.com"));
        s_dalWorker!.Create(new Worker(467893456, 5000, (DO.Expirience)2, "Muchamad Chabud", "muchamad0000@gmail.com"));
        s_dalWorker!.Create(new Worker(780943567, 15000, (DO.Expirience)3, "Shlomo Ben Chaim", "Shlomo345@gmail.com"));
        s_dalWorker!.Create(new Worker(345792615, 25000, (DO.Expirience)4, "Eden Chason", "Eden1212@gmail.com"));
        s_dalWorker!.Create(new Worker(325952589, 20000, (DO.Expirience)5, "Rut Sharabi", "RS1212@gmail.com"));
       
    }
 private static void creatDependency() 
{

}
}

