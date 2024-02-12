using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;
public enum Expirience
{
    Contractor,
    Handyman,
    Painter,
    Architect,
    InteriorDesigner
}

public enum Status
{
    Unscheduled,
    Scheduled,
    OnTrack,
    Done
}
public enum StatusProject
{
    planning,//No start date yet
    intermediate,//There is a start date for the project but not for all tasks
    execution//There is a start date for the project and also a date for all tasks
}
