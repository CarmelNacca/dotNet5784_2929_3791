
namespace DO;
/// <summary>
/// Defining the task entity
/// </summary>
/// <param name="Id">Unique ID numbe</param>
/// <param name="Worker">The Worker ID assigned to the task</param>
/// <param name="Name"></param>
/// <param name="Description"></param>
/// <param name="Milestone"></param>
/// <param name="createdAtDate">Date when the task was added to the system</param>
/// <param name="RequiredEffortTime">how many men-days needed for the task (for MS it is null)</param>
/// <param name="StartDate">the real start date</param>
/// <param name="ScheduledDate">the planned start date</param>
/// <param name="DeadlineDate">the latest complete date</param>
/// <param name="CompleteDate">real completion date</param>
/// <param name="Deliverables">description of deliverables for MS copmletion</param>
/// <param name="Expirience">minimum expirience for Worker to assign</param>

public record Task
(
    int Id,
    int? Worker=null,
    string? Name = null,
    string? Description= null,
    bool Milestone= false,
    
    DateTime? createdAtDate=null,
TimeSpan? RequiredEffortTime = null,
    DateTime? StartDate = null,
    DateTime? ScheduledDate = null,
    DateTime? DeadlineDate = null,  
    DateTime? CompleteDate = null,
    string? Deliverables= null,
    string? Remarks=null,

  Expirience? Copmlexity = null
  
    )
    
{
    
    public Task(): this (0,0) {  }///empty ctor for stage 3


}






