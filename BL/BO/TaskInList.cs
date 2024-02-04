using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class TaskInList
    {
        public int Id { get; init; }
        public string? Name { get; set; } = null;
        public string? Description { get; set; } = null;
        public Status Status { get; set; } = Status.Unscheduled;
    }
}
