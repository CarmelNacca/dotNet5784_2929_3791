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
public enum ExpiriencePl//We have defined another enum so that updates cannot use the "ALL" value to represent an Worker level and it will only be used for the display layer
{
    Contractor,
    Handyman,
    Painter,
    Architect,
    InteriorDesigner,
    All
}

public enum Status
{
    Unscheduled,
    Scheduled,
    OnTrack,
    Done
}
public enum StatusPl
{
    Unscheduled,
    Scheduled,
    OnTrack,
    Done,
    All
}
public enum StatusProject
{
    planning,//No start date yet
    intermediate,//There is a start date for the project but not for all tasks
    execution//There is a start date for the project and also a date for all tasks
}
