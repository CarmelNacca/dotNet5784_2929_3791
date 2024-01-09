


namespace DO;

/// <summary>
/// 
/// </summary>
/// <param name="Id">Unique ID numbe</param>
/// <param name="IdTask">ID number of pending task</param>
/// <param name="DependsOnTask">ID number of a task that needs to be executed firstr</param>
public record Dependency
( 
    int Id,
    int IdTask,
    int DependsOnTask
  

 )
{
  public Dependency(): this(0,0,0) { }//empty ctor for stage 3

}


