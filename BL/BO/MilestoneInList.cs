using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class MilestoneInList
{
    public int Id { get; init; }
    public string Description { get; set; }// NN
    public string Alias { get; set; }// NN
    public Status Status { get; set; } = Status.Unscheduled;// NN
    public double CompletionPercentage {  get; set; }

}
