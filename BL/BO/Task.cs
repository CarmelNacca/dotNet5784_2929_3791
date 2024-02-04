using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Task
    {
        public int Id { get; init; }
        public int Worker {  get; set; }
        public string? Name {  get; set; }=null;
        public string? Description { get; set; } = null;
        public Status Status { get; set; } = Status.Unscheduled;
        public BO.TaskInList? TaskInList { get; set; } = null;
        public bool Milestone { get; set; } = false;
        public DateTime? createdAtDate { get; set; } = null;
        public DateTime? RequiredEffortTime { get; set; } = null;
        public DateTime? CalculatedEndDate {  get; set; } = null;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? ScheduledDate { get; set; } = null;
        public DateTime? DeadlineDate { get; set; } = null;
        public DateTime? CompleteDate { get; set; } = null;
        public string? Deliverables { get; set; } = null;
        public Expirience? Copmlexity { get; set; } = null;


 
    }
}
