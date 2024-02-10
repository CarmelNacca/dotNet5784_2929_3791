using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Task
{
    public static StatusProject StatusProject { get; set; } = StatusProject.planning;
    public int Id { get; init; }
    public string Description { get; set; } // NN

    public string  Alias {  get; set; }// NN
    public DateTime? createdAtDate { get; set; }// NN
    public Status Status { get; set; } = Status.Unscheduled;
    public List<BO.TaskInList>? Dependencies { get; set; } = null;

    public BO.MilestoneInTask Milestone { get; set; }
    public TimeSpan? RequiredEffortTime { get; set; } = null;
    public DateTime? StartDate { get; set; } = null;///
    public DateTime? ScheduledDate { get; set; } = null;//
    public DateTime? ForeCastDate { get; set; } = null;//
    public DateTime? DeadlineDate { get; set; } = null;//
    public DateTime? CompleteDate { get; set; } = null;///
    public string? Deliverables { get; set; } = null;
    public string? Remarks { get; set; } = null;
    public BO.WorkerInTask? Worker {  get; set; }//CalculatedEndDate StartDate ScheduledDate DeadlineDate CompleteDate Deliverables Copmlexity
    public Expirience? Copmlexity { get; set; } = null;
    
}
