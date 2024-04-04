
namespace Dal;
using DalApi;

using DO;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;



public static class Initialization
{
    /// <summary>
    /// Initialize initial values for all entities
    /// </summary>
    //private static IWorker? s_dalWorker;
    //private static ITask? s_dalTask;
    //private static IDependency? s_dalDependency;
    private static IDal? s_dal; //stage 2



    private static readonly Random s_rand = new();
    private static void creatTask()
    {

        DateTime start = new DateTime(2024, 01, 08);
        DateTime finish = new DateTime(2024, 03, 15);
        int rangStart = (finish - start).Days;
        s_dal!.Task.Create(new Task(0, null, "Signing a contract", "The legal process of adding the formal signature to a contract, signifying agreement and commitment", false, start.AddDays(s_rand.Next(rangStart)), null, null, null, null, null, "Formally signed contract indicating mutual agreement and commitment.", null, (DO.Expirience)0));
        string[] TaskNameForHandyman = {"Replacement of living room windows","Replacing kitchen windows","Replacing bedroom windows",
            "Replacing bathroom windows","Installation of living room floors","Installing bedroom floors","Installing kitchen floors",
            "Installing bathroom floors","Bedroom door replacement","Living room door replacement",
            "Kitchen door replacement","Replacing a bathroom door","Living room air conditioning installation","Installing kitchen air conditioning",
            "Bedroom air conditioning installation","Installation of heating in a bathroom","General house cleaning"};
        string[] TaskNamePainter = { "Painting bedrooms", "Living room painting", "Kitchen painting", "Painting a bathroom" };
        string[] TaskNameArchitect = { "Bedroom planning", "Kitchen planning", "Bathroom design", "Living room planning" };
        string[] TaskNameInteriorDesigner = {"Installation of living room curtains","Installing bedroom curtains","Installing bathroom curtains",
            "Installing kitchen curtains","Bedroom furniture","Living room furniture","Bathroom furniture","kitchen furniture" };
        string[] TaskDescriptionForHandyman = {"The action of removing old windows and installing new ones in the living room.",
            "The action of removing existing windows in the kitchen and installing new ones.",
            "The action of removing existing windows in the bedrooms and installing new ones.",
            "The action of removing existing windows in the bathroom and installing new ones.",
            "The process of installing the flooring surface in the living room, including the selection of flooring material and installation procedures.",
            "The process of installing the flooring surface in the bedrooms, including the selection of flooring material and installation procedures.",
            "The process of installing the flooring surface in the kitchen, including the selection of flooring material and installation procedures.",
            "The process of installing the flooring surface in the bathroom, including the selection of flooring material and installation procedures.",
            "The action of removing existing doors in the bedrooms and installing new ones.",
            "The action of removing the existing door in the living room and installing a new one.",
            "The action of removing the existing door in the kitchen and installing a new one.",
            "The action of removing the existing door in the bathroom and installing a new one.",
            "The process of installing an air conditioning system in the living room.",
            "The process of installing an air conditioning system in the kitchen.",
            "The process of installing an air conditioning system in the bedrooms.",
            "The process of installing a heating system suitable for the bathroom.",
            "A thorough cleaning process for the entire house."};
        string[] TaskDescriptionForPainter = {"Applying a fresh coat of paint to the walls in the bedrooms.",
            "Applying a fresh coat of paint to the walls in the living room.",
            "Applying a fresh coat of paint to the walls in the kitchen.",
            "Applying a fresh coat of paint to the walls in the bathroom."};
        string[] TaskDescriptionForArchitect = {"The process of designing and planning the sleeping spaces in a home, including the selection of furniture, colors, lighting, and aesthetics.",
            "The process of designing and planning the cooking area in a home, including the selection of furniture, accessories, functional planning, and aesthetics.",
            "The process of designing and planning the bathroom space in a home, including the selection of furniture, colors, lighting, and privacy considerations.",
            "The process of designing and planning the central living space in a home, including the selection of furniture, colors, and overall aesthetics."};
        string[] TaskDescriptionForInteriorDesigner = {"The process of installing curtains or blinds in the living room ",
            "The process of installing curtains or blinds in the bedrooms ",
            "The process of installing curtains or blinds in the bathroom ",
            "The process of installing curtains or blinds in the kitchen ",
            "The process of selecting and installing furniture in the bedrooms.",
            "The process of selecting and installing furniture in the living room.",
            "The process of selecting and installing furniture in the bathroom.",
            "The process of selecting and installing furniture in the kitchen."};
        string[] TaskResultForHandyman = {"Improved lighting and aesthetics with new windows.",
            "Enhanced lighting and improved aesthetics in the kitchen.",
            "Improved insulation and aesthetics in bedrooms.",
            "Enhanced privacy and lighting in the bathroom.",
            "Stylish and easy-to-maintain living room flooring.",
            "Comfortable and visually appealing bedroom flooring.",
            "Functional and visually appealing kitchen flooring.",
            "Water-resistant and aesthetically pleasing bathroom flooring.",
            "Modern and privacy-enhancing bedroom doors.",
            "Upgraded living room door for improved security.",
            "New kitchen door enhancing functionality.",
            "Replacement of the bathroom door for improved privacy.",
            "Installation of an air conditioning system for comfort.",
            "Installation of an air conditioning system for a comfortable cooking environment.",
            "Installation of an air conditioning system for a comfortable sleeping environment.",
            "Installation of a heating system in the bathroom for comfort",
            "A thoroughly cleaned and organized home, providing a fresh living space."};
        string[] TaskResultForPainter = {"Refreshed bedroom walls, creating a warm atmosphere.",
            "Renewed living room walls, enhancing the overall ambiance.",
            "Updated kitchen walls, contributing to a clean look.",
            "Revitalized bathroom walls, enhancing cleanliness."};
        string[] TaskResultForArchitect = {"Well-designed and aesthetically pleasing sleeping spaces.",
            "Efficient and aesthetically pleasing kitchen spaces.",
            "Well-designed and private bathroom spaces.",
            "Centrally designed living space with an inviting aesthetic." };
        string[] TaskResultForInteriorDesigner ={"Improved privacy and light control with curtains or blinds.",
            "Enhanced privacy and light control in bedrooms.",
            "Improved privacy and light control in the bathroom.",
            "Enhanced privacy and light control in the kitchen.",
            "Well-selected and arranged furniture for comfort.",
            "Carefully chosen and arranged furniture for a welcoming environment.",
            "Selected and arranged furniture combining functionality with aesthetics.",
            "Thoughtfully selected and arranged furniture enhancing both form and function."};


        for (int i = 0; i < TaskNameForHandyman.Length; i++)
        {
            s_dal!.Task.Create(new Task(0, null, TaskNameForHandyman[i], TaskDescriptionForHandyman[i], false, start.AddDays(s_rand.Next(rangStart)), null, null, null, null, null, TaskResultForHandyman[i], null, (DO.Expirience)1));
        }
        for (int i = 0; i < TaskNamePainter.Length; i++)
        {
            s_dal!.Task.Create(new Task(0, null, TaskNamePainter[i], TaskDescriptionForPainter[i], false, start.AddDays(s_rand.Next(rangStart)), null, null, null, null, null, TaskResultForPainter[i], null, (DO.Expirience)2));
        }
        for (int i = 0; i < TaskNameArchitect.Length; i++)
        {
            s_dal!.Task.Create(new Task(0, null, TaskNameArchitect[i], TaskDescriptionForArchitect[i], false, start.AddDays(s_rand.Next(rangStart)), null, null, null, null, null, TaskResultForArchitect[i], null, (DO.Expirience)3));
        }
        for (int i = 0; i < TaskNameInteriorDesigner.Length; i++)
        {
            s_dal!.Task.Create(new Task(0, null, TaskNameInteriorDesigner[i], TaskDescriptionForInteriorDesigner[i], false, start.AddDays(s_rand.Next(rangStart)), null, null, null, null, null, TaskResultForInteriorDesigner[i], null, (DO.Expirience)4));
        }


    }
    // Method for creating and initializing workers
    private static void creatWorker()
    {
        s_dal!.Worker.Create(new Worker(324561245, 150000, (DO.Expirience)0, "Chaim Cohen", "CH3245@gmail.com"));
        s_dal.Worker.Create(new Worker(322323567, 20000, (DO.Expirience)1, "Yosef Levi", "Yl322@gmail.com"));
        s_dal.Worker.Create(new Worker(035423456, 5000, (DO.Expirience)1, "Muchamad Abu Chasan", "muchamad0@gmail.com"));
        s_dal.Worker.Create(new Worker(467893456, 5000, (DO.Expirience)1, "Muchamad Chabud", "muchamad0000@gmail.com"));
        s_dal.Worker.Create(new Worker(780943567, 15000, (DO.Expirience)2, "Shlomo Ben Chaim", "Shlomo345@gmail.com"));
        s_dal.Worker.Create(new Worker(345792615, 25000, (DO.Expirience)3, "Eden Chason", "Eden1212@gmail.com"));
        s_dal.Worker.Create(new Worker(325952589, 20000, (DO.Expirience)4, "Rut Sharabi", "RS1212@gmail.com"));

    }
    //// Method for creating and initializing dependencies
    private static void creatDependency()
    {
        s_dal!.Dependency.Create(new Dependency(0, 1, 23));
        s_dal.Dependency.Create(new Dependency(0, 1, 24));
        s_dal.Dependency.Create(new Dependency(0, 1, 25));
        s_dal.Dependency.Create(new Dependency(0, 1, 26));
        s_dal.Dependency.Create(new Dependency(0, 23, 4));
        s_dal.Dependency.Create(new Dependency(0, 23, 7));
        s_dal.Dependency.Create(new Dependency(0, 24, 3));
        s_dal.Dependency.Create(new Dependency(0, 24, 8));
        s_dal.Dependency.Create(new Dependency(0, 25, 5));
        s_dal.Dependency.Create(new Dependency(0, 25, 9));
        s_dal.Dependency.Create(new Dependency(0, 26, 2));
        s_dal.Dependency.Create(new Dependency(0, 26, 6));
        s_dal.Dependency.Create(new Dependency(0, 4, 28));
        s_dal.Dependency.Create(new Dependency(0, 7, 10));
        s_dal.Dependency.Create(new Dependency(0, 3, 30));
        s_dal.Dependency.Create(new Dependency(0, 8, 12));
        s_dal.Dependency.Create(new Dependency(0, 5, 29));
        s_dal.Dependency.Create(new Dependency(0, 9, 13));
        s_dal.Dependency.Create(new Dependency(0, 2, 27));
        s_dal.Dependency.Create(new Dependency(0, 6, 11));
        s_dal.Dependency.Create(new Dependency(0, 12, 21));
        s_dal.Dependency.Create(new Dependency(0, 10, 19));
        s_dal.Dependency.Create(new Dependency(0, 13, 22));
        s_dal.Dependency.Create(new Dependency(0, 11, 20));
        s_dal.Dependency.Create(new Dependency(0, 21, 30));
        s_dal.Dependency.Create(new Dependency(0, 19, 28));
        s_dal.Dependency.Create(new Dependency(0, 22, 29));
        s_dal.Dependency.Create(new Dependency(0, 20, 27));
        s_dal.Dependency.Create(new Dependency(0, 21, 34));
        s_dal.Dependency.Create(new Dependency(0, 19, 31));
        s_dal.Dependency.Create(new Dependency(0, 22, 33));
        s_dal.Dependency.Create(new Dependency(0, 20, 32));
        s_dal.Dependency.Create(new Dependency(0, 23, 16));
        s_dal.Dependency.Create(new Dependency(0, 24, 15));
        s_dal.Dependency.Create(new Dependency(0, 25, 17));
        s_dal.Dependency.Create(new Dependency(0, 26, 14));
        s_dal.Dependency.Create(new Dependency(0, 16, 19));
        s_dal.Dependency.Create(new Dependency(0, 14, 20));
        s_dal.Dependency.Create(new Dependency(0, 15, 21));
        s_dal.Dependency.Create(new Dependency(0, 17, 22));
        s_dal.Dependency.Create(new Dependency(0, 18, 31));
        s_dal.Dependency.Create(new Dependency(0, 18, 32));
        s_dal.Dependency.Create(new Dependency(0, 18, 33));
        s_dal.Dependency.Create(new Dependency(0, 18, 34));
    }
    /// <summary>
    /// Main entry point for initializatio
    /// </summary>
    /// <param name="dal_Worker"></param>
    /// <param name="dal_Task"></param>
    /// <param name="dal_Dependency"></param>
    /// <exception cref="NullReferenceException"></exception>
    //public static void Do (IWorker? dal_Worker, ITask? dal_Task, IDependency? dal_Dependency)
    public static void Do() //stage 2

    {
        //s_dalWorker = dal_Worker ?? throw new NullReferenceException("DAL can not be null");
        //s_dalTask = dal_Task ?? throw new NullReferenceException("DAL can not be null");
        //s_dalDependency = dal_Dependency ?? throw new NullReferenceException("DAL can not be null");
        //s_dal = dal ?? throw new NullReferenceException("DAL object can not be null!"); //stage 2
        s_dal = Factory.Get; //stage 4
        Reset();
        s_dal.Task.Reset();
        creatDependency();
        creatTask();
        creatWorker();

    }
    public static void Reset()
    {

        s_dal!.Worker.Reset();
        s_dal.Dependency.Reset();
        s_dal.Task.Reset();
    }


}
