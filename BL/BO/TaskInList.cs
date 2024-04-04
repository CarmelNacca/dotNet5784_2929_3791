using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BO
{
    public class TaskInList
    {
        public int Id { get; init; }
        public string Description { get; set; } = " "; 
        public string Alias { get; set; } = " ";

        public Status Status { get; set; } = Status.Unscheduled;
        public override string ToString()
        {
            return ("id=" + Id + ", name=" + Alias + ", description=" + Description + ", status=" + Status );
        }
    }
}
